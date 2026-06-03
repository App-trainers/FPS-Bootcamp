using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int roomIndex;
    public RoomData roomData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemySpawner.Instance.SpawnEnemies(roomIndex);
        }
    }

    #region JUST FOR TESTING PURPOSES
    [ContextMenu("Test Trigger Room")]
    public void TestTriggerRoom()
    {
        EnemySpawner.Instance.SpawnEnemies(roomIndex);
    }
    #endregion
}



[Serializable]
public struct RoomData
{
    public List<Enemy> Enemies;

    public bool IsTriggered;
}

