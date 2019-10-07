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
            if(upwardHit.transform.tag == "Track")
             GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);

        }
        if (Physics.Raycast(transform.position, -transform.up, out downardHit, 10f))
        {
            if (downardHit.transform.tag == "Track")
            {
                GetComponent<Rigidbody>().useGravity = false;

                GetComponent<Rigidbody>().AddForce(-transform.up * downwardForce);

                desiredRotation = Quaternion.FromToRotation(transform.up, downardHit.normal) * transform.rotation;
                if (gameObject.tag == "Player")
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, .05f);
                else
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, .45f);
                if (gameObject.tag == "Player")
                    GetComponent<Movement>().forwardForce = 1200;
            }
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                GetComponent<Rigidbody>().useGravity = true;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.localEulerAngles.y, 0), .01f);
                // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, .01f);

                GetComponent<Movement>().forwardForce = 0;
            }
        }
    }

}
