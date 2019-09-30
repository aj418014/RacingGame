using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles != Vector3.zero)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Vector3.zero, .1f);
        }

    }
}
