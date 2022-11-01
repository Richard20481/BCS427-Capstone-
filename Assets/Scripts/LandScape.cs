using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum landScapeSizes{

    LS_SIZE_S = 0x10,
    LS_SIZE_M = 0x20,
    LS_SIZE_L = 0x40,
};

public class LandScape : MonoBehaviour{

    // //Google more about refferances types???
    // public float height = 1.0f;
    private GameObject _map;
    public int size;
    public byte height;
    private Vector3[] Hello;

    public GameObject gm_16;

    private int GenTerain(){

        print("Generating Terrain...");

        //Varifys the map size is withing range.
        switch(this.size){

            case ((int)landScapeSizes.LS_SIZE_S):

                //Generation Terrain with no perlin noise being applyed...
                _map = Instantiate(this.gm_16, new Vector3(-1.0f, 0.5f, -1.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f), this.transform);
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
        float tmp = 1.0f;
        
        /**
         *
         */
        for(int i = 0; i < Hello.Length; i++){

            if(Hello[i].z > 0.0f){

                tmp = (Mathf.PerlinNoise(Hello[i].x/16.0f, Hello[i].y/16.0f) * this.height);
                tmp = Mathf.Round(tmp);

                Hello[i] += new Vector3(0.0f, 0.0f, tmp);
            }
        }

        /**
         * Sets the mesh changes.
         */
        this._map.GetComponent<MeshFilter>().mesh.vertices = Hello;

        this._map.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        this._map.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        this._map.GetComponent<MeshCollider>().sharedMesh = this._map.GetComponent<MeshFilter>().mesh;

        /**
         * Fixing normals. (not mine credit to robertbu).
         * https://answers.unity.com/questions/798510/flat-shading.html
         */
        // Vector3[] oldVerts = this._map.GetComponent<MeshFilter>().mesh.vertices;
        // int[] triangles = this._map.GetComponent<MeshFilter>().mesh.triangles;
        // Vector3[] vertices = new Vector3[triangles.Length];


        //Vector2[] uvs = new Vector2[triangles.Length];
        //uvs = this._map.GetComponent<MeshFilter>().mesh.uv;

        // for (int i = 0; i < triangles.Length; i++) {

        //     vertices[i] = oldVerts[triangles[i]];
        //     triangles[i] = i;
        // }

        // this._map.GetComponent<MeshFilter>().mesh.vertices = vertices;
        // this._map.GetComponent<MeshFilter>().mesh.triangles = triangles;

        // this._map.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        // this._map.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        // /**
        //  * Fixes the uv's
        //  */
        // Vector2[] uvs = this._map.GetComponent<MeshFilter>().mesh.uv;

        // for (int i = 0; i < uvs.Length; i++){

        //     //uvs[i] = new Vector2(vertices[i].x / 32.0f, vertices[i].z/32.0f);
        //     //uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        //     uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        // }

        //this._map.GetComponent<MeshFilter>().mesh.uv = uvs;
        return 0;
    }   

    /**
     * Start is called before the first frame update.
     */
    void Start(){

        //Terminal output...
        print("Landscape Script Version 7.0");
        this.GenTerain();
    }

    /**
     * Update is called once per frame.
     */
    void Update(){

    }
}
