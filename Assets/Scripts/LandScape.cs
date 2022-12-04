using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
/**
 * Sizes the map can be.
 */
enum landScapeSizes{

    LS_SIZE_S = 0x10,
    LS_SIZE_M = 0x20,
    LS_SIZE_L = 0x40,
};

public class LandScape : MonoBehaviour{

    /**
     * Public Attributes.
     */
    public GameObject[,] Tiles;
    public int size;
    public byte height;

    /**
     * Private Attributes.
     */
    private GameObject _map;
    private int _TilesSize = 0x00;
    public int SelectedX = 0x00;
    public int SelectedZ = 0x00;

    [HideInInspector]
    public GameObject gm_16;

    private int GenTerain(){

        /**
         * Varifys the map size is withing range. 
         */
        switch(this.size){

            /**
             * Generation Terrain with no perlin noise being applyed.
             */
            case ((int)landScapeSizes.LS_SIZE_S):

                _map = Instantiate(this.gm_16, this.transform);
                this._TilesSize = 0x08;
                break;

            case ((int)landScapeSizes.LS_SIZE_M):

                break;

            case ((int)landScapeSizes.LS_SIZE_L):

                break;

            default:

                Debug.LogWarning("Invalid Generation Terrain size, failed to generation!");
                return -1;
        }

        /**
         * Gets the terrain's mesh vertices.
         */
        Vector3[] Hello = this._map.GetComponent<MeshFilter>().mesh.vertices;
        float tmp = 1.0f;

        /**
         * Applys a perlin noise matrix transfrom to the terrain mesh.
         */
        for(int i = 0; i < Hello.Length; i++){
           
            if (Hello[i].y > -0.5f){

                tmp = (Mathf.PerlinNoise(Hello[i].x/16.0f, Hello[i].z/16.0f) * this.height);
                Hello[i] = new Vector3(Mathf.Round(Hello[i].x), Mathf.Round(tmp), Mathf.Round(Hello[i].z));
            }
        }
        
        /**
         * Sets the mesh changes.
         */
        this._map.GetComponent<MeshFilter>().mesh.vertices = Hello;
        this._map.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        this._map.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        this._map.GetComponent<MeshCollider>().sharedMesh = this._map.GetComponent<MeshFilter>().mesh;

        return 0;
    }

    // Deprecated... 
    // private void OnDrawGizmos(){

    //     Gizmos.color = Color.black;
    //     for (int i = 0; i < Hello.Length; i++)
    //     {
    //         Gizmos.DrawSphere(Hello[i], 0.1f);
    //     }
    // }

    // Deprecated... 
    // public float GetPositionHeight(float x, float z){

    //     int x_index = (int)(Mathf.Abs(15 - x)  / 2.0f);
    //     int z_index = (int)(Mathf.Abs(15 - z)  / 2.0f);
    //     //print(x_index.ToString() + ", " + z_index.ToString());
    //     Vector3[] verts = this._map.GetComponent<MeshFilter>().mesh.vertices;

    //     Vector3 a = this._map.transform.TransformPoint(verts[(x_index + z_index * 17) + 17]) ; //a
    //     Vector3 b = this._map.transform.TransformPoint(verts[(x_index + z_index * 17) + 18]); //b
    //     Vector3 c = this._map.transform.TransformPoint(verts[(x_index + z_index * 17) + 1]);  //c
    //     Vector3 d = this._map.transform.TransformPoint(verts[(x_index + z_index * 17) + 0]);  //d
    //     Vector3 e = new Vector3(x, 0, z);

    //     float qa = (d.z - e.z) / (d.z - a.z) * a.y + (e.z - a.z) / (d.z - a.z) * d.y;
    //     float qb = (c.z - e.z) / (c.z - b.z) * b.y + (e.z - b.z) / (c.z - b.z) * c.y;
    //     float y = (b.x - e.x) / (b.x - a.x) * qa + (e.x - a.x) / (b.x - a.x) * qb;

    //     return y;
    // }

    public Vector3[] GetTileVerts(float x, float z){

        int x_index = (int)(Mathf.Abs(15 - x) / 2.0f);
        int z_index = (int)(Mathf.Abs(15 - z) / 2.0f);
        x_index = Mathf.Clamp(x_index, 0, 15);
        z_index = Mathf.Clamp(z_index, 0, 15);

        //print(x_index.ToString() + ", " + z_index.ToString());
        Vector3[] verts = this._map.GetComponent<MeshFilter>().mesh.vertices;

        int start_ind = x_index + z_index * 17;
        Vector3 a = this._map.transform.TransformPoint(verts[start_ind + 0]); //a
        Vector3 b = this._map.transform.TransformPoint(verts[start_ind + 1]); //b
        Vector3 c = this._map.transform.TransformPoint(verts[start_ind + 17]);  //c
        Vector3 d = this._map.transform.TransformPoint(verts[start_ind + 18]);  //d
        
        return new Vector3[] {a,b,c,d};
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
