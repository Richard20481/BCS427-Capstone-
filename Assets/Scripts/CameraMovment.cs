using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour{

    //Public variables.
    public float speed = 0.0f;
    public int xMin = 0;   //The lower bound limit the camera can move on the x axis.
    public int xMax = 0;   //The upper bound limit the camera can move on the x axis.
    public float zoomMax = 0.0f;
    public float zoomMin = 0.0f;
    public float steps = 0;
    public GameObject gm;

    //private variables.
    private Camera cam;

    // Start is called before the first frame update.
    void Start(){

        cam = this.GetComponent<Camera>();
        cam.orthographicSize = zoomMin;

        //cam.transform.Translate(new Vector3(0.0f, 24.0f, 0.0f));  //Adds...

        //cam.transform.position = new Vector3((gm.GetComponent<TestLandScape>().size / 4.0f), (gm.GetComponent<TestLandScape>().size / 2.0f), (gm.GetComponent<TestLandScape>().size / 4.0f));    //Sets...
        

        //Good...
        //cam.transform.position = new Vector3((gm.GetComponent<TestLandScape>().size / 4.0f), 128.0f, (gm.GetComponent<TestLandScape>().size / 4.0f));    //Sets...
    
        //cam.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));

        //Peramiter validation.
        //zoomMax = (zoomMax < 2.0f) && (zoomMax > 8.0f) ? 2.0f : zoomMax;

        steps = Mathf.Round(Mathf.Abs((zoomMax - zoomMin)/steps));
    }

    // Update is called once per frame.
    void Update(){

        //print(cam.transform.position);

        if(Input.GetKeyDown(KeyCode.R)){

            cam.transform.RotateAround(new Vector3 (0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), 90.0f);
        }  

        // print(this.transform.position);

        //If " " is pressed
        if(Input.GetKeyDown(KeyCode.Q) && (cam.orthographicSize < zoomMin)){

            cam.orthographicSize = cam.orthographicSize += steps;
        }  
        
        //If " " is pressed
        if(Input.GetKeyDown(KeyCode.E) && (cam.orthographicSize > zoomMax)){

            cam.orthographicSize = cam.orthographicSize -= steps;
        }

        //If " " is pressed
        if(Input.GetKey(KeyCode.W)){

            this.transform.Translate(Vector3.up * Time.deltaTime * (cam.orthographicSize * speed));
        }

        //If " " is pressed
        if(Input.GetKey(KeyCode.S)){

            this.transform.Translate(Vector3.down * Time.deltaTime * (cam.orthographicSize * speed));
        }

        //If " " is pressed
        if(Input.GetKey(KeyCode.A)){

            this.transform.Translate(Vector3.left * Time.deltaTime * (cam.orthographicSize * speed));
        }

        //If " " is pressed
        if(Input.GetKey(KeyCode.D)){

            this.transform.Translate(Vector3.right * Time.deltaTime * (cam.orthographicSize * speed));
        }
    }
}
