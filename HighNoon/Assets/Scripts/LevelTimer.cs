using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float timer = 90;
    public Text timerText;


    public Transform player1;
    public Transform player2;
    public Transform target;


    public Camera cam;


    [SerializeField] HatHolder holderOfTheHats;
    [SerializeField] HatHolder holderOfTheHats2;

    public AudioClip gameOverSound;
    public AudioSource source;

    bool gameOver = true;


    private void Start()
    {
        source.clip = gameOverSound;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        timerText.text = "Time Remaining: " + timer.ToString("F2");

        if (timer <= 0) {
            if (gameOver == true)
            {
                source.PlayOneShot(gameOverSound, 1.5f);
                gameOver = false;
            }
            //timer = 0;
            //Time.timeScale = 0;
            if (holderOfTheHats.HatList.Count >= holderOfTheHats2.HatList.Count)
            {
                timerText.color = Color.red;
                timerText.text = "Red Player Wins, \n Press C to Continue";
                target = player1;
            }
            else {
                timerText.color = Color.blue;
                timerText.text = "Blue Player Wins, \n Press C to Continue";
                target = player2;
             }
            cam.transform.position = (target.transform.position - new Vector3(0.0f, 0.0f, 2.0f));
            cam.orthographicSize = 5;

            if (Input.GetKeyDown(KeyCode.C)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
