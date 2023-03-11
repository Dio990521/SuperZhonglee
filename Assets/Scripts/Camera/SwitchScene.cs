using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    private CameraController cameraController;
    
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cameraController.activateY = true;
            cameraController.minY = -49.96f;
            GameManager.instance.isCameraY = true;
        }
    }
}
