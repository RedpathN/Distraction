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

    private Vector3 moveDir = Vector3.zero;

    private bool falling = false;

    private void Start()
    {
        transform.position += new Vector3(0, nextHeight(), 0);
    }
    // Update is called once per frame
    void Update()
    {
        //Loc
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDir = -transform.forward;
        }
        else
        {
            moveDir = Vector3.zero;
        }

        transform.rotation = Quaternion.Euler(Vector3.up * (Input.GetAxis("Horizontal") * turnSpeed));

        //Gravity
        if (falling)
        {
            transform.position -= new Vector3(0, gravity, 0);
        }

    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        transform.position += (moveDir * moveSpeed) * Time.fixedDeltaTime;
        transform.position += new Vector3(0, nextHeight(), 0);
    }
    private float nextHeight()
    {

        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveDir.z * Time.fixedDeltaTime*4));
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
