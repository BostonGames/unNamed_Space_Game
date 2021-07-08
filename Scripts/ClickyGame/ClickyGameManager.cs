using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickyGameManager : MonoBehaviour
{
 
    public List<GameObject> targets;
    [SerializeField] GameObject gameOverText;

    [SerializeField] GameObject retryButton;
    [SerializeField] GameObject leaveButton;

    [SerializeField] GameObject gameTitleText;
    [SerializeField] GameObject startButtons;

    [SerializeField] float spawnRate = 1.0f;

    public TextMeshProUGUI clickyScoreText;
    private int score;

    public int NPC0Quantity;
    public int Enemy0Quantity;
    public int resource0Quantity;
    public int resource1Quantity;
    public int resource2Quantity;
    public int resource3Quantity;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        //clean score slate
        resource0Quantity = 0;
        resource1Quantity = 0;
        resource2Quantity = 0;
        resource3Quantity = 0;
        NPC0Quantity = 0;
        Enemy0Quantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        clickyScoreText.text = score.ToString();
    }

    public void ClickyGameStart(float difficulty)
    {


        gameTitleText.SetActive(false);
        startButtons.SetActive(false);

        //higher difficulty number = quicker spawn rate, so more difficult to click all targets
        spawnRate /= difficulty;

        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
    }

    public void ClickyGameOver()
    {
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        leaveButton.SetActive(true);
        isGameActive = false;
    }


    //--------DIFFICULTY BUTTONS----------\\
    public void AssignLowGravity()
    {

        ClickyGameStart(1.0f);
    }

    public void AssignMedGravity()
    {
        ClickyGameStart(2.0f);
    }

    public void AssignHighGravity()
    {
        ClickyGameStart(3.0f);
    }

}
