using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Killbox : MonoBehaviour
{
    GameObject gameObjectToKill;

    private void Start()
    {
        gameObjectToKill = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().IsFalling() == true)
            {
                gameObject.GetComponentInParent<Enemy_SlimeMovement>().KillMe();               
            } 
            
        }
    }
}
