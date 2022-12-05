using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public string buildingName = "Building";
    public int cost = 50;
    public int income = 10;
    public int population = 5;

    public override string ToString()
    {
        return buildingName + "\n\tCost: " + cost.ToString();

    }

}
