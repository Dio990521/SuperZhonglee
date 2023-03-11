using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private GameObject dialogueWindow;
    private Chest chest;

    public string dialogue;
    public string successDialogue;
    private string errorDialogue = "Ô­Ê¯²»Ì«¹»Äó...";

    private void Awake()
    {
        dialogueWindow = GameObject.FindGameObjectWithTag("dialogueWindow");
        chest = GetComponentInParent<Chest>();
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !chest.isOpen)
        {
            dialogueWindow.GetComponent<SpriteRenderer>().enabled = true;
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogue;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
            dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
    }

    public void Sucess()
    {
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = successDialogue;
    }

    public void Fail()
    {
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = errorDialogue;
    }

}
