using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachineBlock : MonoBehaviour
{
    public Sprite sprite;
    private void Awake()
    {
        if (GameManager.instance.isJumpMachine)
        {
            GetComponent<BlockHit>().maxHits = 0;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

}
