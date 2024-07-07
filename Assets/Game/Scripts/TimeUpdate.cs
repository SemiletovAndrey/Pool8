using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text tMP_Text;

    private void Update()
    {
        float timeElapsed = Time.timeSinceLevelLoad;
        string formattedTime = FormatTime(timeElapsed);
        tMP_Text.text = formattedTime;
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
    }
}
