using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingsAppear : MonoBehaviour
{
    public GameObject settingsUI;
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
        if (settingsUI.active == false)
        {
            settingsUI.SetActive(true);
        }
        else
        {
            settingsUI.SetActive(false);
        }
    }
}
