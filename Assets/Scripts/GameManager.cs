using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject queen;
    public AntsManager antManager;
    [SerializeField]
    AnimationCurve animationCurve;
    //public ants manager
    //pubilc enemies manager
    //public food manager
    //public scene manager

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    [ContextMenu("Debug")]
    private void DebugText()
    {
        Debug.Log(animationCurve.Evaluate(0.5f));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
