using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCreationScript : MonoBehaviour
{
    public GameObject tunnelPrefab;
    public GameObject currentLine;
    [SerializeField] float tunnelSize = 0.5f;
    LineRenderer _lr;
    Ant ant;
    [SerializeField]bool _flag = true;
    Transform[] points;
    [SerializeField]List<Vector2> positions;
    Transform holder;
    public bool dig = false;
    public Transform digPoint;
    [SerializeField]float time = 0.1f;
    void Start()
    {
        _lr = tunnelPrefab.GetComponent<LineRenderer>();
        holder = GameObject.FindGameObjectWithTag("TunnelHolder").transform;
    }

    private void OnDisable()
    {
        _flag = true;
    }

    void Update()
    {
        if (dig && _flag)
        {
            _flag = false;
            CreateLine();
        }

        if (dig && _flag == false)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                UpdateLine(digPoint.position);
                time = 0.1f;
            }
        }
    }

    public void CreateLine()
    {
        currentLine = Instantiate(tunnelPrefab, Vector2.zero, Quaternion.identity,holder) ;
        _lr = currentLine.GetComponent<LineRenderer>();
        _lr.widthMultiplier = tunnelSize;
        positions.Clear();
        positions.Add(transform.position);
        positions.Add(transform.position);
        _lr.SetPosition(0,positions[0]);
        _lr.SetPosition(1,positions[1]);
    }

    public void UpdateLine(Vector2 newPos)
    {
        positions.Add(newPos);
        _lr.positionCount++;
        _lr.SetPosition(_lr.positionCount - 1, newPos);
    }
}
