using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Forces")]
    public int forwardForce = 5;
    public int rotateSpeed = 5;
    private int backwardForce;
    // Update is called once per frame
    [Header("RotateCar")]
    public int childRotateSpeed = 5;
    public Transform car;
    Vector3 desiredCarRotation;
    public float carYRotation;
    public float maxCarYRotation;
    public float minCarYRotation;
    private void Start()
    {
        backwardForce = forwardForce / 2;
    }
    void Update()
    {
        PlayerInputMovement();
        RotateCar();
    }
    /***************************************************************************
     * FunctionName: PlayerInputMovement
     * Created By: Andy Johnson
     * Purpose: to take in inputs from the xbox controller and turn and give the car force
     * 
     ***************************************************************************/
    void PlayerInputMovement()
    {
        if (Input.GetAxis("X360_TriggerR") > .2)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce * Time.deltaTime * Input.GetAxis("X360_TriggerR"));
        }
        if (Input.GetAxis("X360_TriggerL") > .2)
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * backwardForce * Time.deltaTime * Input.GetAxis("X360_TriggerL"));
        }
        if (Input.GetAxis("X360_LStickX") > .2)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime * Input.GetAxis("X360_LStickX"), 0);
        }
        if (Input.GetAxis("X360_LStickX") < -.2)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime * Input.GetAxis("X360_LStickX"), 0);
        }
    }
 /***************************************************************************
 * FunctionName: RotateCar
 * Created By: Andy Johnson
 * Purpose: to Rotate the car when the player inputs buttons to make it look
 * slightly more real;
 ***************************************************************************/
 void RotateCar()
    {
        if (Input.GetAxis("X360_LStickX") > .2)
            carYRotation += 10 * Time.deltaTime;
        if (carYRotation > 0)
            carYRotation -= 5 * Time.deltaTime;
        if (carYRotation > maxCarYRotation)
            carYRotation = maxCarYRotation;
        if (Input.GetAxis("X360_LStickX") < -.2)
            carYRotation -= 10 * Time.deltaTime;
        if (carYRotation < 0)
            carYRotation += 5 * Time.deltaTime;
        if (carYRotation < minCarYRotation)
            carYRotation = minCarYRotation;
        print(desiredCarRotation);
        car.localEulerAngles = new Vector3(car.localEulerAngles.x, carYRotation, car.localEulerAngles.z);

    }
}
