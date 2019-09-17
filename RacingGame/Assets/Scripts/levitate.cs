using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitate : MonoBehaviour
{
    public int upwardForce = 5;
    public int forwardForce = 5;
    public int rotateSpeed = 5;
    public int childRotateSpeed = 5;
    public Transform car;
    public float childYRotationAddition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            Debug.Log("hit");
            GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);
        }
 

    }
    void Movement()
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
            transform.eulerAngles = new Vector3
                (transform.eulerAngles.x, transform.eulerAngles.y - (rotateSpeed * Time.deltaTime), transform.eulerAngles.z);
            childYRotationAddition -= 45 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3
                (transform.eulerAngles.x, transform.eulerAngles.y + (rotateSpeed * Time.deltaTime), transform.eulerAngles.z);
            childYRotationAddition += 45 * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            if (childYRotationAddition > 0)
            {
                childYRotationAddition -= 45 * Time.deltaTime;
            }
        }
        if (!Input.GetKey(KeyCode.A))
        {
            if (childYRotationAddition < 0)
            {
                childYRotationAddition += 45 * Time.deltaTime;
            }
        }
        if (childYRotationAddition > 45)
            childYRotationAddition = 45;
        if (childYRotationAddition < -45)
            childYRotationAddition = -45;
        car.localEulerAngles = new Vector3(car.eulerAngles.x, childYRotationAddition, car.eulerAngles.z);


    }
}
