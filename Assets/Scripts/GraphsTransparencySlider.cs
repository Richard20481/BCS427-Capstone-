using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GraphsTransparencySlider : MonoBehaviour
{
    public float alpha = 1f;
    public GameObject UIGraphsTransparency;
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

        UIGraphsTransparency.GetComponent<CanvasGroup>().alpha = slider.value;
        




        showUITransparencyValue.text = "Graph Transparency: " + slider.value.ToString("N2"); //N2 specifies 2 decimal places without rounding
    }
}
