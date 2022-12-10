using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public string buildingName = "Building";
    public int cost = 50;
    public int expense = 2;
    public int income = 10;
    public int population = 5;
    public int demand = 1;

    float nextSpawn = 0;

    public override string ToString()
    {
        return buildingName + "\n\tCost: " + cost.ToString() +"\n\tExpense " + expense.ToString()+"\n\tIncome " + income + "\n\tPopulation " + population.ToString();
    }

    public void Update()
    {
        if (Time.time >= nextSpawn) {
            print(buildingName + " ");
            nextSpawn = Time.time + 60.0f / (population+1);
            if(population > 0)
            {
                GameObject.FindGameObjectWithTag("Map16").GetComponentInParent<LandScape>().SpawnCar(gameObject);
            }
            GameManager.gm.addMoney(-expense);
        }
    }


}
