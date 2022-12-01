using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSwitch : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchAppear()
    {
        if (switch1.active == true)
        {
            switch1.SetActive(false);
            switch2.SetActive(true);
        }
        else if (switch2.active == true)
        {
            switch2.SetActive(false);
            switch1.SetActive(true);
        }
    }
    public void showSwitch1Not2()
    {
        switch1.SetActive(true);
        switch2.SetActive(false);
    }
    public void showSwitch2Not1()
    {
        switch2.SetActive(true);
        switch1.SetActive(false);
    }
    public void showSwitch1()
    {
        switch1.SetActive(true);
    }
    public void showSwitch2()
    {
        switch2.SetActive(true);
    }
    public void ifNoneShow()
    {
        if((switch1.active == false) && (switch2.active == false))
        {
            switch1.active = true;
        }
        else if (switch1.active == true || switch2.active == true)
        {
            switch1.SetActive(false);
            switch2.SetActive(false);
        }
    }
}
