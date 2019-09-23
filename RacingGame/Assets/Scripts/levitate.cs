using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitate : MonoBehaviour
{

    [Header("Forces")]
    public int upwardForce = 20;
    public int forwardForce = 5;
    public int downwardForce = 10;
    [Header("Rotation Speeds")]
    public int rotateSpeed = 5;
    public int childRotateSpeed = 5;
    public Transform car;
    public float childYRotationAddition;
    public float myYRotation;
    Quaternion desiredRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RaycastHit upwardHit;
        RaycastHit downardHit;
        if (Physics.Raycast(transform.position, -transform.up, out upwardHit, 1f))
        {
            Debug.Log("Force Up");
            GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);

        }
        if(Physics.Raycast(transform.position, -transform.up, out downardHit, 5f))
        {
            GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("Force Down");
            GetComponent<Rigidbody>().AddForce(-transform.up * downwardForce);
            desiredRotation = Quaternion.FromToRotation(transform.up, downardHit.normal) * transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, .3f);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
    /// <summary>
    /// Controls movement through wasd
    /// </summary>
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
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            childYRotationAddition -= 45 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
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
