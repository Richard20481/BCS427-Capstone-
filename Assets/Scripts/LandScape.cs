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

    [HideInInspector]
    public Vector3[] Hello;

    public GameObject gm_16;

    private int GenTerain(){

        print("Generating Terrain...");

        //Varifys the map size is withing range.
        switch(this.size){

            case ((int)landScapeSizes.LS_SIZE_S):

                //Generation Terrain with no perlin noise being applyed...
                _map = Instantiate(this.gm_16, this.transform);
                // _map.transform.position = new Vector3(-1.0f, 0.5f, -1.0f);
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
        print(Hello.Length);
        for (int i = 0; i < Hello.Length; i++){
           
            if (Hello[i].y > -.5f){
                
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < Hello.Length; i++)
        {
            Gizmos.DrawSphere(Hello[i], 0.1f);
        }
    }

    public float GetPositionHeight(float x, float z)
    {
        int x_index = (int)(Mathf.Abs(14 - x) / 2);
        int z_index = (int)(Mathf.Abs(14 - z) / 2);

        Vector3[] verts = this._map.GetComponent<MeshFilter>().mesh.vertices;

        Vector3 a =  this._map.transform.TransformPoint(verts[(x_index + z_index * 16) + 17]) ; //a
        Vector3 b = this._map.transform.TransformPoint(verts[(x_index + z_index * 16) + 18]); //b
        Vector3 c = this._map.transform.TransformPoint(verts[(x_index + z_index * 16) + 1]);  //c
        Vector3 d = this._map.transform.TransformPoint(verts[(x_index + z_index * 16) + 0]);  //d

        Vector3 e = new Vector3(x, 0, z);

        float qa = (d.z - e.z) / (d.z - a.z) * a.y + (e.z - a.z) / (d.z - a.z) * d.y;
        float qb = (c.z - e.z) / (c.z - b.z) * b.y + (e.z - b.z) / (c.z - b.z) * c.y;

        float y = (b.x - e.x) / (b.x - a.x) * qa + (e.x - a.x) / (b.x - a.x) * qb;
        return y;
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
