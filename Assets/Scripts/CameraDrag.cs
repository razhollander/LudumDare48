using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    //void Update()
    //{
    //    //float zoom = Input.GetAxisRaw("Mouse ScrollWheel");
    //    //Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize += zoom * -5;
    //    //Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 
    //    //        Mathf.Clamp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize,3,7);

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        dragOrigin = Input.mousePosition;
    //        Camera.main.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,-10) ;
    //        return;
    //    }

    //    if (!Input.GetMouseButton(0)) return;

    //    //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //    //Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

    //    //transform.Translate(-move, Space.World);


    //}

    public float offset;
    public float speed;
    //x - min y - max
    public Vector2 minMaxXPosition;
    public Vector2 minMaxYPosition;
    private float screenWidth;
    private float screenHeight;
    private Vector3 cameraMove;
    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        cameraMove.x = transform.position.x;
        cameraMove.y = transform.position.y;
        cameraMove.z = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        //Move camera
        if ((Input.mousePosition.x > screenWidth - offset) && transform.position.x < minMaxXPosition.y)
        {
            cameraMove.x += MoveSpeed();
        }
        if ((Input.mousePosition.x < offset) && transform.position.x > minMaxXPosition.x)
        {
            cameraMove.x -= MoveSpeed();
        }
        if ((Input.mousePosition.y > screenHeight - offset) && transform.position.y < minMaxYPosition.y)
        {
            cameraMove.y += MoveSpeed();
        }
        if ((Input.mousePosition.y < offset) && transform.position.y > minMaxYPosition.x)
        {
            cameraMove.y -= MoveSpeed();
        }
        transform.position = cameraMove;
    }
    float MoveSpeed()
    {
        return speed * Time.deltaTime;
    }

}
