using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private IEnumerator coroutine0;
    private IEnumerator coroutine1;

    public SpaceCurrentUIController spaceCurrentUIScript;


    private AudioSource playerAudio;


    [SerializeField] GameObject playerGameObject;
    [SerializeField] GameObject ufoCockpitGameObject;
    [SerializeField] GameObject ufoTankBGGameObject;
    [SerializeField] GameObject spaceCurrentGameObject;



    public bool tutorialMode;
    public bool totalsAddedToPoints;


    [SerializeField] OpenCloseButton totalsScript;
    [SerializeField] OpenCloseButton canvasScript;




    [SerializeField] AudioClip tallySound0;
    [SerializeField] AudioClip totalSound0;
    [SerializeField] AudioClip buttonSound0;
    [SerializeField] AudioClip deniedSound0;
    [SerializeField] AudioClip unlockSound0;
    [SerializeField] AudioClip loadSound0;
    [SerializeField] AudioClip saveSound0;

    public List<Texture> playerPortraits;
    [SerializeField] Sprite blankUserPic;

    [SerializeField] TextMeshProUGUI playerPoints;
    [SerializeField] GameObject playerPointsGameObject;

    //--------Help Panels / Tutorials ------------\\
    [SerializeField] GameObject tutorialPanels;
    [SerializeField] GameObject infoPanels;

    //--------Radial Meters - Directional------------\\
    [SerializeField] GameObject upDirectionImage;
    [SerializeField] GameObject leftDirectionImage;
    [SerializeField] GameObject rightDirectionImage;
    [SerializeField] GameObject downDirectionImage;
    


     //--------Space Current------------\\
    [SerializeField] GameObject objectSpawner0;
    [SerializeField] GameObject obstacleSpawner0;
    [SerializeField] GameObject obstacleSpawnerS;

    [SerializeField] GameObject crossHairGameObject;

    //--------End Tally Panel - Space Current------------\\
    [SerializeField] GameObject endScorePanel;
    public List<TextMeshProUGUI> pointTallyLine;
    public List<TextMeshProUGUI> pointTotal;
    [SerializeField] List<int> objectValue;


    [SerializeField] TextMeshProUGUI scoreTotalName;
    [SerializeField] TextMeshProUGUI scoreTotalNumber;
    [SerializeField] GameObject totalsScreenIcon;
    [SerializeField] GameObject anomalousEnergyIcon;

    [SerializeField] GameObject anomalousEnergyUnlockedGameObject;


    //--------Dialogue Varibles------------\\

    [SerializeField] TextMeshProUGUI npcDialogueMssge;
    [SerializeField] GameObject  emptyNpcPic;

    [SerializeField] TextMeshProUGUI playerDialogueMssge;
    [SerializeField] GameObject npcName;

    //--------Mission Panel------------\\

    [SerializeField] GameObject missionPanel;


    [SerializeField] GameObject unlockItemCatchPanel;
    [SerializeField] GameObject itemCatchPanel;

    [SerializeField] GameObject foundAllItemsSpaceCurrent0;


    [SerializeField] GameObject tankOfObjects3D;
    [SerializeField] GameObject emptyCockpitGameobject;

    [SerializeField] GameObject catMissionsIcon;



    //--------Message Panel------------\\
    [SerializeField] GameObject message0GameObject;
    [SerializeField] GameObject catChatIcon;

    [SerializeField] GameObject shipPanelIcon;
    [SerializeField] GameObject allUIiconsGameObject;



    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        UpdatePlayerStatus();

        SetPlayerDialogueBox("A trivial task. Please extend a communication if services are required again.");
        playerPoints.text = GameManager.instance.points.ToString();

        //TODO: testing debugging only, can delete this I think?
        if (GameManager.instance.useTallyScreen0 == true)
        {
            EndTallySpaceCurrent();
            ShowAbductionTANK();
            Debug.Log("Use Tally0 is st to true");

        }


        //TEST: does this suffice, or do I need more to make sure the panels show correctly?
        if (!GameManager.instance.unlockedItemCatch)
        {
            itemCatchPanel.SetActive(false);
            unlockItemCatchPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Directional Movement Indicators for UI
    // up ^
    public void ShowMovingUpIndicator()
    {
        upDirectionImage.SetActive(true);
    }
    public void HideMovingUpIndicator()
    {
        upDirectionImage.SetActive(false);
    }

    // left < 
    public void ShowMovingLeftIndicator()
    {
        leftDirectionImage.SetActive(true);
    }
    public void HideMovingLeftIndicator()
    {
        leftDirectionImage.SetActive(false);
    }

    // right >
    public void ShowMovingRightIndicator()
    {
        rightDirectionImage.SetActive(true);
    }
    public void HideMovingRightIndicator()
    {
        rightDirectionImage.SetActive(false);
    }

    // right >
    public void ShowMovingDownIndicator()
    {
        downDirectionImage.SetActive(true);
    }
    public void HideMovingDownIndicator()
    {
        downDirectionImage.SetActive(false);
    }


    public void ShowCrossHair()
    {
        crossHairGameObject.SetActive(true);
    }
    public void HideCrossHair()
    {
        crossHairGameObject.SetActive(false);
    }







    public void ShowCockpit()
    {
        emptyCockpitGameobject.SetActive(true);
    }

    public void HideCockpit()
    {
        emptyCockpitGameobject.SetActive(false);
    }

    public void ShowCatChatIcon()
    {
            catChatIcon.SetActive(true);
    }

    public void HideCatChatIcon()
    {
        catChatIcon.SetActive(false);
    }

    public void ShowMissisonsIcon()
    {
        catMissionsIcon.SetActive(true);
    }

    public void HideMissisonsIcon()
    {
        catMissionsIcon.SetActive(false);
    }

    public void ShowTotalsIcon()
    {
        totalsScreenIcon.SetActive(true);
    }

    public void HideTotalsIcon()
    {
        totalsScreenIcon.SetActive(false);
    }

    public void ShowShipPanelIcon()
    {
        shipPanelIcon.SetActive(true);
    }
    public void HideShipPanelIcon()
    {
        shipPanelIcon.SetActive(false);
    }

    public void ShowUIicons()
    {
        allUIiconsGameObject.SetActive(true);
    }
    public void HideUIicons()
    {
        allUIiconsGameObject.SetActive(false);
    }




    public void ShowSpaceCurrentBG0()
    {
        spaceCurrentGameObject.SetActive(true);
    }
    public void HideSpaceCurrentBG0()
    {
        spaceCurrentGameObject.SetActive(false);
    }

    public void ShowTankBG()
    {
        ufoTankBGGameObject.SetActive(true);
    }
    public void HideTankBG()
    {
        ufoTankBGGameObject.SetActive(false);
    }

    public void ShowSpecialEnergy3DGameObject()
    {
        anomalousEnergyIcon.SetActive(true);
    }
    public void HideSpecialEnergy3DGameObject()
    {
        anomalousEnergyIcon.SetActive(false);
    }


    //check to make sure all the stuff player unlocked in saved game shows properly
    public void MissionsPanelsCheck()
    {
       //if level has been unlocked in saved game, load that info
        if (GameManager.instance.unlockedItemCatch)
        {
            itemCatchPanel.SetActive(true);
            unlockItemCatchPanel.SetActive(false);
        }
        //if level has been NOT been unlocked in saved game, load that info
        if (!GameManager.instance.unlockedItemCatch)
        {
            itemCatchPanel.SetActive(false);
            unlockItemCatchPanel.SetActive(true);
        }

        if (GameManager.instance.foundAllSpecialPickups0)
        {
            foundAllItemsSpaceCurrent0.SetActive(true);
        }
        if (!GameManager.instance.foundAllSpecialPickups0)
        {
            foundAllItemsSpaceCurrent0.SetActive(false);
        }
    }

    public void LoadSpaceCurrentScene0()
    {
        ShowPlayer();
        objectSpawner0.SetActive(true);
        obstacleSpawner0.SetActive(true);
        playerPointsGameObject.SetActive(false);
        ShowSpecialSpawner0();
        spaceCurrentUIScript.StartSpaceCurrent();
        HideUIicons();

    }



    public void ShowSpecialSpawner0()
    {
        obstacleSpawnerS.SetActive(true);
    }
    public void HideSpecialSpawner0()
    {
        obstacleSpawnerS.SetActive(false);
    }



    public void UnlockItemCatchScene()
    {
        if(GameManager.instance.points > 400)
        {
            GameManager.instance.points = GameManager.instance.points - 400;
            unlockItemCatchPanel.SetActive(false);
            itemCatchPanel.SetActive(true);
            playerAudio.PlayOneShot(unlockSound0);
            RefreshPlayerPointsTextUI();
            GameManager.instance.unlockedItemCatch = true;
        }
    }
    public void LoadItemCatchScene()
    {
        GameManager.instance.StartItemCatch();
    }

    public void UnlockSound0()
    {
        playerAudio.PlayOneShot(unlockSound0);
    }

    public void ButtonSound0()
    {
        playerAudio.PlayOneShot(buttonSound0);
    }

    public void DeniedSound0()
    {
        playerAudio.PlayOneShot(deniedSound0);
    }

    public void EndTallySpaceCurrent()
    {
        tankOfObjects3D.SetActive(true);
        ShowSpecialEnergy3DGameObject();
        objectSpawner0.SetActive(false);
        obstacleSpawner0.SetActive(false);

        playerPointsGameObject.SetActive(true);
        missionPanel.SetActive(false);
        endScorePanel.SetActive(true);
        ShowAbductionTANK();
        ShowUIicons();

        HidePlayer();
        HideCrossHair();



        totalsScript.GetComponent<Animator>().SetTrigger("OpenPanel");
        canvasScript.GetComponent<Animator>().SetTrigger("ClosePanel");


        coroutine0 = TimedTextShow(pointTallyLine[0], "x " + objectValue[0] + " x " + GameManager.instance.objectCount0, .25f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[0]," = " + CalculateLineSum(0, GameManager.instance.objectCount0).ToString(), .5f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTallyLine[1], "x " + objectValue[1] + " x " + GameManager.instance.objectCount1, .75f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[1], " = " + CalculateLineSum(1, GameManager.instance.objectCount1).ToString(), 1.0f);
        StartCoroutine(coroutine0);

        coroutine0 = TimedTextShow(pointTallyLine[2], "x " + objectValue[2] + " x " + GameManager.instance.objectCount2, 1.25f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[2], " = " + CalculateLineSum(2, GameManager.instance.objectCount2).ToString(), 1.5f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTallyLine[3], "x " + objectValue[3] + " x " + GameManager.instance.objectCount3, 1.75f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[3], " = " + CalculateLineSum(3, GameManager.instance.objectCount3).ToString(), 2.0f);
        StartCoroutine(coroutine0);

        coroutine0 = TimedTextShow(pointTallyLine[4], "x " + objectValue[4] + " x " + GameManager.instance.objectCount4, 2.25f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[4], " = " + CalculateLineSum(4, GameManager.instance.objectCount4).ToString(), 2.5f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTallyLine[5], "x " + objectValue[5] + " x " + GameManager.instance.objectCount5, 2.75f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShow(pointTotal[5], " = " + CalculateLineSum(5, GameManager.instance.objectCount5).ToString(), 3.0f);
        StartCoroutine(coroutine0);


        //-----SPECIAL ITEM SECTION-----\\
        coroutine0 = TimedTextShow(pointTallyLine[7], CalculateLineSum(7, GameManager.instance.objectCountSpecial).ToString() + " of 10", 3.25f);
        StartCoroutine(coroutine0);
        if(GameManager.instance.objectCountSpecial >= 10)
        {

            if(GameManager.instance.foundAllSpecialPickups0 == false)
            {
            //NOTE: right now the animation is set to
            //  go from 0 to 100% visible after X seconds in the defaul anim,
            //  if it doesnt line up properly adjust
            anomalousEnergyUnlockedGameObject.SetActive(true);
            GameManager.instance.foundAllSpecialPickups0 = true;
                //get the timing so it sounds off when the text pops up, look in the animation for the piece of text
            Invoke("UnlockSound0", 3.5f);

            //the badge for the missions panel
            foundAllItemsSpaceCurrent0.SetActive(true);
            }
            else if (GameManager.instance.foundAllSpecialPickups0 == true)
            {
                anomalousEnergyUnlockedGameObject.SetActive(false);

                foundAllItemsSpaceCurrent0.SetActive(true);
                Debug.Log("all 10 anomalous objects have already been found");
            }
            else { return; }
        }


        coroutine0 = TimedTextShow(scoreTotalName, "Total: ", 3.5f);
        StartCoroutine(coroutine0);
        coroutine0 = TimedTextShowTotal(scoreTotalNumber," = " + CalculateTotal().ToString(), 4.0f);
        StartCoroutine(coroutine0);

        if (GameManager.instance.useTallyScreen0 == true)
        {
            totalsAddedToPoints = false;

            coroutine0 = ShowPlayerPoints(4.0f);
            StartCoroutine(coroutine0);
        }

    }

    public void StopEndTallying()
    {
        StopAllCoroutines();
        coroutine1 = SetAllTallyLinesInactive();
        StartCoroutine(coroutine1);

    }
    IEnumerator SetAllTallyLinesInactive()
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < pointTallyLine.Count; i++)
        {
            pointTallyLine[i].gameObject.SetActive(false);
        }
        for (int j = 0; j < pointTotal.Count; j++)
        {
            pointTotal[j].gameObject.SetActive(false);
        }
    }
    public void HideEndTallys()
    {
        endScorePanel.SetActive(false);
        GameManager.instance.useTallyScreen0 = false;

    }
    public void ShowEndTallysAgain()
    {
        endScorePanel.SetActive(true);
    }

    public void ShowPlayer()
    {
        GameManager.instance.showPlayer = true;
        playerGameObject.SetActive(true);
        ufoCockpitGameObject.SetActive(false);
        ufoTankBGGameObject.SetActive(false);
        spaceCurrentGameObject.SetActive(true);
    }
    public void HidePlayer()
    {

        GameManager.instance.showPlayer = false;
        playerGameObject.SetActive(false);
        ufoCockpitGameObject.SetActive(true);
        ufoTankBGGameObject.SetActive(true);
        spaceCurrentGameObject.SetActive(false);

        //TODO: use animations instead of SetActive
        Debug.Log("Player should be hidden now");
    }
    public void UpdatePlayerStatus()
    {
        if(GameManager.instance.showPlayer == true) {
            ShowPlayer();

        }
        if (GameManager.instance.showPlayer == false)
        {
            HidePlayer();
        }
        else
        {
            return;
        }
    }

    public void ShowAbductionTANK()
    {
        tankOfObjects3D.SetActive(true);

    }
    public void HideAbductionTANK()
    {
        tankOfObjects3D.SetActive(false);

    }



    public void ShowMessage0GameObject()
    {
        message0GameObject.SetActive(true);

    }
    public void HideMessage0GameObject()
    {
        message0GameObject.SetActive(false);

    }

    public void ShowTutorials()
    {
        tutorialMode = true;
        tutorialPanels.SetActive(true);

        //TODO: use animations instead of SetActive
        Debug.Log("tutorials should be visible now, should change to animations next");
    }
    public void HideTutorials()
    {

        tutorialMode = false;
        tutorialPanels.SetActive(false);


        //TODO: use animations instead of SetActive
        Debug.Log("tutorials should be hidden now");
    }

    public void UpdateTutorialModeStatus()
    {

        if (tutorialMode == true)
        {
            ShowPlayer();

        }
        if (tutorialMode == false)
        {
            HidePlayer();
        }
        else
        {
            return;
        }
    }



    public void UpdatePlayerPoints()
    {
        float pointsToAdd = CalculateTotal();
        GameManager.instance.points = GameManager.instance.points + pointsToAdd;

        playerPoints.text = GameManager.instance.points.ToString();
        totalsAddedToPoints = true;
    }
    public void DisplayPlayerPoints()
    {
        //so if player closes panel before the tallying is done, the points are added to their space points
        // also so it doesn't add the points twice
        if (!totalsAddedToPoints)
        {
            UpdatePlayerPoints();
        }
        else if (totalsAddedToPoints)
        {
            return;
        }
    }

    public void RefreshPlayerPointsTextUI()
    {
        playerPoints.text = GameManager.instance.points.ToString();
    }


    public float CalculateLineSum(int index, int objectCount)
    {
        float linesum = objectValue[index] * objectCount;

        return linesum;
    }

    IEnumerator TimedTextShow(TextMeshProUGUI textVar, string text, float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);

        playerAudio.PlayOneShot(tallySound0);

        textVar.gameObject.SetActive(true);
        textVar.text = text;

    }

    IEnumerator TimedTextShowTotal(TextMeshProUGUI textVar, string text, float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);

        playerAudio.PlayOneShot(totalSound0);

        textVar.gameObject.SetActive(true);
        textVar.text = text;

    }
    IEnumerator ShowPlayerPoints(float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);

        playerAudio.PlayOneShot(totalSound0);

        UpdatePlayerPoints();

    }

    public float CalculateTotal()
    {
        //I know, barbaric:
        float sum0 = CalculateLineSum(0, GameManager.instance.objectCount0);
        float sum1 = CalculateLineSum(1, GameManager.instance.objectCount1);
        float sum2 = CalculateLineSum(2, GameManager.instance.objectCount2);
        float sum3 = CalculateLineSum(3, GameManager.instance.objectCount3);
        float sum4= CalculateLineSum(4, GameManager.instance.objectCount4);
        float sum5= CalculateLineSum(5, GameManager.instance.objectCount5);
        //TODO: bonus calc: float sum6 = bonusValue x objectCount6;
        //TODO: bonus calc: float sum7 = otherBonusValue x objectCount7;



        float endSum = sum0 + sum1 + sum2 + sum3 + sum4 + sum5;

        return endSum;
    }

    public void SetNPCDialogueBox(string npcString)
    {
        npcDialogueMssge.text = npcString;
    }

    public void ClearMessagePanel()
    {
        //TODO:
        //  add a neutral meowmers portrait,
        //  clear the NPC panel to 'no incoming messages' or something.
        //  Like a TV fuzz for the NPC image
        npcDialogueMssge.text = "- No incoming messages -";
        emptyNpcPic.SetActive(true);
        playerDialogueMssge.text = " ";
        npcName.SetActive(false);
        missionPanel.SetActive(true);

    }

    public void TotalsGameobjectHide()
    {
        endScorePanel.SetActive(false);
        tankOfObjects3D.SetActive(false);
        //canDelete, doesnt work as is. doesnt find the script
        totalsScript.ClosePanel();

    }


    public void CallGameSave()
    {
        GameManager.instance.Save();
        playerAudio.PlayOneShot(saveSound0);
    }

    public void CallGameLoad()
    {
        GameManager.instance.Load();
        MissionsPanelsCheck();
        playerAudio.PlayOneShot(loadSound0);
    }


    //-------------Common Player Reactions------------\\
    public void SetPlayerDialogueBox(string playerString)
    {
        playerDialogueMssge.text = playerString;
    }

}
