using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossDialogue : MonoBehaviour
{
    private GameObject dialogueWindow;
    private string[] dialogues = new string[10];

    private bool isStart = false;

    private void Awake()
    {
        dialogueWindow = GameObject.FindGameObjectWithTag("dialogueWindow");
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        dialogues[0] = "看样子你跟那些史莱姆一样，都不属于这个世界。";
        dialogues[1] = "是我，是我先，明明都是我先来的......";
        dialogues[2] = "蘑菇也好，水管也好，还是喜欢顶砖块也好。";
        dialogues[3] = "为什么会变成这样呢......";
        dialogues[4] = "唉，你还是快点从我头上跳过去吧，异乡人。";
        dialogues[5] = "超级马里奥什么的，已经无所谓了。";

        dialogues[6] = "我不喜欢用武力使人屈服...";
        dialogues[7] = "如果你执意让我这么做的话...那就来吧！";

        dialogues[8] = "你赢了。";
        dialogues[9] = "从现在开始，这个世界的主人就是你了...";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isStart)
        {
            isStart = true;
            StartCoroutine(Dialogue1());
        }

    }

    private IEnumerator Dialogue1()
    {
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[0];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[1];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[2];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[3];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[4];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[5];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

    public void Dialogue22()
    {
        StartCoroutine(Dialogue2());
    }

    public void Dialogue33()
    {
        StartCoroutine(Dialogue3());
    }

    private IEnumerator Dialogue2()
    {
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[6];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[7];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

    private IEnumerator Dialogue3()
    {
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[8];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[9];
        yield return new WaitForSeconds(3f);
        dialogueWindow.GetComponent<SpriteRenderer>().enabled = false;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

}
