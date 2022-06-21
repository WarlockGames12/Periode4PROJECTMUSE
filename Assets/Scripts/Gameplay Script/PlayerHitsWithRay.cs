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
    public GameObject[] TelevisionScreens;

    [Header("WinScherm")]
    public TimerScript isRunning;
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

    private Transform currentSelected;

    public FinalPolePositionScript[] PoleScrolls;

    private void Start()
    {
        BendablesTransform = new Transform[Bendables.Length];
        DragAbleTransform = new Transform[DragAblePole.Length];

        Hover = GameObject.Find("Hover");
        isRunning.isRunning = false;
        WinScreen.SetActive(false);

        for (int i = 0; i < TelevisionScreens.Length; i++)
        {
            TelevisionScreens[i].SetActive(false);
        }

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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !MouseisPressed)
        {
            MouseisPressed = true;
            mouseYReference = Input.mousePosition.y;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("HitSomething");
                currentSelected = hit.transform;
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
                    Bendables[4].transform.Rotate(0, 90, 0);
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
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && MouseisPressed)
        {
            MouseisPressed = false;
            currentSelected = null;
        }

        if (MouseisPressed) MouseDrag();
        
        if (isRotated0 && isRotated1 && isDragged)
        {
            ParticlesWhenDone[1].ParticlesWontShock = true;
            ParticlesWhenDone[5].ParticlesWontShock = true;
            TelevisionScreens[1].SetActive(true);
            TelevisionScreens[4].SetActive(true);
        }

        if (isRotated2 && isOnRightPlace1)
        {
            ParticlesWhenDone[0].ParticlesWontShock = true;
            TelevisionScreens[0].SetActive(true);
        }

        if (isRotated3 && isRotated4 && isRotated5 && isOnRightPlace && isOnRightPlace2)
        {
            ParticlesWhenDone[2].ParticlesWontShock = true;
            ParticlesWhenDone[3].ParticlesWontShock = true;
            ParticlesWhenDone[4].ParticlesWontShock = true;
            TelevisionScreens[2].SetActive(true);
            TelevisionScreens[3].SetActive(true);
            TelevisionScreens[5].SetActive(true);
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
        isRunning.isRunning = true;
        WinScreen.SetActive(true);
        yield return new WaitForSeconds(Rotate);
    }

    public void MouseDrag()
    {
        if (currentSelected == null)
        {
            return;
        }
        Debug.Log("drag");
        //RaycastHit hits;
        //Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);


        float direction = 0;
        if (Mathf.Abs(mouseYReference - Input.mousePosition.y) > 15f)
        {
            if (mouseYReference + Input.mousePosition.y > 0)
            {
                direction = speed * Time.deltaTime;
            }
            else
            {
                direction = -speed * Time.deltaTime;
            }
        }

        float range = 5f;
        float YReference = currentSelected.GetComponent<FinalPolePositionScript>().Y;
        Debug.Log(direction);
        currentSelected.localPosition = new Vector3(currentSelected.localPosition.x, currentSelected.localPosition.y + direction, currentSelected.localPosition.z);
        if (PoleScrolls[0].GameObjectTransform.localPosition.y > YReference - range && PoleScrolls[0].GameObjectTransform.localPosition.y < YReference + range && PoleScrolls[0].PoleScroll)
        {
            Snap.Play();
            Debug.Log("Pole is dragged");
            isOnRightPlace = true;
            PoleScrolls[0].GameObjectTransform.localPosition = new Vector3(PoleScrolls[0].GameObjectTransform.localPosition.x, YReference, PoleScrolls[0].GameObjectTransform.localPosition.z);
        }
        if (PoleScrolls[1].GameObjectTransform.localPosition.y > YReference - range && PoleScrolls[1].GameObjectTransform.localPosition.y < YReference + range && PoleScrolls[1].PoleScroll1)
        {
            Snap.Play();
            Debug.Log("Pole is dragged");
            isOnRightPlace1 = true;
            PoleScrolls[1].GameObjectTransform.localPosition = new Vector3(PoleScrolls[1].GameObjectTransform.localPosition.x, YReference, PoleScrolls[1].GameObjectTransform.localPosition.z);
        }
        if (PoleScrolls[2].GameObjectTransform.localPosition.y > YReference - range && PoleScrolls[2].GameObjectTransform.localPosition.y < YReference + range && PoleScrolls[2].PoleScroll2)
        {
            Snap.Play();
            Debug.Log("Pole is dragged");
            isOnRightPlace2 = true;
            PoleScrolls[2].GameObjectTransform.localPosition = new Vector3(PoleScrolls[2].GameObjectTransform.localPosition.x, YReference, PoleScrolls[2].GameObjectTransform.localPosition.z);
        }
        if (PoleScrolls[3].GameObjectTransform.localPosition.y > YReference - range && PoleScrolls[3].GameObjectTransform.localPosition.y < YReference + range && PoleScrolls[3].Bendable)
        {
            Snap.Play();
            Debug.Log("Pole is dragged");
            isDragged = true;
            PoleScrolls[3].GameObjectTransform.localPosition = new Vector3(PoleScrolls[3].GameObjectTransform.localPosition.x, YReference, PoleScrolls[3].GameObjectTransform.localPosition.z);
        }
    }
        


public void RestartLevel()
{
SceneManager.LoadScene("SampleScene");
}

   public void BacktoMenu()
   { 
      SceneManager.LoadScene("Start");
      Destroy(Hover);
   }
}



