using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler
{

    [Header("ButtonHover Audio: ")]
    public AudioSource ButtonHover;

    public void OnPointerEnter(PointerEventData ped)
    {
        ButtonHover.Play();
    }
}
