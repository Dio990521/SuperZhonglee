using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private Animator animator;
    public int savePointId;

    private void Start()
    {
        GameManager.instance.savePoints[savePointId] = gameObject;
        animator = GetComponent<Animator>();
        if (GameManager.instance.activeSavePointIndex == savePointId)
        {
            GameManager.instance.ReactivateSavePoint(savePointId);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.activeSavePointIndex != savePointId || GameManager.instance.activeSavePointIndex < 0)
            {
                AudioManager.instance.PlaySE("pause");
            }
            GameManager.instance.SetSavePoint(collision.transform.position, savePointId);
        }
    }
}
