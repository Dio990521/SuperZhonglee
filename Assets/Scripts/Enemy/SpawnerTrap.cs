using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrap : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject[] enemies;
    public float interval = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.PlaySE("fireworks");
            StartCoroutine(SpawnEnemy1());
        }
        
    }

    private IEnumerator SpawnEnemy1()
    {
        foreach (GameObject spawner in spawners)
        {
            int index = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[index];
            Instantiate(enemy, spawner.transform);
            enemy.GetComponent<EntityMovement>().direction = Vector3.left;
            yield return new WaitForSeconds(interval);
        }

        foreach (GameObject spawner in spawners)
        {
            int index = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[index];
            Instantiate(enemy, spawner.transform);
            enemy.GetComponent<EntityMovement>().direction = Vector3.left;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator SpawnEnemy2()
    {
        foreach (GameObject spawner in spawners)
        {
            int index = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[index];
            enemy.GetComponent<EntityMovement>().direction = Vector3.right;
            Instantiate(enemy, spawner.transform);
            yield return new WaitForSeconds(interval);
        }

        foreach (GameObject spawner in spawners)
        {
            int index = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[index];
            enemy.GetComponent<EntityMovement>().direction = Vector3.right;
            Instantiate(enemy, spawner.transform);
            yield return new WaitForSeconds(interval);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(SpawnEnemy2());
        }
    }

}
