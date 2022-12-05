using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIStats : MonoBehaviour
{
    bool status = true;
    GameObject[] UIStatImages;
    // Start is called before the first frame update
    void Start()
    {
        UIStatImages = GameObject.FindGameObjectsWithTag("UIStatImage");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleUIStatImages()
    {
        foreach (GameObject go in UIStatImages)
        {
            if(status == true)
            {
                go.SetActive(false);
            }
            if(status == false)
            {
                go.gameObject.SetActive(true);
            }
        }
        if(status == true)
        {
            status = false;
        }
        else
        {
            status = true;
        }
    }
}
