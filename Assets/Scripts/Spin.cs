using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.y += spinSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(newRot);
    }
}
