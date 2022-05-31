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

    [Header("Dont Destroy Music")]
    public GameObject DontDestroy;

    void Start()
    {
        DontDestroy = GameObject.Find("Hover");
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            ResetGame();
        }
        Timer.text = Mathf.Round(countdown).ToString();
        countdown -= Time.deltaTime;
    }
    public void ResetGame()
    {
        DontDestroyOnLoad(DontDestroy);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Reset Scene");
    }
}
