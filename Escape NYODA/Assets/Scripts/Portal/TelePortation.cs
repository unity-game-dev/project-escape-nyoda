using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortation : MonoBehaviour
{
    public GameObject Portal, Player;
    public static int StartTeleport = 0;
    public bool canTeleport;

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.E) && (canTeleport))
        {
            StartCoroutine(Teleport());
            canTeleport = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && TelePortation.StartTeleport == 1)
        {
            canTeleport = true;
            TelePortation.StartTeleport = 0;
        }

    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
