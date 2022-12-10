using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;

public class FitToTerrain : MonoBehaviour
{
    Mesh mesh;
    Vector3[] originalVerts = new Vector3[0];


    static List<NavMeshSurface> surfaces = new List<NavMeshSurface>();
    void OnInit()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVerts = mesh.vertices;
    }

    public void UpdateMesh(GameObject landscape)
    {
        if (!mesh)
        {
            OnInit();
        }
        LandScape landscapescript = landscape.GetComponent<LandScape>();
        Vector3[] verts = mesh.vertices;
        for (int i = 0; i < verts.Length; i++)
        {
            Vector3 vert = transform.localToWorldMatrix.MultiplyPoint3x4(verts[i]);
            float y = landscapescript.GetPositionHeight(vert.x, vert.z) + transform.localPosition.y;
            verts[i] = (transform.worldToLocalMatrix.MultiplyPoint3x4(new Vector3(vert.x, y, vert.z))) + new Vector3(0,originalVerts[i].y,0);
            
            //verts[i] += new Vector3(0,transform.localToWorldMatrix.MultiplyPoint3x4(originalVerts[i]).y,0);
        }
        GetComponent<MeshFilter>().mesh.vertices = verts;
        GetComponent<MeshFilter>().mesh.RecalculateBounds();
        GetComponent<MeshFilter>().mesh.RecalculateNormals();

        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
        NavMeshSurface navMeshSurface = GetComponent<NavMeshSurface>();
        if (navMeshSurface)
        {
            surfaces.Add(navMeshSurface);
            RebuildSurfaces();
        }
        
    }
    public void RebuildSurfaces()
    {
        for(int i = 0; i < surfaces.Count; i++)
        {
            
            surfaces[i].BuildNavMesh();
            if (!surfaces[i].enabled)
            {
                surfaces.Remove(surfaces[i]);
            }
        }
    }
    private void OnDestroy()
    {
        NavMeshSurface navMeshSurface = GetComponent<NavMeshSurface>();

        if (navMeshSurface)
        {
            navMeshSurface.RemoveData();
            navMeshSurface.enabled = false;
            RebuildSurfaces();

        }
    }

}
