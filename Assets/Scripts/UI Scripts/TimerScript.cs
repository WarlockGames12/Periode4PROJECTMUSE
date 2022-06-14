using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    [Header("Timer Settings:")]
    public Text Timer;
    public float countdown = 180f;
    public bool isRunning = false;

    [Header("Dont Destroy Music")]
    public GameObject DontDestroy;
    public GameObject GameOver;

    [Header("Play Rotation after Game is over")]
    public Animation Model;
    public AudioSource LoseCondition;

    void Start()
    {
        DontDestroy = GameObject.Find("Hover");
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            if (countdown <= 0f)
            {
                ResetGame();
            }
            Timer.text = Mathf.Round(countdown).ToString();
            countdown -= Time.deltaTime;
        }
    }
    public void ResetGame()
    {
        LoseCondition.Play();
        GameOver.SetActive(true);
        Model.Play();
        isRunning = true;
    }

    public void BackToMenu()
    {
        Destroy(DontDestroy);
        SceneManager.LoadScene("Start");
        print("Reset Scene");
    }
}
