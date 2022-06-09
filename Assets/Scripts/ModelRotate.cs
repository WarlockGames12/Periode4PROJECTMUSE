using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotate : MonoBehaviour
{

    [Header("Speed for Rotation")]
    [SerializeField] private float RotationSpeed = 5f;
    public bool isRotating = false;
    private Vector2 MousePosition;
    private Vector3 baseRotation;


    /*
    [Header("Public bools")]
    public bool FisPressed = true;
    public bool QisPressed = false;
    public bool EisPressed = false;
    public bool RisPressed = false;
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1) && isRotating)
        {
            Debug.Log("Up");
            isRotating = false;
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Down");
            if (!isRotating)
            {
                MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                baseRotation = transform.localEulerAngles;
                isRotating = true;
            }
            else
            {
                transform.localEulerAngles = baseRotation;
                Vector2 Distances = new Vector2( MousePosition.y - Input.mousePosition.y, MousePosition.x - Input.mousePosition.x);
                Distances.x *= RotationSpeed;
                Distances.y *= RotationSpeed;
                Vector3 Rotation = new Vector3(baseRotation.x + Distances.x, baseRotation.y + Distances.y,0);
                transform.localEulerAngles = Rotation;
                

                //transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
            }
        }
        
        //Bools
        /*if (FisPressed)
        {
            transform.Rotate(0, 0, 0);
        }
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
        */
    }
}
