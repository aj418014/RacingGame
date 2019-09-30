using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int forwardForce = 5;
    public int rotateSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        PlayerInputMovement();   
    }
    void PlayerInputMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * forwardForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
