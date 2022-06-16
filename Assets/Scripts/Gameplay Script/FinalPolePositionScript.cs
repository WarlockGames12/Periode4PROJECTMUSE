using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPolePositionScript : MonoBehaviour
{
    [SerializeField] private float PoleYPosition;

    public float Y
    {
        get 
        {
            return PoleYPosition;
        }
    }
}
