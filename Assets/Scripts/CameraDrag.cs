using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    void Update()
    {
        float zoom = Input.GetAxisRaw("Mouse ScrollWheel");
        Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize += zoom * -5;
        Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 
                Mathf.Clamp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.OrthographicSize,3,7);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;       
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(-move, Space.World);

       
    }



}
