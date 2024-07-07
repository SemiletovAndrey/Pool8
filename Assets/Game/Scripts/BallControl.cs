using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallControl : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> balls = new List<Rigidbody>();
    
    public bool IsMovingBall { get; private set; }

    private Hole[] holes;
    private Ball[] _ballsArray;

    void Start()
    {
        IsMovingBall = false;
        _ballsArray = FindObjectsOfType<Ball>();
        foreach (Ball ball in _ballsArray)
        {
            balls.Add(ball.gameObject.GetComponent<Rigidbody>());
        }

        holes = FindObjectsOfType<Hole>();
        for(int i = 0; i < holes.Length; i++)
        {
            holes[i].scoringBall += RollingBall;
        }
    }

    void Update()
    {
        IsMovingBall = CheckSpeedBalls(balls);
    }

    private bool CheckSpeedBalls(List<Rigidbody> balls)
    {
        Vector3 minSpeedVelocity = Vector3.zero;
        foreach (Rigidbody ball in balls)
        {
            if (ball.velocity != minSpeedVelocity)
            {
                return true;
            }
            
        }
        return false;
    }
    public void RollingBall(Ball ball)
    {
        Rigidbody ballRb = ball.gameObject.GetComponent<Rigidbody>();
        balls.Remove(ballRb);
        Destroy(ball.gameObject, 0.05f);
    }

    public void PlayerBallRolling()
    {
        SceneManager.LoadScene(0);
    }
}
