using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DistractionManager: MonoBehaviour
{
    public float pullForce = 10;
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, GetComponent<SphereCollider>().radius);
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector3.one * 0.3f);
    }


}
