using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFBM : MonoBehaviour
{
    public GameObject fbm;

    private AudioSource selectClick;
    private AudioSource deselectClick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        selectClick = GameObject.Find("selectAudio").GetComponent<AudioSource>();
        deselectClick = GameObject.Find("de-selectAudio").GetComponent<AudioSource>();
    }
    public void ToggleGameObject()
    {
        if (fbm.active == false)
        {
            fbm.SetActive(true);
            selectClick.Play();
        }
        else
        {
            fbm.SetActive(false);
            deselectClick.Play();
        }
        

    }
    public void closeFBM()
    {
        fbm.SetActive(false);
        deselectClick.Play();
    }
    public void openFBM()
    {
        fbm.SetActive(true);
        selectClick.Play();
    }
}
