using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPolePositionScript : MonoBehaviour
{
    [SerializeField] private float PoleYPosition;

    [Header("Bools: ")]
    public bool PoleScroll = false;
    public bool PoleScroll1 = false;
    public bool PoleScroll2 = false;
    public bool Bendable = false;

    public Transform GameObjectTransform;

    public float Y
    {
        get 
        {
            return PoleYPosition;
        }
    }
}
