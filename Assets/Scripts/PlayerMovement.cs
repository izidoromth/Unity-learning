using Assets.Scripts;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float initialVelocity;
    public float sidewaysForce;
    public BoxCollider floorCollider;
    void Start()
    {
        rb.AddForce(0, 0, 20, ForceMode.VelocityChange);
    }

    void Update()
    {
        if(GameControl.Instance.GameState == GameState.Running)
        {
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 1, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(0, 0, 20, ForceMode.VelocityChange);
    }

    // FixedUpdate is used when working with Physics
    void FixedUpdate()
    {
        if(GameControl.Instance.GameState == GameState.Start)
        {
            GameControl.Instance.Pause(true);
        }
        else if (GameControl.Instance.GameState == GameState.Running)
        {
            if(transform.position.y <= -1)
            {
                GameControl.Instance.SetGameState(GameState.Finished);
            }

            if (transform.position.z > 820)
            {
                rb.AddForce(-rb.velocity.x * Time.fixedDeltaTime * 70, -rb.velocity.y * Time.fixedDeltaTime * 70, -rb.velocity.z * Time.fixedDeltaTime * 70, ForceMode.VelocityChange);

                GameControl.Instance.SetGameState(GameState.Finished);
            }
            else
            {
                rb.AddForce(0, 0, Time.fixedDeltaTime * initialVelocity * 0.9f, ForceMode.VelocityChange);
            }

            Debug.Log(rb.velocity);
        }
        else if (GameControl.Instance.GameState == GameState.Finished)
        {
            if ((rb.velocity == Vector3.zero || transform.position.y <= -1) && !GameControl.Instance.Paused)
                GameControl.Instance.Pause(true);
        }
    }
}
