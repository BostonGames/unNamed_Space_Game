using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpaceCurrentUIController : MonoBehaviour
{
    [SerializeField] GameObject entireUIgameobject;
    [SerializeField] GameObject goAnimGameobject;


    [SerializeField] UIManager uiScript;



    public float currentHealth;
    public float maxHealth = 100f;

    public float currentShield;
    public float maxShield = 100f; 

    public float increaseShieldValue = 10f;

    //when I list UnityEngine.UI above, I can use "Slider" instead of
    //  UnityEngine.UI.Slider. just a different library.
    public Image healthBar;
    public Image shieldBar;
    //can assign the slider you want in your Heirarchy, can have a bunch of different kinds of sliders
    //  1.) health DONE
    //  2.) enemy status / health 
    //  3.) Interactive energy level (% of Bark power absorbed?)


    public Image barkIcon;
    public Image boostIcon;
    public Image thrusterIcon;
    public Image hoverIcon;


    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject timeTextObject;
    [SerializeField] float timeRemainingSeconds = 90.0f;
    private bool timerIsRunning;
       



    void Start()
    {

       


    }

    public void StartSpaceCurrent() {
        //----RESET STATS FOR NEW GAME----\\
        maxShield = 100f;
        maxHealth = 100f;
        currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.fillAmount = 1f;
        shieldBar.fillAmount = 1f;


        barkIcon.enabled = false;
        boostIcon.enabled = false;
        thrusterIcon.enabled = false;
        hoverIcon.enabled = false;

        Invoke("StartTimer", 1.5f);
        GameManager.instance.ClearAllObjectCounts();


        goAnimGameobject.SetActive(true);
    }

    public void StopSpaceCurrent()
    {
        //----RESET STATS FOR NEW GAME----\\
        barkIcon.enabled = false;
        boostIcon.enabled = false;
        thrusterIcon.enabled = false;
        hoverIcon.enabled = false;



        goAnimGameobject.SetActive(false);

    }


    private void Update()
    {
        if (timerIsRunning)
        {
            //TODO ------------------CHECK LATER FOR PUBLISHI?NG -----------------\\
            //TEMP: fixed a weird bug where the timer always went to -2 seconds, idk if this is a good perma fix
            // should go to > 0 instead
            if (timeRemainingSeconds > 2)
            {
                timeRemainingSeconds -= Time.deltaTime;
                DisplayCountdown(timeRemainingSeconds);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemainingSeconds = 0;
                timerIsRunning = false;

                ShowOrHideEverything(true);

                GameManager.instance.useTallyScreen0 = true;

                //resets the scene 
                GameManager.instance.RestartCurrentScene();


            }
        }
        // Debug.Log(timeRemainingSeconds);
    }

    public void StartTimer()
    {
        timerIsRunning = true;

    }

    private void FixedUpdate()
    {
        //this was how I fixed the button issue where some would show and some wouldn't
        //  when they all were in the same funciton/method.
        RespondToPlayerInputX();
        RespondToPlayerInputY();
        RespondToPlayerInputA();
        RespondToPlayerInputB();

        //prob canDelete RespondToDirectionalInput();
    }

    public void RespondToDirectionalInputUp()
    {
        //when player goes up, show the up one in UI controller
        // same for left
        //same for right
        //when neutral use both for down?
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Debug.Log("Xbox X button sensed by the Space Curent UI Controller");
            barkIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W key sensed by the Space Current UI Controller");
            uiScript.ShowMovingUpIndicator();

        }
        else
        {
            barkIcon.enabled = false;
        }

    }

    private void RespondToPlayerInputX()
    {
        //GetKeyDown only activates the control you want once, even if key is continuously pressed down
        //  for a few seconds or whatever. We want to use GetKey so that the whole time the button
        //  or key is pressed down the button icon is activated


        //Bark button pressed
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            Debug.Log("Xbox X button sensed by the UI Controller");
            barkIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E key sensed by the UI Controller");
            barkIcon.enabled = true;

        }
        else
        {
            barkIcon.enabled = false;
        }
    }

    private void RespondToPlayerInputY()
    {
        //Thruster button pressed
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Debug.Log("Xbox A button sensed by the UI Controller");
            thrusterIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key sensed by the UI Controller");
            thrusterIcon.enabled = true;

        }
        else
        {
            thrusterIcon.enabled = false;
        }
    }

    private void RespondToPlayerInputA()
    {
        //Hover button pressed
        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            Debug.Log("Xbox Y button sensed by the UI Controller");
            hoverIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("Xbox RB trigger button sensed by the UI Controller");
            hoverIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q key sensed by the UI Controller");
            hoverIcon.enabled = true;

        }
        else
        {
            hoverIcon.enabled = false;
        }
    }

    private void RespondToPlayerInputB()
    {
        //Boost button pressed
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            //TODO lessen the fill of the Turbo bar

            Debug.Log("Xbox B button sensed by the UI Controller");
            boostIcon.enabled = true;

        }
        else if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("R key sensed by the UI Controller");
            boostIcon.enabled = true;

        }

        //set all keys inactive if no buttons are being pressed
        else
        {
            boostIcon.enabled = false;
        }
    }

    public void DealDamage(float decreaseThisMuch)
    {
        //Deduct the damage dealth from the character's health
        //currentHealth -= damageValue;

        currentHealth -= decreaseThisMuch;
        float calc_health = currentHealth / maxHealth; //makes health values into a percentage so our slider UI element slides correctly between 0 and 1

        //the new health is calculated above and sent to the Calculate Health function to set the radial meter to the right fill. 
        CalculateHealth(calc_health);


        Debug.Log("DealDamage Activated - UI Controller, current health is " + calc_health);

        //if the player is out of health, die
        if (currentHealth <= 0)
        {
            Debug.Log("Player has lost all energy");
            currentHealth = 0f;
        }
    }

    public void ReplenishHealth(float increaseHealthValue)
    {
        //so health cannot exceed 100
        if(currentHealth >= 100f) { return; }

        //Add the health to the character's health
        //currentHealth += damageValue;

        currentHealth += increaseHealthValue;
        float calc_health = currentHealth / maxHealth; //makes health values into a percentage so our slider UI element slides correctly between 0 and 1

        //the new health is calculated above and sent to the Calculate Health function to set the radial meter to the right fill. 
        CalculateHealth(calc_health);


        Debug.Log("ReplenishHealth Activated - UI Controller");

        //if the player is out of health, die
        if (currentHealth >= 90)
        {
            //something when youre at full or nearly full health
        }
    }

    public void FullyReplenishHealth()
    {
        currentHealth = maxHealth;
        CalculateHealth(currentHealth);
    }

    //a method that returns a float value
    public void CalculateHealth(float playerHealth)
    {
        healthBar.fillAmount = playerHealth;

    }


    public void IncreaseTurboBoost()
    {
        //Deduct the damage dealth from the character's health
        currentShield += increaseShieldValue;
        float calc_turbo = currentShield / maxShield;

        //the new health is calculated above and sent to the Calculate Health function to set the radial meter to the right fill. 
        CalculateTurbo(calc_turbo);


        Debug.Log("UseTurboBoost Activated - UI Controller");

        //if the player has max turbo, do something
        if (currentShield >= 1)
        {
            //TODO have the turbo UI shine a little or something like that?
        }
    }

    public void DecreaseShield(float decreaseThisMuch)
    {
        //if player status is 0 or below, do not continue the shield method
        if (shieldBar.fillAmount <= 0)
        {
            DealDamage(decreaseThisMuch);
            shieldBar.fillAmount = 0;
        }

        //in case shield is almost gone, ensures full damage is dealth through to the energy meter
        if(shieldBar.fillAmount < (decreaseThisMuch / maxShield))
        {
            // turns the ratio of shieldBar remaining into a float so it can be accurately passed through the DealDamage fn
            float decreaseEnergy = decreaseThisMuch - (shieldBar.fillAmount * maxShield);


            //if its negative make it positive
           if(decreaseEnergy < 0) { decreaseEnergy = decreaseEnergy * -1; }


            DealDamage(decreaseEnergy);
            CalculateTurbo(0);

            Debug.Log(decreaseThisMuch + "DAMAGE TAKEN: shield value: " + currentShield + " - energy decreased by: " + decreaseEnergy + " energy value is: " + currentHealth);
        }
        else
        {
            
            //Deduct the damage dealth from the character's health
            currentShield -= decreaseThisMuch;
            float calc_turbo = currentShield / maxShield;

            //the new health is calculated above and sent to the Calculate Health function to set the radial meter to the right fill. 
            CalculateTurbo(calc_turbo);

            Debug.Log("Players Shield has taken " + decreaseThisMuch + " damage, " + currentShield + " shield value remains, and " + currentHealth + " energy remains");
        }




        //if the player is out of turbo, do this
        if (currentShield <= 0)
        {
            //TODO have the shield UI jolt a little?
        }
    }

    public void UseTurboBoost()
    {
        //if player status is 0 or below, do not continue the method
        if (shieldBar.fillAmount <= 0)
        {
            return;
        }

        float useTurboValue = 0.5f;
        //Deduct the damage dealth from the character's health
        currentShield -= useTurboValue;
        float calc_turbo = currentShield / maxShield;

        //the new health is calculated above and sent to the Calculate Health function to set the radial meter to the right fill. 
        CalculateTurbo(calc_turbo);


        Debug.Log("UseTurboBoost Activated - UI Controller");

        //if the player is out of turbo, do this
        if (currentShield <= 0)
        {
            //TODO have the turbo UI jolt a little?
        }
    }

    //CalculatteSHIELD in this case, but dont' want to have to update all other scripts that call this fn
    public void CalculateTurbo(float playerTurbo)
    {
        
        //using mathf.lerp: t needs to be updated by Time.eltatime from 0 to 1 apparently, otherwise it just fills normally.
        shieldBar.fillAmount = Mathf.Clamp(playerTurbo, 0f, 1f);

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    //when measuring time to complete something
    void DisplayCountdown(float timeToDisplay)
    {

        timeToDisplay -= 1;
  

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }



    public void HideTimeUI()
    {
        timeTextObject.SetActive(false);
    }

    public void ShowOrHideEverything(bool yesOrNo)
    {
        entireUIgameobject.SetActive(yesOrNo);
    }


}
