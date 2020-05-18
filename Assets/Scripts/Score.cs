using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text score;

    // Update is called once per frame
    void Update()
    {
        score.text = player.position.z.ToString("0");

        if (GameControl.Instance.GameState == GameState.Finished)
        {
            score.transform.position = new Vector3(score.transform.position.x, 270, score.transform.position.z);
            score.transform.localScale = new Vector3(0.6f, 0.6f, 0);
        }
    }

    public void Reset()
    {
        score.transform.position = new Vector3(score.transform.position.x, 380.0f, 0);
        score.transform.localScale = new Vector3(0.2f, 0.2f, 0);
        score.text = String.Empty;
    }
}
