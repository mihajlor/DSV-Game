using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillzone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().Respawn();
        }
    }

}
