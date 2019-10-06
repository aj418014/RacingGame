using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levitate : MonoBehaviour
{

    [Header("Forces")]
    public int upwardForce = 20;
    public int downwardForce = 10;
    [Header("Rotation Speeds")]
    Quaternion desiredRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit upwardHit;
        RaycastHit downardHit;
        if (Physics.Raycast(transform.position, -transform.up, out upwardHit, 1f))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);

        }
        if (Physics.Raycast(transform.position, -transform.up, out downardHit, 10f))
        {
            GetComponent<Rigidbody>().useGravity = false;

            GetComponent<Rigidbody>().AddForce(-transform.up * downwardForce);

            desiredRotation = Quaternion.FromToRotation(transform.up, downardHit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, .1f);
            if(gameObject.tag == "Player")
                 GetComponent<Movement>().forwardForce = 1200;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.localEulerAngles.y, 0), .01f);
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, .01f);
            if (gameObject.tag == "Player")
                GetComponent<Movement>().forwardForce = 0;
            }
    }

}
