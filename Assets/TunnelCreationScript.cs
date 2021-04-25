using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCreationScript : MonoBehaviour
{
    public GameObject tunnel;
    LineRenderer _lineRenderer;
    Ant ant;
    void Start()
    {
        _lineRenderer = tunnel.GetComponent<LineRenderer>();
        ant = GetComponent<Ant>();
        Instantiate(tunnel,transform.position,Quaternion.identity);
    }

    void Update()
    {
        if (ant._isMoving)
        {
            int index = 0;
            index++;
          //  _lineRenderer.positionCount;
            _lineRenderer.SetPosition(index, transform.position);
        }
    }
}
