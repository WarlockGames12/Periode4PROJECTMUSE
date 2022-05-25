using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public Text Timer;
    public float countdown = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Reset Scene");
    }
}
