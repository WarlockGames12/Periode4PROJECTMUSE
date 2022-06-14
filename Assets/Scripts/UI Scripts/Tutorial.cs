using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [Header("Tutorial: ")]
    public GameObject Tutorials;
    

    // Start is called before the first frame update
    void Start()
    {
        Tutorials.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Tutorials.SetActive(false);
        Time.timeScale = 1;
    }
}
