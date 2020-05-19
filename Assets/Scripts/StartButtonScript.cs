using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public PlayerMovement player;
    public ObstacleBehaviour obstacleHit;
    public GameObject button;
    public Score scoreManager;
    public void Start_Tapped()
    {
        button.SetActive(false);

        if (GameControl.Instance.GameState == GameState.Start)
        {
            GameControl.Instance.SetGameState(GameState.Running);
        }
        else if (GameControl.Instance.GameState == GameState.Finished)
        {
            player.Reset();

            scoreManager.Reset();

            GameControl.Instance.SetGameState(GameState.Running);            
        }
    }

    private void Update()
    {
        if (GameControl.Instance.GameState == GameState.Finished)
        {
            if (player.rb.velocity == Vector3.zero || player.transform.position.y <= -1)
                button.SetActive(true);
        }
      
    }
}
