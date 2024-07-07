using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int scoreBall;
    public int Score {  get { return scoreBall; } }
}
