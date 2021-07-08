using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInGameManager : MonoBehaviour
{
    [SerializeField] ComputerLogScript computerLogScript;

    [SerializeField] ParticleSystem takeDamageParticle;
    [SerializeField] GameObject starAuraParticle;
    [SerializeField] ParticleSystem heartParticle;
    [SerializeField] ParticleSystem alertParticle;
    [SerializeField] ParticleSystem energyParticle;


    private bool isColliding = false;

    //TODO possible separate script for all the sounds?
    private AudioSource playerAudio;

    [SerializeField] AudioClip itemCollectAudioClip;
    [SerializeField] AudioClip NPC0AudioClip;
    [SerializeField] AudioClip Enemy0AudioClip;
    [SerializeField] AudioClip healthCollectAudioClip;
    [SerializeField] AudioClip damageAudioClip;
    [SerializeField] AudioClip getTurboAudioClip;
    [SerializeField] AudioClip useTurboAudioClip;

    [SerializeField] AudioClip abductAudioClip;
    [SerializeField] AudioClip dyingAudioClip;
    [SerializeField] AudioClip getAuraPickupAudioClip;
    [SerializeField] AudioClip useAuraAudioClip;

    public SpaceCurrentUIController uiScript;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

        if (other.gameObject.CompareTag("Health0"))
        {
            Destroy(other.gameObject);
            energyParticle.Play();
            playerAudio.PlayOneShot(healthCollectAudioClip);

            uiScript.ReplenishHealth(25f);

            GameManager.instance.Object0Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Life Energy Increased");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10 = Shock
            // 11 = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);


        }
        //SHIELD REPAIR
        if (other.gameObject.CompareTag("Health1"))
        {
            Destroy(other.gameObject);
            heartParticle.Play();
            playerAudio.PlayOneShot(healthCollectAudioClip);

            uiScript.IncreaseTurboBoost();

            GameManager.instance.Object1Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Shield Energy Increased");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);


        }

        //SHIELD PICKUP - Invincibilty to damage
        if (other.gameObject.CompareTag("Resource0"))
        {
            Destroy(other.gameObject);

            StartCoroutine(StartCounter());

            //ienumerator invoke > animation plays for X seconds

            playerAudio.PlayOneShot(getAuraPickupAudioClip);
            ShowSurprise();

            GameManager.instance.Object2Count(1);


            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Grade 0 Energy Attained");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);
        }
        if (other.gameObject.CompareTag("Resource1"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(itemCollectAudioClip);
            ShowSurprise();

            GameManager.instance.Object3Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Grade 1 Energy Attained");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);
        }
        if (other.gameObject.CompareTag("Resource2"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(itemCollectAudioClip);
            ShowSurprise();

            GameManager.instance.Object4Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Grade 2 Energy Attained");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);
        }
        if (other.gameObject.CompareTag("Resource3"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(itemCollectAudioClip);
            ShowSurprise();

            GameManager.instance.Object5Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Grade 3 Energy Attained");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(0);
        }
        if (other.gameObject.CompareTag("ResourceSpecial"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(itemCollectAudioClip);
            ShowSurprise();

            GameManager.instance.ObjectSpecialCount(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis(GameManager.instance.objectCountSpecial + " of 10 special items collected");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(1);
        }

        if (other.gameObject.CompareTag("Enemy0"))
        {
            Destroy(other.gameObject);
            //make npc slow down and a dialogue box appear

            playerAudio.PlayOneShot(Enemy0AudioClip);
            ShowSurprise();

            GameManager.instance.Object6Count(1);

            //------------------------------- COMPUTER LOG REACTION -------------------------------\\
            computerLogScript.ComputerSaysThis("Hostile Entity Neutralized");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(11);
        }

        // OPTIONAL: playing "tag" with the space seal
        if (other.gameObject.CompareTag("NPC0"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(NPC0AudioClip);
            ShowSurprise();

            GameManager.instance.Object7Count(1);

            //make npc slow down and a dialogue box appear
            computerLogScript.ComputerSaysThis("Unknown Entity Abducted");
            // 0  = Neutral
            // 1  = Exclaimation
            // 2  = DotDotDot
            // 3  = HappyAffection
            // 4  = Laughing
            // 5  = Anger
            // 6  =   Looking
            // 7  =   O_O
            // 8  =  Quesiton Mark ?
            // 9  = Serious
            // 10  = Shock
            // 11  = Suspicion
            // 12 = XD
            computerLogScript.ShowThisEmotePic(11);
        }


        if (other.gameObject.CompareTag("ObstacleLarge"))
        {
            Destroy(other.gameObject);
            takeDamageParticle.Play();
            playerAudio.PlayOneShot(damageAudioClip);

 
                uiScript.DecreaseShield(35f);


            
            Debug.Log("Player has hit a large obstacle");
        }
        if (other.gameObject.CompareTag("ObstacleMed"))
        {
            Destroy(other.gameObject);
            takeDamageParticle.Play();
            playerAudio.PlayOneShot(damageAudioClip);

    
                uiScript.DecreaseShield(20f);

            Debug.Log("Player has hit a medium obstacle");
        }
        if (other.gameObject.CompareTag("ObstacleSmall"))
        {
            Destroy(other.gameObject);
            
            takeDamageParticle.Play();
            playerAudio.PlayOneShot(damageAudioClip);

   
                uiScript.DecreaseShield(10f);


            Debug.Log("Player has hit a small obstacle");
        }
        if (other.gameObject.CompareTag("Deadly"))
        {
            Destroy(other.gameObject);
            //Invoke("ProperDeath", 0f);
            playerAudio.PlayOneShot(dyingAudioClip);

            Debug.Log("player has died");
        }


        //OPTIONAL: TURBO BOOST
        if (other.gameObject.CompareTag("TurboAdd"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(getTurboAudioClip);

            uiScript.IncreaseTurboBoost();

            Debug.Log("Player has collected turbo power");
        }
        if (other.gameObject.CompareTag("TurboInstant"))
        {
            playerAudio.PlayOneShot(useTurboAudioClip);

            //move player forward on z a bit
            //speed up scrolling BG
            //addforce to a layer of game objects? 
            //slow down NPC if playing tag?

            Debug.Log("Player has gotten an instant turbo boost");
        }

        //TEST - WORKS: try to get triggers from being called more than once
        StartCoroutine(Reset());
    }

    private IEnumerator StartCounter()
    {
        float countDown = 10f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                //Debug.Log(i++);
                countDown -= Time.smoothDeltaTime;
                starAuraParticle.SetActive(true);

                yield return null;
            }
        }

        if (countDown < 0)
        {
            starAuraParticle.SetActive(false);
            uiScript.StopSpaceCurrent();

            yield return null;
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    public void ShowSurprise()
    {
        alertParticle.Play();
    }

    public void ShowLove()
    {
        heartParticle.Play();
    }

}
