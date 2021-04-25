using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCreationScript : MonoBehaviour
{
    public GameObject tunnelPrefab;
    public GameObject currentLine;
    LineRenderer _lr;
    Ant ant;
    bool _flag;
    Transform[] points;
    List<Vector2> positions;
    void Start()
    {
        _lr = tunnelPrefab.GetComponent<LineRenderer>();
        ant = GetComponent<Ant>();
        Instantiate(tunnelPrefab, transform.position,Quaternion.identity);
   
    }

    void Update()
    {
        if (ant._isMoving && _flag)
        {
            CreateLine();
            _flag = false;
        }

        if (ant._isMoving && _flag == false)
        {
            UpdateLine(transform.position);
        }
    }

    public void CreateLine()
    {
        currentLine = Instantiate(tunnelPrefab, Vector2.zero, Quaternion.identity) ;
        _lr = currentLine.GetComponent<LineRenderer>();
        positions.Clear();
        positions.Add(transform.position);
        positions.Add(transform.position);
        _lr.SetPosition(0,positions[0]);
        _lr.SetPosition(1,positions[1]);
    }

    public void UpdateLine(Vector2 newPos)
    {
        //positions.Add(newPos);
        //_lr.positionCount++;
        //_lr.SetPosition(_lr.positionCount - 1 ,newPos);
    }
}
