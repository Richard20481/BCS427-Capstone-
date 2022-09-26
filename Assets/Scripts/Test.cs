using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
     [SerializeField] Mesh _mesh = null;
     [SerializeField] Material _material = null;
     Matrix4x4[] _matrices = new Matrix4x4[100];
     void Update ()
     {
         if( _mesh!=null && _material!=null )
         {
             UpdateMatrices();
             Graphics.DrawMeshInstanced( _mesh , 0 , _material , _matrices );
         }
     }
     void UpdateMatrices ()
     {
         Vector3 origin = transform.position;
         float time = Time.time;
         const float tau = Mathf.PI * 2f;
         int numMatrices = _matrices.Length;
         for( int i=0 ; i<numMatrices ; i++ )
         {
             float theta = (float)i / (float)(numMatrices-1) * tau;
             _matrices[i] = Matrix4x4.TRS(
                 origin + new Vector3( 0 , Mathf.Sin(theta) , Mathf.Cos(theta) )*10f ,
                 Quaternion.Euler( new Vector3(333f,10f,333f)*time ) ,
                 Vector3.one
             );
         }
     }
}
