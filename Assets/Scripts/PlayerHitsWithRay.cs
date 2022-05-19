using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerHitsWithRay : MonoBehaviour
{

    public GameObject[] Bendables;
    public Transform[] Bendables1;

    private bool isRotated0 = false;
    private bool isRotated1 = false;
    private bool isRotated2 = false;
    private bool isRotated3 = false;
    private bool isRotated4 = false;
    private bool isRotated5 = false;

    private void Start()
    {
        Bendables1[0].transform.rotation = Bendables[0].transform.rotation;
        Bendables1[1].transform.rotation = Bendables[1].transform.rotation;
        Bendables1[2].transform.rotation = Bendables[2].transform.rotation;
        Bendables1[3].transform.rotation = Bendables[3].transform.rotation;
        Bendables1[4].transform.rotation = Bendables[4].transform.rotation;
        Bendables1[5].transform.rotation = Bendables[5].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Bendables1[0].transform.rotation.z == 0)
        {
            isRotated0 = true;
        }
        if (Bendables1[1].transform.rotation.z == -90)
        {
            isRotated1 = true;
        }
        if (Bendables1[2].transform.rotation.z == 180)
        {
            isRotated2 = true;
        }
        if (Bendables1[3].transform.rotation.z == 90)
        {
            isRotated3 = true;
        }
        if (Bendables1[4].transform.rotation.z == 90)
        {
            isRotated4 = true;
        }
        if (Bendables1[5].transform.rotation.z == -90)
        {
            isRotated5 = true;
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Bendable") && !isRotated0)
                {
                    Bendables[0].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable") && isRotated0)
                {
                    Debug.Log("Don't Rotate");
                }
                if (hit.collider.CompareTag("Bendable1"))
                {
                    Bendables[1].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable1") && isRotated1)
                {
                    Debug.Log("Don't Rotate1");
                }
                if (hit.collider.CompareTag("Bendable2"))
                {
                    Bendables[2].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable2") && isRotated2)
                {
                    Debug.Log("Don't Rotate2");
                }
                if (hit.collider.CompareTag("Bendable3"))
                {
                    Bendables[3].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable3") && isRotated3)
                {
                    Debug.Log("Don't Rotate3");
                }
                if (hit.collider.CompareTag("Bendable4"))
                {
                    Bendables[4].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable4") && isRotated4)
                {
                    Debug.Log("Don't Rotate4");
                }
                if (hit.collider.CompareTag("Bendable5"))
                {
                    Bendables[5].transform.Rotate(0, 0, 90);
                }
                else if (hit.collider.CompareTag("Bendable5") && isRotated5)
                {
                    Debug.Log("Don't Rotate5");
                }
            }
            if (isRotated0 && isRotated1 && isRotated2 && isRotated3 && isRotated4 && isRotated5)
            {
                SceneManager.LoadScene("SampleScene");
            }
            
        }
    }


}
