using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Attempting to make projectiles move with space current particle effects
    [SerializeField] GameObject rotateAroundThisParent;
    //true/checked if you want it to roate
    public bool rotateSpawner;

    public List<GameObject> objectsToSpawn;
    public bool isGameActive = false;
    public bool isDifficultySelected = false;

    // constraints objects will spawn within
    [SerializeField] float maxXpos = 17f;
    [SerializeField] float minXpos = -17f;
    [SerializeField] float maxYpos = 12.5f;
    [SerializeField] float minYpos = -1f;


    [SerializeField] float zSpawnPos;
    [SerializeField] float spawnDelay = 0.5f;

    //CAN DELETE WHEN GAME MANAGER IS MADE:
    private void Start()
    {
        if (!isDifficultySelected)
        {
            AssignLowSpawnRate();
        }

    
    }

    private void Update()
    {
        zSpawnPos = gameObject.transform.position.z;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnDelay);
            int index = Random.Range(0, objectsToSpawn.Count);

            if (rotateSpawner)
            {
                //Adding a Transform to rotate the projectile around to simulate movement in space
                Instantiate(objectsToSpawn[index], new Vector3(Random.Range(minXpos, maxXpos), Random.Range(minYpos, maxYpos), zSpawnPos), Quaternion.identity, rotateAroundThisParent.transform);
            }
            else if (!rotateSpawner)
            {
                Instantiate(objectsToSpawn[index], new Vector3(Random.Range(minXpos, maxXpos), Random.Range(minYpos, maxYpos), zSpawnPos), Quaternion.identity);
            }
        }
    }



    public void StartSpawaningObject(float difficulty)
    {
        spawnDelay /= difficulty;

        isGameActive = true;

        StartCoroutine(SpawnTarget());
        
    }
    public void StopSpawningObject()
    {
        isGameActive = false;
        StopCoroutine(SpawnTarget());
    }

    //--------DIFFICULTY BUTTONS----------\\
    public void AssignLowSpawnRate()
    {
        isDifficultySelected = true;
        StartSpawaningObject(1.0f);
    }

    public void AssignMedSpawnRate()
    {
        isDifficultySelected = true;
        StartSpawaningObject(2.0f);
    }

    public void AssignHighSpawnRate()
    {
        isDifficultySelected = true;
        StartSpawaningObject(3.0f);
    }
}
