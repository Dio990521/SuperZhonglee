using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public enum Type
    {
        Tele1,
        Tele2,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case Type.Tele1:
                    collision.gameObject.transform.position = new Vector2(30.85f, -44.14f);
                    break;
                case Type.Tele2:
                    collision.gameObject.transform.position = new Vector2(26.26f, -44.14f);
                    break;
            }
            
        }
    }
}
