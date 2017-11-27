using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : MonoBehaviour {


    public Animator switchAnimator;
    public bool isTriggered;

	// Use this for initialization
	void Start () {
        //switchAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void FlipTheSwitch()
    {
        isTriggered = true;
        switchAnimator.SetTrigger("FlipSwitch");
    }
}
