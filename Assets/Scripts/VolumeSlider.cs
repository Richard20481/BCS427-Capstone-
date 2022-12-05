using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeSlider : MonoBehaviour
{
   
    public GameObject[] backgroundAudio;
    public GameObject selectClick;
    public GameObject deselectClick;
    public TMPro.TextMeshProUGUI showUITransparencyValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {

        backgroundAudio = GameObject.FindGameObjectsWithTag("backgroundAudio");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeAlphaOnValueChange(Slider slider)
    {
        
        foreach (GameObject go in backgroundAudio)
        {
            go.GetComponent<AudioSource>().volume = slider.value;
        }
       
      
        showUITransparencyValue.text = "Ambient Music Volume: " + slider.value.ToString("N2"); //N2 specifies 2 decimal places without rounding
    }
    private void playSelectClick()
    {
        selectClick.GetComponent<AudioSource>().Play();
    }
    private void playDeselectClick()
    {
        deselectClick.GetComponent<AudioSource>().Play();
    }
}
