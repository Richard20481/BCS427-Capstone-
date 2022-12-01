using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFBM : MonoBehaviour
{
    public GameObject fbm;
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
        if (fbm.active == false)
        {
            fbm.SetActive(true);
        }
        else
        {
            fbm.SetActive(false);
        }
        

    }
    public void closeFBM()
    {
        fbm.SetActive(false);
    }
    public void openFBM()
    {
        fbm.SetActive(true);
    }
}
