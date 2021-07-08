using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankRandomMovement : MonoBehaviour
{
    private Rigidbody targetRb;

    [SerializeField] float minSpeed = 0.01f;
    [SerializeField] float maxSpeed = 1.2f;


    [SerializeField] float maxTorque = 2.0f;


    [SerializeField] float rot_speed_xmax = 10f;
    [SerializeField] float rot_speed_xmin = 1;

    [SerializeField] float rot_speed_ymax = 0f;
    [SerializeField] float rot_speed_ymin = 70f;

    [SerializeField] float rot_speed_zmax = 5f;
    [SerializeField] float rot_speed_zmin = -35f;

    [SerializeField] bool local = false;
    [SerializeField] bool isRotating = false;



    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        InvokeRepeating("AddTorque", Random.Range(0, 1), Random.Range(0.2f, 3f));
        InvokeRepeating("AddForce", Random.Range(0, 1), Random.Range(0.2f, 3f));


    }

    void FixedUpdate()
    {
        if (isRotating)
        {
            if (local)
            {
                //transform.Rotate(transform.up, Time.fixedDeltaTime*rot_speed_x);
                transform.Rotate(Time.fixedDeltaTime * new Vector3(Random.Range(rot_speed_xmin, rot_speed_xmax), Random.Range(rot_speed_ymin, rot_speed_ymax), Random.Range(rot_speed_zmin, rot_speed_zmax)), Space.Self);
            }
            else
            {
                transform.Rotate(Time.fixedDeltaTime * new Vector3(Random.Range(rot_speed_xmin, rot_speed_xmax), Random.Range(rot_speed_ymin, rot_speed_ymax), Random.Range(rot_speed_zmin, rot_speed_zmax)), Space.World);
            }
        }
        else
        {
            return;
        }

    }

    private void AddTorque()
    {
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        Debug.Log("AddTorque is being used");
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }


    private void AddForce()
    {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }



}
