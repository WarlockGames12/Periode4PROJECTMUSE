using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    [Header("Dont Destroy after button clicked")]
    public GameObject DontDestroy;

    public void StartLevel()
    {
        DontDestroyOnLoad(DontDestroy);
        SceneManager.LoadScene("SampleScene");
    }

}
