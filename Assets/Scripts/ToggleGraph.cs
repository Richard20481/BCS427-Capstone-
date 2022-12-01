using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGraph : MonoBehaviour
{
    public GameObject obGraph;
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
        if (obGraph.active == false)
        {
            obGraph.SetActive(true);
        }
        else
        {
            obGraph.SetActive(false);
        }
        //print("click");

    }
}
