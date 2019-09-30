using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 originPosition;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + originPosition, .5f);
    }
}
