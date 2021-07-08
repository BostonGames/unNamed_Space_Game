using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawner : MonoBehaviour
{


    //Attempting to make projectiles move with space current particle effects
    [SerializeField] GameObject rotateAroundThisParent;
    //true/checked if you want it to roate
    public bool rotateSpawner;

    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] GameObject resource0;
    [SerializeField] GameObject resource1;
    [SerializeField] GameObject resource2;
    [SerializeField] GameObject resource3;
    [SerializeField] GameObject resource4;
    [SerializeField] GameObject resource5;



    // use for spawnTrigger somehow
    public bool isTotalsPanelActive = false;

    // constraints objects will spawn within
    [SerializeField] GameObject minXminYminZ;
    [SerializeField] GameObject maxXmaxYmaxZ;



    //--Numerical values for tank object prefabs---\\
    [SerializeField] int healthPrefabX = 0;
    [SerializeField] int shieldPrefabX = 0;
    [SerializeField] int resource0X = 0;
    [SerializeField] int resource1X = 0;
    [SerializeField] int resource2X = 0;
    [SerializeField] int resource3X = 0;
    [SerializeField] int resource4X = 0;
    [SerializeField] int resource5X = 0;




    //[SerializeField] float zSpawnPos = 0;
    [SerializeField] float spawnDelay = 0.5f;

    //CAN DELETE WHEN GAME MANAGER IS MADE:
    private void Start()
    {

        isTotalsPanelActive = true;


        ImportTotalS();
        StartSpawaningObject();

    }

    private void Update()
    {
        //zSpawnPos = gameObject.transform.position.z;
    }


    //---SPAWNER FUNCTIONS----\\

    public void ImportTotalS()
    {
        healthPrefabX = GameManager.instance.objectCount0;
        shieldPrefabX = GameManager.instance.objectCount1;
        resource0X = GameManager.instance.objectCount2;
        resource1X = GameManager.instance.objectCount3;
        resource2X = GameManager.instance.objectCount4;
        resource3X = GameManager.instance.objectCount5;
        resource4X = GameManager.instance.objectCount6;
        resource5X = GameManager.instance.objectCount7;

    }
             



    IEnumerator SpawnTarget()
    {
        //Debug canDeleteProbably fixed the infinite spawn issue
        //while (isTotalsPanelActive)
        //{
            yield return new WaitForSeconds(spawnDelay);

        float xOffset = Random.Range(minXminYminZ.transform.position.x, maxXmaxYmaxZ.transform.position.x);
        float yOffset = Random.Range(minXminYminZ.transform.position.y, maxXmaxYmaxZ.transform.position.y);
        float zOffset = Random.Range(minXminYminZ.transform.position.z, maxXmaxYmaxZ.transform.position.z);


        //---ENERGY object
        for (int i = 0;  i < healthPrefabX; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            

            Instantiate(healthPrefab, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);
        }

        //---SHIELD object
        for (int i = 0; i < shieldPrefabX; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(shieldPrefab, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }

        //---Resource0 object
        for (int i = 0; i < resource0X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource0, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }
        //---Resource1 object
        for (int i = 0; i < resource1X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource1, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }
        //---Resource2 object
        for (int i = 0; i < resource2X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource2, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }
        //---Resource3 object
        for (int i = 0; i < resource3X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource3, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }
        //---Resource4object
        for (int i = 0; i < resource4X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource4, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }
        //---Resource5 object
        for (int i = 0; i < resource5X; i++)
        {
            //Adding a Transform to rotate the projectile around to simulate movement in space
            Instantiate(resource5, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);

            //Debug.Log(i);
        }

    }

    public void StartSpawaningObject()
    {
        //isTotalsPanelActive = true;

        StartCoroutine(SpawnTarget());

    }
    public void StopSpawningObject()
    {
        //isTotalsPanelActive = false;
        StopCoroutine(SpawnTarget());
    }
}
