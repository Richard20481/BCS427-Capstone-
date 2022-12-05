using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleAppear : MonoBehaviour
{
    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleGameObject()
    {
        if (ob.active == false)
        {
            ob.SetActive(true);
        }
        else
        {
            ob.SetActive(false);
        }
        //print("click");
        
    }
    public void setActiveFalse()
    {
        ob.SetActive(false);
    }
    public void setActiveTrue()
    {
        ob.SetActive(true);
    }
}
