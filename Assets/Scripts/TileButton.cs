using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{

    public GameObject tile;
    TextMeshProUGUI tooltiptext;
    RectTransform tooltip;


    void Start()
    {
        tooltip = transform.GetChild(0).GetComponent<RectTransform>();
        tooltip.localPosition = new Vector3(0, 300, 0);
        
        tooltiptext = tooltip.transform.GetComponentInChildren<TextMeshProUGUI>();

        if (tile)
        {
            BuildingScript bs;
            bs = tile.GetComponent<BuildingScript>();
            if (bs == null)
            {
                bs = tile.GetComponent<RoadScript>();
            }
            tooltiptext.text = bs.ToString();
            
        }
    }

    public void TaskOnClick()
    {
        GameObject selector = GameObject.FindGameObjectWithTag("Selector");
        if (selector)
        {
            Selection selectorScript = selector.GetComponent<Selection>();
            selectorScript.selectedBuilding = tile;
        }
        
    }
}
