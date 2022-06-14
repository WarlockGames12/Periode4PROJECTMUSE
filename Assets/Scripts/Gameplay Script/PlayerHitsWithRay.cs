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

    [Header("Sparky for Objects: ")]
    public ShocksParticles[] ParticlesWhenDone;

    [Header("WinScreen: ")]
    public GameObject WinScreen; 

    [Header("Dragable")]
    public GameObject[] DragAblePole;
    private Transform[] DragAbleTransform;
    public float speed = 5f;

    [Header("Dont Destroy after Load")]
    public GameObject Hover;

    [Header("Audio Snaps")]
    public AudioSource Snap;
    public AudioSource SqueekySqueek;

    [Header("Animation After Winning: ")]
    public Animation Model;
    public AudioSource Win;
    public bool switchedOn = true;

    [Header("Speed for Rotation")]
    public float RotationSpeed = 500f;

    private bool isRotated0 = false;
    private bool isRotated1 = false;
    private bool isRotated2 = false;
    private bool isRotated3 = false;
    private bool isRotated4 = false;
    private bool isRotated5 = false;
    private bool isOnRightPlace = false;
    private bool isOnRightPlace1 = false;
    private bool isOnRightPlace2 = false;
    private float mouseYReference = 0f;
    private bool isDragged = false;
    private bool MouseisPressed = false;



    private void Start()
    {
        BendablesTransform = new Transform[Bendables.Length];
        DragAbleTransform = new Transform[DragAblePole.Length];

        Hover = GameObject.Find("Hover");

        WinScreen.SetActive(false);

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
                    SqueekySqueek.Play();
                    Bendables[0].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[0].transform.localEulerAngles);
                    if (Bendables[0].transform.localEulerAngles.y == 0)
                    {
                        Snap.Play();
                        Debug.Log("Pole0");
                        ParticlesWhenDone[6].ParticlesWontShock = true;
                        isRotated0 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable1") && !isRotated1)
                {
                    SqueekySqueek.Play();
                    Bendables[1].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[1].transform.localEulerAngles);
                    if (Bendables[1].transform.localEulerAngles.y == 270 || Bendables[1].transform.localEulerAngles.y == -90)
                    {
                        Snap.Play();
                        Debug.Log("Pole1");
                        ParticlesWhenDone[7].ParticlesWontShock = true;
                        isRotated1 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable2") && !isRotated2)
                {
                    SqueekySqueek.Play();
                    Bendables[2].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[2].transform.localEulerAngles);
                    if (Bendables[2].transform.localEulerAngles.y == 180 || Bendables[2].transform.localEulerAngles.y == -180)
                    {
                        Snap.Play();
                        Debug.Log("Pole2");
                        ParticlesWhenDone[8].ParticlesWontShock = true;
                        isRotated2 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable3") && !isRotated3)
                {
                    SqueekySqueek.Play();
                    Bendables[3].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[3].transform.localEulerAngles);
                    if (Bendables[3].transform.localEulerAngles.y == 90 || Bendables[3].transform.localEulerAngles.y == -270)
                    {
                        Snap.Play();
                        Debug.Log("Pole3");
                        ParticlesWhenDone[9].ParticlesWontShock = true;
                        isRotated3 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable4") && !isRotated4)
                {
                    SqueekySqueek.Play();
                    Bendables[4].transform.Rotate(0, 90,0);
                    Debug.Log(Bendables[4].transform.localEulerAngles);
                    if (Bendables[4].transform.localEulerAngles.y == 90 || Bendables[4].transform.localEulerAngles.y == -270)
                    {
                        Snap.Play();
                        Debug.Log("Pole4");
                        ParticlesWhenDone[10].ParticlesWontShock = true;
                        isRotated4 = true;
                    }
                }
                if (hit.collider.CompareTag("Bendable5") && !isRotated5)
                {
                    SqueekySqueek.Play();
                    Bendables[5].transform.Rotate(0, 90, 0);
                    Debug.Log(Bendables[5].transform.localEulerAngles);
                    if (Bendables[5].transform.localEulerAngles.y == 270 || Bendables[5].transform.localEulerAngles.y == -90)
                    {
                        Snap.Play();
                        Debug.Log("Pole5");
                        ParticlesWhenDone[11].ParticlesWontShock = true;
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
        
        if (isRotated0 && isRotated1 && isDragged)
        {
            ParticlesWhenDone[1].ParticlesWontShock = true;
            ParticlesWhenDone[5].ParticlesWontShock = true;
        }

        if (isRotated2 && isOnRightPlace1)
        {
            ParticlesWhenDone[0].ParticlesWontShock = true;
        }

        if (isRotated3 && isRotated4 && isRotated5 && isOnRightPlace && isOnRightPlace2)
        {
            ParticlesWhenDone[2].ParticlesWontShock = true;
            ParticlesWhenDone[3].ParticlesWontShock = true;
            ParticlesWhenDone[4].ParticlesWontShock = true;
        }

        if (isRotated0 && isRotated1 && isRotated2 && isRotated3 && isRotated4 && isRotated5 && isOnRightPlace && isOnRightPlace1 && isDragged && isOnRightPlace2)
        {
            StartCoroutine(Rotating(5));
        }
    }

    IEnumerator Rotating(int Rotate)
    {
        if (switchedOn && Win.isPlaying == false)
        {
            Win.Play();
            switchedOn = false;
        }
        Model.Play();
        yield return new WaitForSeconds(Rotate);
        Destroy(Hover);
        WinScreen.SetActive(true);
        Time.timeScale = 0;
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

        /*RaycastHit Rotation;
        Ray rayLit = Camera.main.ScreenPointToRay(Input.mousePosition);

        float directionYRotation = 0f;
        if (Mathf.Abs(mouseYRotationReference - Input.mousePosition.x) > 15f)
        {
            if (mouseYRotationReference + Input.mousePosition.x > 0)
            {
                directionYRotation = speeding * Time.deltaTime;
            }
            else
            {
                directionYRotation = -speeding * Time.deltaTime;
            }
        }

        if (Physics.Raycast(rayLit, out Rotation))
        {
            if (Rotation.collider.CompareTag("Bendable") && !isRotated0)
            {
                float range = 5f;
                Bendables[0].transform.Rotate(Bendables[0].transform.rotation.x, Bendables[0].transform.rotation.y + directionYRotation, Bendables[0].transform.rotation.z);
                if (Bendables[0].transform.rotation.y > 360 - range && Bendables[0].transform.rotation.y < 360 + range)
                {
                    Snap.Play();
                    isRotated0 = true;
                    Bendables[0].transform.Rotate(0, 0, 0);
                }
            }
            if (Rotation.collider.CompareTag("Bendable1") && !isRotated1)
            {
                float range = 5f;
                Bendables[1].transform.Rotate(Bendables[1].transform.rotation.x, Bendables[1].transform.rotation.y + directionYRotation, Bendables[1].transform.rotation.z);
                if (Bendables[1].transform.rotation.y > 270 - range && Bendables[1].transform.rotation.y < 270 + range)
                {
                    Snap.Play();
                    isRotated1 = true;
                }
            }
        }
        */

        if (Physics.Raycast(rays, out hits))
        { 
            if (hits.collider.CompareTag("PoleScroll") && !isOnRightPlace)
            {
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
            if (hits.collider.CompareTag("BendableScroll") && !isDragged)
            {
                float range = 5f;
                DragAblePole[2].transform.localPosition = new Vector3(DragAblePole[2].transform.localPosition.x, DragAblePole[2].transform.localPosition.y + direction, DragAblePole[2].transform.localPosition.z);
                if (DragAblePole[2].transform.localPosition.y > 22.4f - range && DragAblePole[2].transform.localPosition.y < 22.4f + range)
                {
                    Snap.Play();
                    isDragged = true;
                    DragAblePole[2].transform.localPosition = new Vector3(DragAblePole[2].transform.localPosition.x, 22.4f, 6.802f);
                }
            }
            if (hits.collider.CompareTag("PoleScroll2") && !isOnRightPlace2)
            {
                float range = 5f;
                DragAblePole[3].transform.localPosition = new Vector3(DragAblePole[3].transform.localPosition.x, DragAblePole[3].transform.localPosition.y + direction, DragAblePole[3].transform.localPosition.z);
                if (DragAblePole[3].transform.localPosition.y > 0.8802491f - range && DragAblePole[3].transform.localPosition.y < 0.8802491f + range)
                {
                    Snap.Play();
                    isOnRightPlace2 = true;
                    DragAblePole[3].transform.localPosition = new Vector3(DragAblePole[3].transform.localPosition.x, 0.8802491f, 4.930663f);
                }
            }

        }
        

               

            
        }
       
    }



