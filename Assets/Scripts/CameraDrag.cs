using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;

    public float offset;
    public float speed;
    //x - min y - max
    public Vector2 minMaxXPosition;
    public Vector2 minMaxYPosition;
    private float screenWidth;
    private float screenHeight;
    public Vector3 cameraMove;
    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        cameraMove.x = transform.position.x;
        cameraMove.y = transform.position.y;
        cameraMove.z = transform.position.z;
    }
    void Update()
    {
        float zoom = Input.GetAxisRaw("Mouse ScrollWheel");
        Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize += zoom * -5;
        Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize =
            Mathf.Clamp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize, 4, 7);

        //Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Camera.main.transform.position = Camera.main.transform.position + (dir * 0.5f);
    }

    public void Up() // set by ui button
    {
        transform.position = Vector3.zero;
    }
}


