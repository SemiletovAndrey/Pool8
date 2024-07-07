using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TMP_Text tMP_TextScore;


    private List<Hole> _holesList;
    private Hole[] _holes;
    void Start()
    {
        _holesList = new List<Hole>();
        _holes = FindObjectsOfType<Hole>();
        for(int i =0; i < _holes.Length; i++)
        {
            _holesList.Add(_holes[i]);
            _holesList[i].scoringBall += ScoringBall;
        }

    }

    void Update()
    {
        
    }

    private void ScoringBall(Ball ball)
    {
        score += ball.ScoreBall;
        string formattedScore = FormatScore(score);
        tMP_TextScore.text = formattedScore;
    }

    string FormatScore(int score)
    {
        string formattedScore = score.ToString("0000");
        return formattedScore;
    }
}
