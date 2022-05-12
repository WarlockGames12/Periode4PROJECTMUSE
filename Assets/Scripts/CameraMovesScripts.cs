using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovesScripts : MonoBehaviour
{

    [Header("Positions")]
    public GameObject MainCamera;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isFront = true;
    private bool isBack = false;

    private void Update()
    {
        //KeyCode A
        if (Input.GetKeyDown(KeyCode.A) && !isRight)
        {
            isLeft = true;
            isFront = false;
            Debug.Log("A IsLeft is" + isLeft);
            GoingFrontToLeft();
        }
        if(Input.GetKeyDown(KeyCode.A) && isLeft)
        {
            isBack = true;
            isLeft = false;
            Debug.Log("A IsBack is" + isBack);
            GoingLeftToBack();
        }
        if (Input.GetKeyDown(KeyCode.A) && isBack)
        {
            isBack = false;
            isRight = true;
            Debug.Log("A IsBack is" + isBack);
            GoingBackToRight();
        }
        if (Input.GetKeyDown(KeyCode.A) && isRight)
        {
            isRight = false;
            isFront = true;
            Debug.Log("A IsLeft is" + isLeft);
            GoingRightToFront();
        }
        
        //KeyCode D
        if (Input.GetKeyDown(KeyCode.D) && !isLeft)
        {
            isRight = true;
            isFront = false;
            Debug.Log("D IsRight is" + isRight);
            GoingFrontToRight();
        }
        if (Input.GetKeyDown(KeyCode.D) && isLeft)
        {
            isLeft = false;
            isFront = true;
            Debug.Log("D IsRight is" + isRight);
            GoingLeftToFront();
        }
        if (Input.GetKeyDown(KeyCode.D) && isRight)
        {
            isBack = true;
            isLeft = false;
            Debug.Log("D IsBack is" + isBack);
            GoingRightToBack();
        }
        if (Input.GetKeyDown(KeyCode.D) && isBack)
        {
            isBack = false;
            isLeft = true;
            Debug.Log("D IsBack is" + isBack);
            GoingBackToLeft();
        }
    }

    public void GoingRightToFront()
    {
        MainCamera.GetComponent<Animator>().Play("CameraRightToFront");
    }

    public void GoingFrontToRight()
    {
        MainCamera.GetComponent<Animator>().Play("CameraRight");
    }

    public void GoingFrontToLeft()
    {
        MainCamera.GetComponent<Animator>().Play("CameraLeft");
    }

    public void GoingLeftToFront()
    {
        MainCamera.GetComponent<Animator>().Play("CameraLeftToForward");
    }

    public void GoingLeftToBack()
    {
        MainCamera.GetComponent<Animator>().Play("CameraLeftToBack");
    }

    public void GoingBackToLeft()
    {
        MainCamera.GetComponent<Animator>().Play("CameraBackToLeft");
    }

    public void GoingBackToRight()
    {
        MainCamera.GetComponent<Animator>().Play("CameraBackToRight");
    }

    public void GoingRightToBack()
    {
        MainCamera.GetComponent<Animator>().Play("CameraRightToBack");
    }
}
