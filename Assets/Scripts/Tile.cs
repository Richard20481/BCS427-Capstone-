using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    private LandScape _gm;
    private bool _isCorner = false;
    private bool _isEage = false;
    private bool _isSelected = false;
    private bool _isWater = false;
    private bool _isfree = true;
    private int _x = 0;
    private int _y = 0;

    //This is stupid but o well.

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

        //this.GetComponent<MeshRenderer>().enabled = true;
        //this._isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    //Read more later...
    void onMouseUp(){

        
    }

    //If the tile not selected.
    void OnMouseExit(){

        //this._isSelected = false;
        //this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
    }
}
