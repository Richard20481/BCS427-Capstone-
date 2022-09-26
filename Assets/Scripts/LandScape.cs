using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum landScapeSizes{

    LS_SIZE_S = 0x10,
    LS_SIZE_M = 0x20,
    LS_SIZE_L = 0x40,
};
    
public class LandScape : MonoBehaviour{

    //Google more about refferances types???
    public float height = 1.0f;
    private GameObject _map;
    public GameObject gm;
    public int size;

    public GameObject test;

    private Vector3[] Hello;

    //Constructor...
    LandScape(int size, GameObject gm){

    }

    //Deconstructor...
    ~LandScape(){

    }

    //Generation Terrain...(Alpha Build!!!)
    //Fixed poor perfoemence...
    private int GenTerain(){

        print("Generating Terrain...");

        //Varifys the map size is withing range.
        switch(this.size){

            case ((int)landScapeSizes.LS_SIZE_S):

                //Generation Terrain with no perlin noise being applyed...
                _map = Instantiate(gm, new Vector3(-1.0f, 0.5f, -1.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f), this.transform);
                break;

            case ((int)landScapeSizes.LS_SIZE_M):

                break;

            case ((int)landScapeSizes.LS_SIZE_L):

                break;

            default:

                Debug.LogWarning("Invalid Generation Terrain size, failed to generation!");
                return -1;
        }

        //Generation Terrain perlin noise...
        //Also the Y and Z axis are switched!!!
        Hello = this._map.GetComponent<MeshFilter>().mesh.vertices;

        for(int i = 0; i < Hello.Length; i++){

            if(Hello[i].z == 0.0f){

                Hello[i] += new Vector3(0.0f, 0.0f, Random.Range(1.0f, 2.0f) * height);
            }
        }

        //Sets the mesh changes.
        this._map.GetComponent<MeshFilter>().mesh.vertices = Hello;
        this._map.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();

        return 0;
    }   

    //Start is called before the first frame update.
    void Start(){

        //Terminal output...
        print("Landscape Script Version 7.0");
        this.GenTerain();
    }

    //Update is called once per frame.
    void Update(){

    }
}
