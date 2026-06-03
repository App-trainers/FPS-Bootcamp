using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private List<Room> _rooms;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void SpawnEnemies(int roomIndex)
    {
        foreach (Room room in _rooms)
        {
            if (room.roomIndex == roomIndex)
            {
                if (room.roomData.IsTriggered) return;
               
                foreach (Enemy enemy in room.roomData.Enemies)
                {
                    enemy.gameObject.SetActive(true);
                }
                room.roomData.IsTriggered = true;
            }
        }
    }

}


