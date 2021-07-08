using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//these allow for system Save and Loads
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float points;

    public bool showPlayer = false;

    public bool useTallyScreen0 = false;

    //--------These are Values so Player can Have Multiple Save Slots------\\
    public int gameSaveNumber;


    //--------These are Temporary Values to Store for Each Individual Level------\\
    public float objectSpeed0 = 120f;

    public int objectCount0;
    public int objectCount1;
    public int objectCount2;
    public int objectCount3;
    public int objectCount4;
    public int objectCount5;
    public int objectCount6;
    public int objectCount7;

    public int objectCountSpecial;


    //--------These are Saved Values to Store for the Player's Inventory------\\
    public int xobjectCount0;
    public int xobjectCount1;
    public int xobjectCount2;
    public int xobjectCount3;
    public int xobjectCount4;
    public int xobjectCount5;
    public int xobjectCount6;
    public int xobjectCount7;

    //--------These are Saved Values to Store what the Player has Unlocked------\\
    public bool unlockedItemCatch;
    public bool foundAllSpecialPickups0;


    private void Awake()
    {
        //this makes the game manager stay and not get destroyed when transitioning scenes
        

        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            //since this means there is already a game manager assigned as "instance"
            Destroy(this.gameObject);
        }

    }




    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




    //possibly CanDelete if I get it to a one-scene game with the space current and UFO
    public void StartSpaceCurrent()
    {
        Debug.Log("Empty function");
    }
    public void StartItemCatch()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitUFO()
    {
        ClearAllObjectCounts();
    }

    public void ClearAllObjectCounts()
    {
        objectCount0 = 0;
        objectCount1 = 0;
        objectCount2 = 0;
        objectCount3 = 0;
        objectCount4 = 0;
        objectCount5 = 0;
        objectCount6 = 0;
        objectCount7 = 0;
        objectCountSpecial = 0;
    }

    public void ClearAllPoints()
    {
        points = 0;

    }

    public void Object0Count(int incrememtByThis) { objectCount0 += incrememtByThis; }
    public void Object1Count(int incrememtByThis) { objectCount1 += incrememtByThis; }
    public void Object2Count(int incrememtByThis) { objectCount2 += incrememtByThis; }
    public void Object3Count(int incrememtByThis) { objectCount3 += incrememtByThis; }
    public void Object4Count(int incrememtByThis) { objectCount4 += incrememtByThis; }
    public void Object5Count(int incrememtByThis) { objectCount5 += incrememtByThis; }
    public void Object6Count(int incrememtByThis) { objectCount6 += incrememtByThis; }
    public void Object7Count(int incrememtByThis) { objectCount7 += incrememtByThis; }
    public void ObjectSpecialCount(int incrememtByThis) { objectCountSpecial += incrememtByThis; }


    public void NewGame()
    {
        //gameSaveNumber = n ++;
        // find data files and see if i can get the index number Application.persistentDataPath.;

        //Debug.Log(indexNumber)
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //where to store the data; will work on all devices except web
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo" + gameSaveNumber + ".dat");

        PlayerData data = new PlayerData();
        data.points = points;

        data.xobjectCount0 = xobjectCount0;
        data.xobjectCount1 = xobjectCount1;
        data.xobjectCount2 = xobjectCount2;
        data.xobjectCount3 = xobjectCount3;
        data.xobjectCount4 = xobjectCount4;
        data.xobjectCount5 = xobjectCount5;
        data.xobjectCount6 = xobjectCount6;
        data.xobjectCount7 = xobjectCount7;

        data.unlockedItemCatch = unlockedItemCatch;
        data.foundAllSpecialPickups0 = foundAllSpecialPickups0;


        Debug.Log("Player saved session and has " + data.points + " points saved");

        //write the data to the file
        bf.Serialize(file, data);
        file.Close();

        //TODO: make web-usable save version with PlayerPrefs unitl i can research a better way
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/playerInfo.dat";

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            //this takes the data from the file, or Deserializes it:
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            points = data.points;

            xobjectCount0 = data.xobjectCount0;
            xobjectCount1 = data.xobjectCount1;
            xobjectCount2 = data.xobjectCount2;
            xobjectCount3 = data.xobjectCount3;
            xobjectCount4 = data.xobjectCount4;
            xobjectCount5 = data.xobjectCount5;
            xobjectCount6 = data.xobjectCount6;
            xobjectCount7 = data.xobjectCount7;

            unlockedItemCatch = data.unlockedItemCatch;
            foundAllSpecialPickups0 = data.foundAllSpecialPickups0;



            Debug.Log("Player loaded points and has " + data.points + " points saved");
        }
        else
        {
            Debug.LogError("File not found in " + path);
            
        }
    }
}

//this works for float, int, bool, and string. For other things XML or JSON might be better for things like colors and gameobjects?
[Serializable]
class PlayerData
{
    public float points;

    //--------These are Saved Values to Store for the Player's Inventory------\\
    public int xobjectCount0;
    public int xobjectCount1;
    public int xobjectCount2;
    public int xobjectCount3;
    public int xobjectCount4;
    public int xobjectCount5;
    public int xobjectCount6;
    public int xobjectCount7;

    //--------These are Saved Values to Store Player has Unlocked------\\
    public bool unlockedItemCatch;
    public bool foundAllSpecialPickups0;

}
