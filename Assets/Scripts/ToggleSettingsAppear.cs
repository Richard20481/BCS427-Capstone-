using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingsAppear : MonoBehaviour
{
    public GameObject settingsUI;
    private AudioSource selectClick;
    private AudioSource deselectClick;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        selectClick = GameObject.Find("selectAudio").GetComponent<AudioSource>();
        deselectClick = GameObject.Find("de-selectAudio").GetComponent<AudioSource>();
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
            selectClick.Play();
        }
        else
        {
            settingsUI.SetActive(false);
            deselectClick.Play();
        }
    }
}
