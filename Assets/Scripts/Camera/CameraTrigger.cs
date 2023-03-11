using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject mainCamera;
    public float setMaxY;
    public float setMinY;
    public float setMinX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (setMaxY != 0)
            {
                mainCamera.GetComponent<CameraController>().maxY = setMaxY;
                GameManager.instance.cameraMaxY = setMaxY;
            }
            if (setMinX != 0)
            {
                mainCamera.GetComponent<CameraController>().minX = setMinX;
                GameManager.instance.cameraMinX = setMinX;
            }
            if (setMinY != 0)
            {
                mainCamera.GetComponent<CameraController>().minY = setMinY;
                GameManager.instance.cameraMinY = setMinY;
            }
        }
    }
}
