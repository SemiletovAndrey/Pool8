using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private BallControl _ballControl;
    public event Action<Ball> scoringBall;

    private void Start()
    {
        _ballControl = FindObjectOfType<BallControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            _ballControl.PlayerBallRolling();
        }
        if(ball != null)
        {
            scoringBall?.Invoke(ball);
        }
    }
}
