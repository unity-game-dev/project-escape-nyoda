using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortation : MonoBehaviour
{
    public GameObject Portal, Player;
    public static int StartTeleport = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && TelePortation.StartTeleport == 1)
        {
            TelePortation.StartTeleport = 0;
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
