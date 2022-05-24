using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerHitsWithRay : MonoBehaviour
{

    public GameObject[] Bendables;
    private Transform[] Bendables1;

    private bool isRotated0 = false;
    private bool isRotated1 = false;
    private bool isRotated2 = false;
    private bool isRotated3 = false;
    private bool isRotated4 = false;
    private bool isRotated5 = false;

    private void Start()
    {
        Bendables1 = new Transform[Bendables.Length]; 

        for (int i = 0; i < Bendables.Length; i++)
        {
            Bendables1[i] = Bendables[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            if (Input.GetMouseButtonDown(0))
            {
              if (Physics.Raycast(ray, out hit))
              {
                Debug.ClearDeveloperConsole();
                if (hit.collider.CompareTag("Bendable") && !isRotated0)
                {
                    Bendables[0].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[0].transform.localEulerAngles);
                    if (Bendables[0].transform.localEulerAngles.y == 0)
                    {
                        Debug.Log("Pole0");
                        isRotated0 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable1") && !isRotated1)
                {
                    Bendables[1].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[1].transform.localEulerAngles);
                    if (Bendables[1].transform.localEulerAngles.y == 270 || Bendables[1].transform.localEulerAngles.y == -90)
                    {
                        Debug.Log("Pole1");
                        isRotated1 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable2") && !isRotated2)
                {
                    Bendables[2].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[2].transform.localEulerAngles);
                    if (Bendables[2].transform.localEulerAngles.y == 180 || Bendables[2].transform.localEulerAngles.y == -180)
                    {
                        Debug.Log("Pole2");
                        isRotated2 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable3") && !isRotated3)
                {
                    Bendables[3].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[3].transform.localEulerAngles);
                    if (Bendables[3].transform.localEulerAngles.y == 90 || Bendables[3].transform.localEulerAngles.y == -270)
                    {
                        Debug.Log("Pole3");
                        isRotated3 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable4") && !isRotated4)
                {
                    Bendables[4].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[4].transform.localEulerAngles);
                    if (Bendables[4].transform.localEulerAngles.y == 90 || Bendables[4].transform.localEulerAngles.y == -270)
                    {
                        Debug.Log("Pole4");
                        isRotated4 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable5") && !isRotated5)
                {
                    Bendables[5].transform.Rotate(0, 0, 90);
                    Debug.Log(Bendables[5].transform.localEulerAngles);
                    if (Bendables[5].transform.localEulerAngles.y == 270 || Bendables[5].transform.localEulerAngles.y == -90)
                    {
                        Debug.Log("Pole5");
                        isRotated5 = true;
                    }
                }
            }
        }
        if (isRotated0 && isRotated1 && isRotated2 && isRotated3 && isRotated4 && isRotated5)
        { 
            SceneManager.LoadScene("SampleScene");
        }
    }


}
