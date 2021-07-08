using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickyTarget : MonoBehaviour
{
    //TODO: Tidy this up:
    private GameManager gameManager;

    private ClickyGameManager clickyGameManager;
    private Rigidbody targetRb;
    [SerializeField] float minSpeed = 12.0f;
    [SerializeField] float maxSpeed = 16.0f;
    [SerializeField] float maxTorque = 10.0f;
    [SerializeField] float minX = -7.0f;
    [SerializeField] float maxX = 7.0f;
    [SerializeField] float ySpawnPos = -7.0f;

    [SerializeField] int pointValue;

    [SerializeField] ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        clickyGameManager = GameObject.Find("ClickyGameManager").GetComponent<ClickyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Destroyer" && !gameObject.CompareTag("Bad"))
        {
            clickyGameManager.ClickyGameOver();
        }

    }

    private void OnMouseDown()
    {
        if (clickyGameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            clickyGameManager.UpdateScore(pointValue);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(minX, maxX), ySpawnPos);
    }
}
