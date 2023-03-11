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
        dialogues[0] = "�����������Щʷ��ķһ������������������硣";
        dialogues[1] = "���ң������ȣ�����������������......";
        dialogues[2] = "Ģ��Ҳ�ã�ˮ��Ҳ�ã�����ϲ����ש��Ҳ�á�";
        dialogues[3] = "Ϊʲô����������......";
        dialogues[4] = "�����㻹�ǿ�����ͷ������ȥ�ɣ������ˡ�";
        dialogues[5] = "���������ʲô�ģ��Ѿ�����ν�ˡ�";

        dialogues[6] = "�Ҳ�ϲ��������ʹ������...";
        dialogues[7] = "�����ִ��������ô���Ļ�...�Ǿ����ɣ�";

        dialogues[8] = "��Ӯ�ˡ�";
        dialogues[9] = "�����ڿ�ʼ�������������˾�������...";
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
