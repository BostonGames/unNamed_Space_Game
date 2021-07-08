using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;


    [SerializeField] float positionPitchFactor = -0.5f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float rollDueToControlThrow = -27f;

    float horizontalThrow, verticalThrow;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = player.position - transform.position;
    
        Rotationx();

    }


    public void Rotationx()
    {
        verticalThrow = Input.GetAxis("Vertical");
        horizontalThrow = Input.GetAxis("Horizontal");

        //--ROTATION--  want to go in the X, Y, then Z order so values show in game correctly
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControThrow = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControThrow;

        
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float roll = horizontalThrow * rollDueToControlThrow;
        //--Pitch: x-axis
        //--Yaw: y-axis
        //--Roll: z-axis
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
