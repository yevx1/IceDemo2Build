using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour {

    public Transform StartPositionGO;
    public Transform EndPositionGO;
    float StartTime;
    float TotalDistanceToDestination;
    private bool startTheElevator;

    private void Start()
    {
        //startTheElevator = true;
    }
    private void Update()
    {
        if (startTheElevator)
        {
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(StartPositionGO.position, EndPositionGO.position, journeyFraction);
        }
    }

    public void StartElevator()
    {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionGO.position, EndPositionGO.position);
        startTheElevator = true;
    }
}
