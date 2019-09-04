using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float timer = 120;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        timerText.text = "Time Remaining: " + timer.ToString("F2");
    }
}
