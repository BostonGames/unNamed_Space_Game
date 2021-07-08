using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ComputerLogScript : MonoBehaviour
{

    [SerializeField] GameObject emoteNeutral;
    [SerializeField] GameObject emoteExclaimation;
    [SerializeField] GameObject emoteDotDotDot;
    [SerializeField] GameObject emoteHappyAffection;
    [SerializeField] GameObject emoteLaughing;
    [SerializeField] GameObject emoteAnger;
    [SerializeField] GameObject emoteLooking;
    [SerializeField] GameObject emoteO_O;
    [SerializeField] GameObject emoteQuesitonMark;
    [SerializeField] GameObject emoteSerious;
    [SerializeField] GameObject emoteShock;
    [SerializeField] GameObject emoteSuspicion;
    [SerializeField] GameObject emoteXD;

    [SerializeField] TextMeshProUGUI computerLogText;
    private Animator animator;

    public



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComputerSaysThis(string message)
    {

        computerLogText.text = "// " + message;
        OpenPanel();
    }

    public void ClearComputerMessage()
    {
        computerLogText.text = "";
    }

    public void OpenPanel()
    {
        animator.SetTrigger("OpenPanel");
    }



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
    public void ShowThisEmotePic(int i)
    {
        //Neutral / Empty
        if (i == 0)

        {
            emoteNeutral.SetActive(true);

            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);
        }
        //Exclaimation
        if (i == 1)

        {
            emoteExclaimation.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //DotDotDot
        if (i == 2)

        {
            emoteDotDotDot.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //HappyAffection
        if (i == 3)

        {
            emoteHappyAffection.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //Laughing
        if (i == 4)

        {
            emoteLaughing.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //Anger
        if (i == 5)

        {
            emoteAnger.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //  Looking
        if (i == 6)

        {
            emoteLooking.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //  O_O
        if (i == 7)

        {
            emoteO_O.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        // Quesiton Mark ?
        if (i == 8)

        {
            emoteQuesitonMark.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //Serious
        if (i == 9)

        {
            emoteSerious.SetActive(true);

            HideThisEmotePic(0);
            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(10);
            HideThisEmotePic(11);
            HideThisEmotePic(12);

        }
        //Shock
        if (i == 10)

        {
            emoteShock.SetActive(true);

            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(0);
            HideThisEmotePic(11);
            HideThisEmotePic(12);
        }
        //Suspicion
        if (i == 11)

        {
            emoteSuspicion.SetActive(true);

            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(0);
            HideThisEmotePic(12);
        }
        //XD
        if (i == 12)

        {
            emoteSuspicion.SetActive(true);

            HideThisEmotePic(1);
            HideThisEmotePic(2);
            HideThisEmotePic(3);
            HideThisEmotePic(4);
            HideThisEmotePic(5);
            HideThisEmotePic(6);
            HideThisEmotePic(7);
            HideThisEmotePic(8);
            HideThisEmotePic(9);
            HideThisEmotePic(10);
            HideThisEmotePic(0);
            HideThisEmotePic(11);
        }






    }

    public void HideThisEmotePic(int i)
    {
        //Neutral
        if (i == 0)

        {
            emoteNeutral.SetActive(false);
        }
        //Exclaimation
        if (i == 1)

        {
            emoteExclaimation.SetActive(false);
        }
        //DotDotDot
        if (i == 2)

        {
            emoteDotDotDot.SetActive(false);
        }
        //HappyAffection
        if (i == 3)

        {
            emoteHappyAffection.SetActive(false);
        }
        //Laughing
        if (i == 4)

        {
            emoteLaughing.SetActive(false);
        }
        //Anger
        if (i == 5)

        {
            emoteAnger.SetActive(false);
        }
        //  Looking
        if (i == 6)

        {
            emoteLooking.SetActive(false);
        }
        //  O_O
        if (i == 7)

        {
            emoteO_O.SetActive(false);
        }
        // Quesiton Mark ?
        if (i == 8)

        {
            emoteQuesitonMark.SetActive(false);
        }
        //Serious
        if (i == 9)

        {
            emoteSerious.SetActive(false);
        }
        //Shock
        if (i == 10)

        {
            emoteShock.SetActive(false);
        }
        //Suspicion
        if (i == 11)

        {
            emoteSuspicion.SetActive(false);
        }
        //XD
        if (i == 12)

        {
            emoteSuspicion.SetActive(false);
        }

    }
}
