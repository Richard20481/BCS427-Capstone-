using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour{
    
    // Start is called before the first frame update.
    void Start(){
        
    }

    // Update is called once per frame.
    void Update(){

        var cam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(cam, out hit, 100.0f)){

            if(hit.collider.tag == "Map16"){

                //Vector3[] Hello = this.GetComponent<Mesh>().vertices;

                //this.transform.position = new Vector3((hit.point.x + 0.52f), 2.0f, (hit.point.z + 0.52f));
                //this.transform.position = new Vector3((Mathf.RoundToInt((hit.point.x + 0.5f)/2.0f)*2.0f), 2.0f, (Mathf.RoundToInt((hit.point.z + 0.5f)/2.0f)*2.0f));
                
                // Hello[0] = new Vector3(10.0f, 1.0f, 1.0f);

                this.transform.position = hit.point;
                print(hit.point);
            }
        }
    }
}
