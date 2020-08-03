using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 360f;
    [SerializeField]
    private float movementSpeed = 0.5f;


    private CharacterController charCont;

    private Vector3 gravity = new Vector3(0, -0.1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Location
        if (Input.GetKey(KeyCode.W))
        {
            charCont.SimpleMove((transform.forward * movementSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            charCont.SimpleMove(-(transform.forward * movementSpeed));
        }


        //Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (Vector3.up * -rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (Vector3.up * rotationSpeed * Time.deltaTime));
        }

        //Add Gravity
        //transform.position += gravity;

    }
}
