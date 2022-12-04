using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Selection : MonoBehaviour{

    /**
     * Attributes.
     */
    public GameObject Gm_obj;
    
    // Start is called before the first frame update.
    void Start(){

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        int[] tris = new int[6]{

                // lower left triangle
                1, 0, 3,
                // upper right triangle
                0, 3, 2
            };

        mesh.triangles = tris;
    }


    /**
     * Gets max y vector.
     */
    private float getMaxY(Vector3[] v){

        float maxY = 0.0f;

        for(int i = 0; i != v.Length; i++){

            maxY = maxY < v[i].y ? v[i].y : maxY;
        }

        return maxY;
    }

    // /**
    //  * Gets the midpoint of two vec 3.
    //  * (Deprecated... )
    //  */
    // private Vector3 midpoint(Vector3 x, Vector3 y){

    //     return (x + y) / 2.0f;
    // }

    // Update is called once per frame.
    void Update(){

        var cam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(cam, out hit, 100.0f)){

            if(hit.collider.tag == "Map16"){

                LandScape landscape = hit.collider.GetComponentInParent<LandScape>();

                Vector3 pos = hit.point;
                int x = (int) Mathf.Round(pos.x / 2) * 2;
                int z = (int) Mathf.Round(pos.z / 2) * 2;

                Mesh mesh = this.GetComponent<MeshFilter>().mesh;
                Vector3[] verts = mesh.vertices;
                Vector3[] tile_verts = landscape.GetTileVerts(hit.point.x,hit.point.z);

                float max_y = Mathf.Max(tile_verts[0].y, tile_verts[1].y, tile_verts[2].y, tile_verts[3].y);

                for (int i = 0; i < verts.Length; i++){
                    
                    verts[i] = this.transform.InverseTransformPoint(tile_verts[i]) + transform.up*.01f;
                }
                
                /**
                 * Places down the new foundation and the building...
                 */
                if(Input.GetMouseButtonDown(0)){

                    GameObject a = Instantiate(Gm_obj, new Vector3(x, this.getMaxY(tile_verts) - 0.90f, z), Quaternion.identity);
                    //a.transform.Rotate(-90.0f, 0.0f, 0.0f, 0.0f);
                }

                mesh.vertices = verts;
                mesh.RecalculateBounds();

                this.transform.position = pos;
            }
        }
    }

    void OnDrawGizmosSelected(){

        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
