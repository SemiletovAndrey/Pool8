using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour
{
    [SerializeField] private Cue cue;

    private BallControl _ballControl;

    private void Start()
    {
        cue = FindObjectOfType<Cue>();
        _ballControl = FindObjectOfType<BallControl>();
    }

    private void LateUpdate()
    {
        if (_ballControl.IsMovingBall)
        {
            CueOff();
        }
        else
        {
            CueOn();
        }
    }

    public void CueOn()
    {
        cue.gameObject.SetActive(true);
    }
    public void CueOff()
    {
        cue.gameObject.SetActive(false);
    }
}
