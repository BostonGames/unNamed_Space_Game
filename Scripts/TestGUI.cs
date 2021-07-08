using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestGUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;
    [SerializeField] TextMeshProUGUI uiText0;

    private void Update()
    {
        uiText.text = "Points: " + GameManager.instance.points.ToString();
        uiText0.text = "Object0 Count: " + GameManager.instance.xobjectCount0.ToString();
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 100, 120, 30), "Points Up"))
        {
            GameManager.instance.points += 10;
        }
        if (GUI.Button(new Rect(10, 140, 120, 30), "Points Down"))
        {
            GameManager.instance.points -= 10;
        }

        //Works for object counts as well
        if (GUI.Button(new Rect(140, 100, 120, 30), "Object0 Up"))
        {
            GameManager.instance.xobjectCount0 += 1;
        }
        if (GUI.Button(new Rect(140, 140, 120, 30), "Object0 Down"))
        {
            GameManager.instance.xobjectCount0 -= 1;
        }


        if (GUI.Button(new Rect(10, 180, 120, 30), "Save"))
        {
            GameManager.instance.Save();
        }
        if (GUI.Button(new Rect(10, 220, 120, 30), "Load"))
        {
            GameManager.instance.Load();
        }
    }
}
