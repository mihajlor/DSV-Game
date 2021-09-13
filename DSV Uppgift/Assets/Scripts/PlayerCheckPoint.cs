using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    [SerializeField] private Sprite checkPointTaken;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = checkPointTaken;
        }
    }

}
