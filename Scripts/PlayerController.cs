using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    PlayerControls controls;
    [SerializeField] UIManager uiScript;


    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject firstPersonCamera;
    private bool firstPersonView;


    [Tooltip("In meters/sec")][SerializeField] float moveSpeedWASD = 50f;
    [Tooltip("In meters/sec")] [SerializeField] float moveSpeedKbd = 50f;
    [Tooltip("In meters/sec")][SerializeField] float moveSpeedGamepad = 35f;
    [Tooltip("clamp player movement")] [SerializeField] float minXValue, maxXValue, minYValue, maxYValue;

    [SerializeField] float positionPitchFactor = -0.5f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float rollDueToControlThrow = -27f;    

    float horizontalThrow, verticalThrow;

    private void Awake()
    {
        controls = new PlayerControls();

        //TODO: works, but the Xbox controllers Dpad is not working for the crosshair
        //  it wont move and I get a bunch of mac errors in the console.
        //  I think it might have to do with the Mac. look into later for publishing
        controls.Player.ChangeView.performed += ctx => ToggleCameraViewMainToFirst();
    }



    private void FixedUpdate()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        //change Camera view
        if (kb.vKey.wasPressedThisFrame)
        {
            ToggleCameraViewMainToFirst();
        }

        if(moveSpeedWASD != moveSpeedKbd)
        {
            if (Input.anyKey)
            {
                moveSpeedWASD = moveSpeedKbd;
                Debug.Log("Keyboard is bieng Used, movement speed is: " + moveSpeedWASD);
            }
        }


        if(moveSpeedWASD != moveSpeedGamepad){
            if (Input.GetAxis("joystickX") > 0)
            {
                moveSpeedWASD = moveSpeedGamepad;
                Debug.Log("Gamepad is bieng Used, movement speed is: " + moveSpeedWASD);

            }
            if (Input.GetAxis("joystickY") < 0)
            {
                moveSpeedWASD = moveSpeedGamepad;
            }
        }


        Move();
        Rotation();

        //TODO: if player z-value is < 0, slowly lerp back to 0 like if i had a collision or something
        if (gameObject.transform.position.z > 0)
        {
           // ResetZPosition();
            Debug.Log("Player has been knocked off z-position of 0");
        }

    }



    public void Shoot()
    {
        Debug.Log("Shoot activated - pew pew!");
    }
    public void Abduct()
    {
        Debug.Log("Attempted Abduction!");
    }

    public void Turbo()
    {
        Debug.Log("Turbo Activated!");
    }

    public void Rotation()
    {

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

    public void Move()
    {
        Debug.Log("Player wants to move!");


        //--TRANSLATION--

        //-----HORIZONTAL MOVEMENT-----
        horizontalThrow = Input.GetAxis("Horizontal");
        float xOffset = horizontalThrow * Time.deltaTime * moveSpeedWASD;
        float rawXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawXPos, minXValue, maxXValue);

        //-----VERTICAL MOVEMENT-----
        verticalThrow = Input.GetAxis("Vertical");
        float yOffset = verticalThrow * Time.deltaTime * moveSpeedWASD;
        float rawYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawYPos, minYValue, maxYValue);        
        
        // keep player positioned at 0 on z axis 
        // even with collisions, will lerp back to 0 quickly
        float t = 1f;
        float zPos = Mathf.SmoothStep(transform.localPosition.z, 0, t);
        
        transform.localPosition = new Vector3(xPos, yPos, zPos);

    }

    public void ToggleCameraViewMainToFirst()
    {
        if(firstPersonView == false)
        {
            FirstPersonCameraView();
        }
        else if(firstPersonView == true)
        {
            MainCameraView();
        }
        else { Debug.Log("error reading firstPersonView bool, value is: " + firstPersonView); return; }
    }


    private void MainCameraView()
    {
        mainCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
        uiScript.HideCrossHair();

        firstPersonView = false;
    }

    private void FirstPersonCameraView()
    {
        mainCamera.SetActive(false);
        firstPersonCamera.SetActive(true);
        uiScript.ShowCrossHair();

        firstPersonView = true;

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
