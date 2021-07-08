using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankObject : MonoBehaviour
{
    private Rigidbody targetRb;
    [SerializeField] float minSpeed = 0.01f;
    [SerializeField] float maxSpeed = 0.2f;
    [SerializeField] float maxTorque = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);


        targetRb.AddForce(RandomForce(), ForceMode.VelocityChange);

        //InvokeRepeating("AddForce", 0.2f, 1.3f);
    }

    private void AddForce()
    {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
