using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCreationScript : OverridableMonoBehaviour
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
    [SerializeField] float diggingDelta=0.1f;
    float time = 0.1f;
    [SerializeField] bool isSingleLine = false;
    void Start()
    {
        _lr = tunnelPrefab.GetComponent<LineRenderer>();
        holder = GameObject.FindGameObjectWithTag("TunnelHolder").transform;
        time = diggingDelta;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _flag = true;
    }

    public override void UpdateMe()
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
                if (!isSingleLine)
                {
                    AddPoint(digPoint.position);
                }
                else
                {
                    UpdateLastPoint(digPoint.position);
                }
                time = diggingDelta;
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

    public void AddPoint(Vector2 newPos)
    {
        positions.Add(newPos);
        _lr.positionCount++;
        _lr.SetPosition(_lr.positionCount - 1, newPos);
    }

    public void UpdateLastPoint(Vector2 newPos)
    {
        positions[positions.Count - 1] = newPos;
        _lr.SetPosition(_lr.positionCount - 1, newPos);
    }
}
