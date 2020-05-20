using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 initPos;
    Vector3 initRot;

    private bool _reseting;
    public bool Reseting
    {
        get { return _reseting; }
        set { _reseting = value; }
    }

    public void Reset()
    {
        transform.position = initPos;
        transform.eulerAngles = initRot;
        rb.velocity = Vector3.zero;

        Reseting = false;
    }

    void Start()
    {
        initPos = transform.position;
        initRot = transform.eulerAngles;        
    }

    // Update is called once per frame
    void Update()
    {  
        if(GameControl.Instance.GameState != GameState.Finished && Reseting)
        {
            Reset();

            Reseting = false;
        }
    }
}
