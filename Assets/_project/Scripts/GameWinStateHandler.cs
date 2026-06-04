using UnityEngine;

public class GameWinStateHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    void Start()
    {
        winScreen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("win ya bro");

            Invoke("WinSequence",10f);
            
        }
    }

    private void WinSequence()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
