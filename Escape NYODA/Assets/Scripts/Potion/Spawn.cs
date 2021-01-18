
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 spawnPos = new Vector2(player.position.x + player.right.x + 2, player.position.y);
        Instantiate(item, spawnPos, Quaternion.identity);
    }
}
