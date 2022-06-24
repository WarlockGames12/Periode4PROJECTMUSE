using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [Header("Tutorial: ")]
    public GameObject Tutorials;
    public GameObject Timers;
    

    // Start is called before the first frame update
    void Start()
    {
        Timers.SetActive(false);
        Tutorials.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Timers.SetActive(true);
        Tutorials.SetActive(false);
        Time.timeScale = 1;
    }
}
