using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Selection : MonoBehaviour{
    
    // Start is called before the first frame update.
    void Start(){
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        int[] tris = new int[6]
               {
                    // lower left triangle
                    1, 0, 3,
                    // upper right triangle
                    0, 3, 2
               };
        mesh.triangles = tris;
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

                LandScape landscape = hit.collider.GetComponentInParent<LandScape>();

                Vector3 pos = hit.point;
                int x = (int) Mathf.Round(pos.x / 2) * 2;
                int z = (int)Mathf.Round(pos.z / 2) * 2;

                //pos = new Vector3(x, 0, z);

                Mesh mesh = this.GetComponent<MeshFilter>().mesh;
                Vector3[] verts = mesh.vertices;
                Vector3[] tile_verts = landscape.GetTileVerts(hit.point.x,hit.point.z);

                float max_y = Mathf.Max(tile_verts[0].y, tile_verts[1].y, tile_verts[2].y, tile_verts[3].y);

                for (int i = 0; i < verts.Length; i++)
                {
                    // tile_verts[i].y = max_y;
                    verts[i] = this.transform.InverseTransformPoint(tile_verts[i]) + transform.up*.01f;
                }
                mesh.vertices = verts;

                mesh.RecalculateBounds();
                

                this.transform.position = pos;

            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawSphere(transform.position, 1);
    }
}
