using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public int healthPoints = 2;
    public int initialHealthPoints = 2;

    public int coinAmount = 0;

    private GameObject respawnPosition;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = initialHealthPoints;
        if (useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }
        respawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoHarm(int doHarmByThisMuch)
    {
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0)
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
    }

    public void CoinPickup()
    {
        coinAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }

}
