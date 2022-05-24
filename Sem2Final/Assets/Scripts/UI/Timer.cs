using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    public float time;
    public Animator timerAnim;

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        time = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;
        time += Time.deltaTime;

        UpdateText();
    }

    void UpdateText()
    {
        text.text = "Time: " + time.ToString("0.000");
    }

    public void StopTime()
    {
        done = true;
        timerAnim.Play("FinalTime");
        if (!PlayerPrefs.HasKey("HighScore1") || time < PlayerPrefs.GetFloat("HighScore1"))
            PlayerPrefs.SetFloat("HighScore1", time);
    }
}
