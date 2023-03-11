using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private Animator animator;
    public Type type;
    public enum Type
    {
        Spawner,
        Path,
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AudioManager.instance.PlaySE("fireworks");
            animator.SetBool("isSet", true);
            switch (type)
            {
                case Type.Spawner:
                    GetComponentInParent<EnemySpawner>().enabled = true;
                    GetComponentInParent<EnemySpawner>().isSpawning = true;
                    break;
                case Type.Path:
                    transform.GetChild(0).gameObject.SetActive(true);
                    break;

            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            switch (type)
            {
                case Type.Spawner:
                    break;
                case Type.Path:
                    transform.GetChild(0).gameObject.SetActive(false);
                    animator.SetBool("isSet", false);
                    break;

            }
        }
            
    }
}
