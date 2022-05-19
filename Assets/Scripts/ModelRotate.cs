using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotate : MonoBehaviour
{

    [Header("Speed for Rotation")]
    public float RotationSpeed = 500f;

    [Header("Public bools")]
    public bool QisPressed = false;
    public bool EisPressed = false;
    public bool FisPressed = false;
    public bool RisPressed = true;

    // Update is called once per frame
    void Update()
    {

        //Bools
        if (RisPressed)
        {
            transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
        }
        if (QisPressed)
        {
            transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, 0, Space.World);
        }
        if (EisPressed)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
        }
        if (FisPressed)
        {
            transform.Rotate(0, 0, 0);
        }

        //Pressed
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            QisPressed = true;
            EisPressed = false;
            RisPressed = false;
            FisPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            QisPressed = false;
            EisPressed = true;
            RisPressed = false;
            FisPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            QisPressed = false;
            EisPressed = false;
            RisPressed = true;
            FisPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            QisPressed = false;
            EisPressed = false;
            RisPressed = false;
            FisPressed = true;
        }
    }
}
