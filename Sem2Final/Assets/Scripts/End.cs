using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Timer timeTracker;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeTracker.StopTime();
        CutsceneManager.instance.isPlaying = true;
    }
}