using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MovePlatform : MonoBehaviour {

    public GameObject colliderFloor;

    public GameObject lightOutside;
    public GameObject audioPlatformMovement;

    public Transform enteringStartPositionGO;
    public Transform enteringStop1;
    public Transform enteringStop2;
    public Transform enteringStopFinal;
    float StartTime;
    float TotalDistanceToDestination;
    private bool enteringstartTheElevator;
    
    private bool enteringstop1Reached;
    private bool enteringstop2Reached;
    private bool enteringstopFinalReached;
    private bool checkStartTime;
    private bool leavingstartTheElevator;
    private bool leavingstop2Reached;
    private bool leavingstop1Reached;

    private ButtonManager bManager;

    private void Start()
    {
        bManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        
    }
    private void Update()
    {
        if (enteringstartTheElevator)
        {
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStartPositionGO.position, enteringStop1.position, journeyFraction * 5);
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStop1.position.x;
            float yPoint1 = enteringStop1.position.y;
            float zPoint1 = enteringStop1.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1)<0.01 && Mathf.Abs(z - zPoint1)<0.01)
            {
                transform.position = enteringStop1.position;
                enteringstop1Reached = true;
                enteringstartTheElevator = false;
                checkStartTime = true;
            }
        }

       
        if (enteringstop1Reached)
        {
            if (checkStartTime)
            {
            StartTime = Time.time;
            TotalDistanceToDestination = Vector3.Distance(enteringStop1.position, enteringStop2.position);
                checkStartTime = false;
            }
            
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStop1.position, enteringStop2.position, journeyFraction *2 );
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStop2.position.x;
            float yPoint1 = enteringStop2.position.y;
            float zPoint1 = enteringStop2.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1) < 0.01 && Mathf.Abs(z - zPoint1) < 0.01)
            {
                transform.position = enteringStop2.position;
                enteringstop2Reached = true;
                enteringstop1Reached = false;
                checkStartTime = true;
            }
        }
       
        if (enteringstop2Reached)
        {
            if (checkStartTime )
            {
            StartTime = Time.time;
            TotalDistanceToDestination = Vector3.Distance(enteringStop2.position, enteringStopFinal.position);
                checkStartTime = false;

            }
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStop2.position, enteringStopFinal.position, journeyFraction );
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStopFinal.position.x;
            float yPoint1 = enteringStopFinal.position.y;
            float zPoint1 = enteringStopFinal.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1) < 0.01 && Mathf.Abs(z - zPoint1) < 0.01)
            {
                transform.position = enteringStopFinal.position;
                enteringstop2Reached = false;
                enteringstopFinalReached = true;
                
            }
        }
        if (enteringstopFinalReached)
        {     
            
                bManager.NextButton();
                enteringstopFinalReached = false;
            audioPlatformMovement.SetActive(false);


        }

        if (leavingstartTheElevator)
        {
            audioPlatformMovement.SetActive(true);
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStopFinal.position, enteringStop2.position, journeyFraction * 3);
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStop2.position.x;
            float yPoint1 = enteringStop2.position.y;
            float zPoint1 = enteringStop2.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1) < 0.01 && Mathf.Abs(z - zPoint1) < 0.01)
            {
                transform.position = enteringStop2.position;
                leavingstop2Reached = true;
                leavingstartTheElevator = false;
                checkStartTime = true;
            }
        }

        if (leavingstop2Reached)
        {
            if (checkStartTime)
            {
                StartTime = Time.time;
                TotalDistanceToDestination = Vector3.Distance(enteringStop2.position, enteringStop1.position);
                checkStartTime = false;
            }

            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStop2.position, enteringStop1.position, journeyFraction * 3);
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStop1.position.x;
            float yPoint1 = enteringStop1.position.y;
            float zPoint1 = enteringStop1.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1) < 0.01 && Mathf.Abs(z - zPoint1) < 0.01)
            {
                transform.position = enteringStop1.position;
                leavingstop1Reached = true;
                leavingstop2Reached = false;
                checkStartTime = true;
            }
        }
        if (leavingstop1Reached)
        {
            if (checkStartTime)
            {
                StartTime = Time.time;
                TotalDistanceToDestination = Vector3.Distance(enteringStop1.position, enteringStartPositionGO.position);
                checkStartTime = false;

            }
            float currentDuration = Time.time - StartTime;
            float journeyFraction = currentDuration / TotalDistanceToDestination;
            transform.position = Vector3.Lerp(enteringStop1.position, enteringStartPositionGO.position, journeyFraction * 3);
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float xPoint1 = enteringStartPositionGO.position.x;
            float yPoint1 = enteringStartPositionGO.position.y;
            float zPoint1 = enteringStartPositionGO.position.z;
            if (Mathf.Abs(x - xPoint1) < 0.01 && Mathf.Abs(y - yPoint1) < 0.01 && Mathf.Abs(z - zPoint1) < 0.01)
            {
                transform.position = enteringStartPositionGO.position;
                enteringstop2Reached = false;
                lightOutside.SetActive(false);
                //enteringstopFinalReached = true;
                colliderFloor.tag = "floor";

            }
        }
       
    }

    public void StartPlatformMovement()
    {
        lightOutside.SetActive(true);
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(enteringStartPositionGO.position, enteringStopFinal.position);
        enteringstartTheElevator = true;
    }
    public void LeavePlatformMovement()
    {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(enteringStopFinal.position, enteringStartPositionGO.position);
        leavingstartTheElevator = true;
    }
}
