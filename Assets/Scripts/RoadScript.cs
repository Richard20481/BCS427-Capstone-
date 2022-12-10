using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadScript: BuildingScript
{
    public GameObject car;

    public RoadScript()
    {
        this.cost = 10;
        
    }

    Vector3[] originalMesh;
    private void Start()
    {
        
    }
    public void UpdateRoad(bool[] direction)
    {
        for(int i = 0; i < direction.Length; i++)
        {
            transform.GetChild(i).gameObject.SetActive(!direction[i]);
        }
    }
    public void SpawnCar(float value, Vector3 dest)
    {
        GameObject newcar = Instantiate(car, transform.position+(Vector3.up*1.5f), Quaternion.identity);
        newcar.GetComponent<CarScript>().SetDest(dest,value);
    }
    public void UpdateMesh(GameObject land)
    {
        
        FitToTerrain[] children = GetComponentsInChildren<FitToTerrain>();
        print(children.Length);
        foreach (FitToTerrain obj in children)
        {
            obj.UpdateMesh(land);
        }
    }
}
