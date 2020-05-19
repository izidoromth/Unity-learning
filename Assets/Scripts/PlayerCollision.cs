using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCollision : MonoBehaviour
{
    public ObstacleBehaviour obstacleHit;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            GameControl.Instance.SetGameState(GameState.Finished);

            collision.gameObject.GetComponent<ObstacleBehaviour>().Reseting = true;
        }
    }
}
