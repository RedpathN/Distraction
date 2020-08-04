using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DistractionManager: MonoBehaviour
{

    private bool isActive = false;
    private GameObject player;

    public float pullForce = 10;
    private float radius;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        radius = GetComponent<SphereCollider>().radius;
    }



    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, GetComponent<SphereCollider>().radius);
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector3.one * 0.3f);
    }

    private void Update()
    {
        if (isActive)
        {
            pullPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }

    private void pullPlayer()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        float influence = ((radius - distToPlayer)/radius); // Get 0-1 value of relative distance
        influence = Mathf.Sin(influence / (Mathf.PI * 2)); // Convert to curve

        if (distToPlayer < radius * 0.99f && distToPlayer > 0.5f)
        {
            Vector3 targetVec = ((transform.position - player.transform.position).normalized);
            targetVec.y = 0;
            player.transform.position += targetVec * (influence * pullForce);
        }
        

    }
}
