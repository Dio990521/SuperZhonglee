using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float interval = 5f;
    public Vector2 direction = Vector2.left;

    public bool isSpawning = false;
    public bool setVisibility = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void OnBecameInvisible()
    {
        if (setVisibility)
        {
            isSpawning = false;
        }
        else
        {
            isSpawning = true;
        }
    }

    private void OnBecameVisible()
    {
        if (setVisibility)
        {
            isSpawning = true;
        }
        else
        {
            isSpawning = true;
        }
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (isSpawning)
            {
                int index = Random.Range(0, enemies.Length);
                GameObject enemy = enemies[index];
                enemy.GetComponent<EntityMovement>().direction = direction;
                enemy.GetComponent<SpriteRenderer>().flipX = direction.x > 0 ? true : false;
                Instantiate(enemy, transform);
                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return null;
            }
        }
    }
}
