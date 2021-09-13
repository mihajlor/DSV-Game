using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Giver : MonoBehaviour
{

    [SerializeField] private GameObject questGiverText;

    [SerializeField] private Text textComponent;

    [SerializeField] private string questBeginText;
    [SerializeField] private string questIsCompleteText;


    [SerializeField] private int amountToCollect = 1;

    [SerializeField] private GameObject doorToOpenWhenQuestIsComplete;


    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(false);

        textComponent.text = questBeginText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.GetComponent<PlayerState>().coinAmount >= amountToCollect)
            {
                textComponent.text = questIsCompleteText;
                collision.GetComponent<Quest_Player>().isQuestComplete = true;
                doorToOpenWhenQuestIsComplete.SetActive(false);
            }

            else
            {
                textComponent.text = questBeginText;
            }

            questGiverText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            questGiverText.SetActive(false);
        }
    }
}
