using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensting : MonoBehaviour{

    public int Instances;
    public Mesh mesh;
    public Material[] meterials;

    private List<List<Matrix4x4>> Batches = new List<List<Matrix4x4>>();

    // Start is called before the first frame update
    void Start(){

        int added = 0;

        Batches.Add(new List<Matrix4x4>());

        for(int i = 0; i < Instances; i++){


            if(added < 1000){

                Batches[Batches.Count - 1].Add(Matrix4x4.TRS(new Vector3(Random.Range(0.0f, 75.0f),Random.Range(0.0f, 75.0f),Random.Range(0.0f, 75.0f)), Quaternion.identity, Vector3.one));
                added++;
            }
            else{

                Batches.Add(new List<Matrix4x4>());
                added = 0;
            }
        }
    }

    // Update is called once per frame
    void Update(){

        foreach(var Batch in Batches){

            for(int i = 0; i < mesh.subMeshCount; i++){

                Graphics.DrawMeshInstanced(mesh, i, meterials[i], Batch);
            }
        }
    }
}
