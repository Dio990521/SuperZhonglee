using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Skilling());
    }

    private IEnumerator Skilling()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject, 0.2f);
        GetComponent<Animator>().SetTrigger("isFade");
    }

}
