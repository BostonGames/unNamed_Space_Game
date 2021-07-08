using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Vector3 offset;
    [SerializeField] float smoothRate;
    [Tooltip("clamp camera movement")] [SerializeField] float minXValue, maxXValue, minYValue, maxYValue;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - transform.position;
    }

    // late update so cameras position is set after all calculations
    void LateUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 newRawPos = player.position - offset;
        float newXPos = Mathf.Clamp(newRawPos.x,  minXValue, maxXValue);
        float newYPos = Mathf.Clamp(newRawPos.y, minYValue, maxYValue);
        Vector3 pos = new Vector3(newXPos, newYPos, newRawPos.z);

        // change the transform.position so that 
        //      every time the frame is called, 
        //      the currentPos will slowly move toward newPos 
        //      at the rate of smoothRate
        transform.position = Vector3.Lerp(currentPos, pos, smoothRate * Time.deltaTime);
    }
}
