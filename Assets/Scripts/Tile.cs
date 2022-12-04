using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    private int _x = 0;
    private int _y = 0;

    //Constructor...
    public Tile(){

    }

    //Deconstructor...
    ~Tile(){

        Object.Destroy(this);
    }

    // Start is called before the first frame update.
    void Start(){

        //_gm = GameObject.Find("LandScape").GetComponent<TestLandScape>();
    }

    // Update is called once per frame.
    void Update(){
        

        // if(Input.GetMouseButtonDown(0) && this._isSelected){

        //     this.GetComponent<MeshRenderer>().enabled = true;
        //     this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        //     //this.GetComponent<Renderer>().enabled = false;
        // }

        // if(Input.GetMouseButtonUp(0)){

        //     this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        //     this._isSelected = false;
        //     this.GetComponent<Renderer>().enabled = false;
        // }
    }

    //If the tile is selected.
    void OnMouseOver(){

        print("hello");

        //this.GetComponent<MeshRenderer>().enabled = true;
        //this._isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    //Read more later...
    void onMouseUp(){

        print("wee");        
    }

    //If the tile not selected.
    void OnMouseExit(){

        print("err");
        //this._isSelected = false;
        //this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
    }
}
