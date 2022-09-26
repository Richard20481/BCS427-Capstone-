using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour{

    public float speed = 1.0f;

    // Start is called before the first frame update.
    void Start(){
        
    }

    // Update is called once per frame.
    void Update(){

        this.transform.Rotate((Vector3.right * Time.deltaTime) * speed);
    }
}
