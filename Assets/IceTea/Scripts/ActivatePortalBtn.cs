using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActivatePortalBtn : MonoBehaviour {
    public GameObject audioGate;
    public GameObject portal;
    Animator ringsAnimation;
	// Use this for initialization
	void Start () {
        ringsAnimation = GetComponent<Animator>();
        ringsAnimation.SetBool("ringsTurn",false);
        if (portal != null)
        {
            portal.SetActive(false);
        }
        if (audioGate != null)
        {
            audioGate.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivatePortal()
    {
        ringsAnimation.SetBool("ringsTurn", true);
        if (portal != null)
        {

        portal.SetActive(true);
        }
        if (audioGate != null)
        {
            audioGate.SetActive(true);
        }
    }

    public void DisactivatePortal()
    {
        ringsAnimation.SetBool("ringsTurn", false);
        if (portal != null)
        {

            portal.SetActive(false);
        }
        if (audioGate != null)
        {
            audioGate.SetActive(true);
        }
    }
}
