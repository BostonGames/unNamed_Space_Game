using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    //Note: change from +/- to change direction of scroll to match player path movement
    public float bgSpeed = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
         startPos = transform.position;
        //numbers didn't make sense, collider was not in scale units. repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        //this one iddn't work iwth all four of them, 150 was a better match in this scenario repeatWidth = transform.position.z / 1.5f;
        repeatWidth = 150f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bgSpeed);
        
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
