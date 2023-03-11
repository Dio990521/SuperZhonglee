using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] items;
    public float interval = 5f;
    public bool isLoop = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Spawn());
        }

    }

    private IEnumerator Spawn()
    {
        if (isLoop)
        {
            foreach (GameObject spawner in spawners)
            {
                int index = Random.Range(0, items.Length);
                GameObject item = items[index];
                Instantiate(item, spawner.transform);
                yield return new WaitForSeconds(interval);
            }
        }
        else
        {
            foreach (GameObject spawner in spawners)
            {
                int index = Random.Range(0, items.Length);
                GameObject item = items[index];
                Instantiate(item, spawner.transform);
                yield return null;
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
