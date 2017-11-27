using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour {


    public Transform StartPositionGO;
    public Transform EndPositionGO;
    float StartTime;
    float TotalDistanceToDestination;




	// Use this for initialization
	void Start () {
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(StartPositionGO.position, EndPositionGO.position);
	}
	
	// Update is called once per frame
	void Update () {
        float currentDuration = Time.time - StartTime;
        float journeyFraction = currentDuration / TotalDistanceToDestination;
        transform.position = Vector3.Lerp(StartPositionGO.position, EndPositionGO.position, journeyFraction);
	}
}
