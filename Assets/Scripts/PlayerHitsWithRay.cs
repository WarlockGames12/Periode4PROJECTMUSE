using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerHitsWithRay : MonoBehaviour
{
    [Header("Bendables")]
    public GameObject[] Bendables;
    private Transform[] BendablesTransform;

    [Header("Dragable")]
    public GameObject[] DragAblePole;
    private Transform[] DragAbleTransform;
    public float speed = 5;

    [Header("Audio Snaps")]
    public AudioSource Snap;


    private bool isRotated0 = false;
    private bool isRotated1 = false;
    private bool isRotated2 = false;
    private bool isRotated3 = false;
    private bool isRotated4 = false;
    private bool isRotated5 = false;
    private bool isOnRightPlace = false;
    private bool isOnRightPlace1 = false;
    private float mouseYReference = 0f;
    private bool MouseisPressed = false;



    private void Start()
    {
        BendablesTransform = new Transform[Bendables.Length];
        DragAbleTransform = new Transform[DragAblePole.Length];



        for (int i = 0; i < Bendables.Length; i++)
        {
            BendablesTransform[i] = Bendables[i].transform;
        }
        for (int i = 0; i < DragAblePole.Length; i++)
        {
            DragAbleTransform[i] = DragAblePole[i].transform;
        }
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetMouseButtonDown(0) && !MouseisPressed)
        {
            MouseisPressed = true;
            mouseYReference = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0) && MouseisPressed)
        {
            MouseisPressed = false;
        }

        if (MouseisPressed) MouseDrag();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            {
              
              if (Physics.Raycast(ray, out hit))
              {
                Debug.ClearDeveloperConsole();
                if (hit.collider.CompareTag("Bendable") && !isRotated0)
                {
                    Bendables[0].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[0].transform.localEulerAngles);
                    if (Bendables[0].transform.localEulerAngles.y == 0)
                    {
                        Snap.Play();
                        Debug.Log("Pole0");
                        isRotated0 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable1") && !isRotated1)
                {
                    Bendables[1].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[1].transform.localEulerAngles);
                    if (Bendables[1].transform.localEulerAngles.y == 270 || Bendables[1].transform.localEulerAngles.y == -90)
                    {
                        Snap.Play();
                        Debug.Log("Pole1");
                        isRotated1 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable2") && !isRotated2)
                {
                    Bendables[2].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[2].transform.localEulerAngles);
                    if (Bendables[2].transform.localEulerAngles.y == 180 || Bendables[2].transform.localEulerAngles.y == -180)
                    {
                        Snap.Play();
                        Debug.Log("Pole2");
                        isRotated2 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable3") && !isRotated3)
                {
                    Bendables[3].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[3].transform.localEulerAngles);
                    if (Bendables[3].transform.localEulerAngles.y == 90 || Bendables[3].transform.localEulerAngles.y == -270)
                    {
                        Snap.Play();
                        Debug.Log("Pole3");
                        isRotated3 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable4") && !isRotated4)
                {
                    Bendables[4].transform.Rotate(0, 90,0);
                    Debug.Log(Bendables[4].transform.localEulerAngles);
                    if (Bendables[4].transform.localEulerAngles.y == 90 || Bendables[4].transform.localEulerAngles.y == -270)
                    {
                        Snap.Play();
                        Debug.Log("Pole4");
                        isRotated4 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable5") && !isRotated5)
                {
                    Bendables[5].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[5].transform.localEulerAngles);
                    if (Bendables[5].transform.localEulerAngles.y == 270 || Bendables[5].transform.localEulerAngles.y == -90)
                    {
                        Snap.Play();
                        Debug.Log("Pole5");
                        isRotated5 = true;
                    }
                }/*
                if (hit.collider.CompareTag("PoleScroll"))
                {
                    OnMouseDrag();
                }
                if (hit.collider.CompareTag("PoleScroll1"))
                {
                    
                    OnMouseDrag();
                }
                */
            }
        }
        if (isRotated0 && isRotated1 && isRotated2 && isRotated3 && isRotated4 && isRotated5 && isOnRightPlace && isOnRightPlace1)
        { 
            SceneManager.LoadScene("SampleScene");
        }
    }


    public void MouseDrag()
    {
        Debug.Log("drag");
        RaycastHit hits;
        Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);

        float direction = 0;
        if (Mathf.Abs(mouseYReference - Input.mousePosition.y) > 15f)
        {
            if(mouseYReference + Input.mousePosition.y > 0)
            {
                direction = speed * Time.deltaTime;
            }
            else
            {
                direction = -speed * Time.deltaTime;
            }
        }


        if (Physics.Raycast(rays, out hits))
        {

            if (hits.collider.CompareTag("PoleScroll") && !isOnRightPlace)
            {
                /* 
                * Only move first object hit until mouse button goes up
                */
                float range = 5f;
                Debug.Log(direction);
                DragAblePole[0].transform.localPosition = new Vector3(DragAblePole[0].transform.localPosition.x, DragAblePole[0].transform.localPosition.y + direction, DragAblePole[0].transform.localPosition.z);
                if (DragAblePole[0].transform.localPosition.y > 0.79f - range && DragAblePole[0].transform.localPosition.y < 0.79f + range)
                {
                    Snap.Play();
                    Debug.Log("Pole is dragged");
                    isOnRightPlace = true;
                    DragAblePole[0].transform.localPosition = new Vector3(DragAblePole[0].transform.localPosition.x, 0.79f, DragAblePole[0].transform.localPosition.z);
                }
            }
            if (hits.collider.CompareTag("PoleScroll1") && !isOnRightPlace1)
            {
                float range = 5f;
                Debug.Log("Drag Pole1");
                DragAblePole[1].transform.localPosition = new Vector3(DragAblePole[1].transform.localPosition.x, DragAblePole[1].transform.localPosition.y + direction, DragAblePole[1].transform.localPosition.z);
                if (DragAblePole[1].transform.localPosition.y > 0.8802491f - range && DragAblePole[1].transform.localPosition.y < 0.8802491f + range)
                {
                    Snap.Play();
                    Debug.Log("Pole is dragged");
                    isOnRightPlace1 = true;
                    DragAblePole[1].transform.localPosition = new Vector3(DragAblePole[1].transform.localPosition.x, 0.8802491f, DragAblePole[1].transform.localPosition.z);
                }
            }
        }
        

               

            
        }
       
    }



