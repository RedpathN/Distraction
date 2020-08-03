using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject cameraTarget;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = gameObject.transform.position - cameraTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = cameraTarget.transform.position + cameraOffset;
    }
}
