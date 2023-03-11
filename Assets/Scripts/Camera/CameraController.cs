
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float height = -7f;
    public float undergroundHeight = 1f;

    public bool activateY;

    public bool cameraOn = true;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        activateY = GameManager.instance.isCameraY ? true : false;
        minX = GameManager.instance.cameraMinX;
        maxX = GameManager.instance.cameraMaxX;
        minY = GameManager.instance.cameraMinY;
        maxY = GameManager.instance.cameraMaxY;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(playerTransform.position.x, minX, maxX);
        if (activateY)
        {
            cameraPosition.y = Mathf.Clamp(playerTransform.position.y, minY, maxY);
        }
        if (cameraOn)
        {
            transform.position = cameraPosition;
        }
        
    }

    public void SetCamera(bool underground)
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = underground ? undergroundHeight : height;
        transform.position = cameraPosition;
    }
}
