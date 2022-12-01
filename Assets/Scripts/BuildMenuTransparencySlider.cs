using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildMenuTransparencySlider : MonoBehaviour
{
    //GameObject[] transparencySliderGameObjects;
    public float alpha = 1f;
    public GameObject UIFirstBuildMenuTransparency;
    public GameObject UISettingsMenuTransparency;
    public GameObject UITopPanel;
    public TMPro.TextMeshProUGUI showUITransparencyValue;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void ChangeAlpha(Image img, float alphaValue)
    {
       
    }
    public void ChangeAlphaOnValueChange(Slider slider)
    {

        UIFirstBuildMenuTransparency.GetComponent<CanvasGroup>().alpha = slider.value;
        UISettingsMenuTransparency.GetComponent<CanvasGroup>().alpha = slider.value;
        UITopPanel.GetComponent<CanvasGroup>().alpha = slider.value;





        showUITransparencyValue.text = "Menu Transparency: "+ slider.value.ToString("N2"); //N2 specifies 2 decimal places without rounding
    }
    
}
