using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mouseOverDisplaySubtitle : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    //displays subtitle text of any game object (text mustbe first child of object that's scrolled over)

    public GameObject childTextObject;
    
    void Start()
    {
        childTextObject = transform.GetChild(0).gameObject;
        childTextObject.SetActive(false);   
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        childTextObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        childTextObject.SetActive(false);
    }

}
