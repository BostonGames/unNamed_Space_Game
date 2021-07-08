using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardCamera : MonoBehaviour
{
    [SerializeField] float objectSpeed = 75f;
    
    // Start is called before the first frame update
    void Start()
    {
        objectSpeed = GameManager.instance.objectSpeed0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the object upward in world space 1 unit/second.
        transform.Translate(-Vector3.forward * objectSpeed * Time.deltaTime, Space.World);
    }
}
