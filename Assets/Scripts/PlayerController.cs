using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{

    private CharacterController charCont;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float gravity;

    public bool falling = true;

    // Update is called once per frame
    void Update()
    {
        //Loc
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.forward * moveSpeed) * Time.deltaTime;
            transform.position += new Vector3(0, nextHeight(1), 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += (-transform.forward * moveSpeed) * Time.deltaTime;
            transform.position += new Vector3(0, nextHeight(-1), 0);
        }
        //Rot
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - (Vector3.up * turnSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (Vector3.up * turnSpeed) * Time.deltaTime);
        }
        
        

        /*if(falling)
        {
            transform.position -= new Vector3(0, gravity, 0);
        }*/
    }

    private float nextHeight(int dir)
    {

        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z + ((moveSpeed * dir) * Time.deltaTime));
        RaycastHit hit;
        float nextPos = 0;
        LayerMask lm = LayerMask.GetMask("Walkable");

        if (Physics.Raycast(origin, -transform.up, out hit, 1.5f, lm))
        {
            falling = false;
            Debug.DrawRay(origin, -transform.up * hit.distance, Color.red);
            nextPos = (hit.point.y - transform.position.y) + 1.01f;
        }
        else 
        {
            falling = true;
        }

        return nextPos;
    }
}
