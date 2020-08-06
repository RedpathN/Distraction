using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    private float maxFallTimer = 1;


    private bool isMoving = false;
    private bool isFalling = false;
    private bool fallTimerOn = false;
    private float fallTimer = 0;

    private Vector3 moveDir = Vector3.zero;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.position += new Vector3(0, nextHeight().y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //Loc
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !isFalling)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (fallTimerOn)
        {
            fallTimer += Time.deltaTime;
            bool falling = checkFalling();
            if (!falling)
            {
                fallTimerOn = false;
                fallTimer = 0;
            }
            else if (falling && fallTimer > maxFallTimer)
            {
                fallTimerOn = false;
                fallTimer = 0;
                isFalling = true;
            }

        }

        transform.rotation = Quaternion.Euler(Vector3.up * (Input.GetAxis("Horizontal") * turnSpeed));
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            movePlayer();
        }

        if (transform.position.y < -20f)
        {
            death();
        }

    }
    private void movePlayer()
    {
        rb.AddForce(((transform.forward * moveSpeed) + nextHeight()).normalized * Input.GetAxis("Vertical"), ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, moveSpeed);
    }

    private Vector3 nextHeight()
    {
        Vector3 origin = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 0.025f);
        RaycastHit hit;
        Vector3 nextPos = Vector3.zero;

        LayerMask lm = LayerMask.GetMask("Walkable");

        if (Physics.Raycast(origin, -transform.up, out hit, 3f, lm))
        {
            Debug.DrawRay(origin, -transform.up * hit.distance, Color.red);
            nextPos = (hit.point - transform.position).normalized;
        }
        else
        {
            fallTimerOn = true;
        }

        return nextPos;
    }
    
    private bool checkFalling()
    {
        bool falling = false;

        float rad = GetComponent<CapsuleCollider>().radius * 0.75f;
        List<Vector3> origins = new List<Vector3> { Vector3.zero, transform.forward, transform.right, -transform.forward, -transform.right };
        foreach(Vector3 vec in origins)
        {
            Vector3 origin = transform.position + (vec * rad);
            RaycastHit hit;

            LayerMask lm = LayerMask.GetMask("Walkable");

            if (Physics.Raycast(origin, -transform.up, out hit, 5f, lm))
            {
                falling = false;
                Debug.DrawRay(origin, -transform.up * hit.distance, Color.red);
            }
            else
            {
                falling = true;
            }
            
        }

        return falling;
    }

    void death()
    {

    }


}
