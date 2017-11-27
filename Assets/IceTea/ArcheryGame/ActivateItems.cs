using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActivateItems : MonoBehaviour {

    public GameObject itemPreview;
    public GameObject itemGreenOutline;

	// Use this for initialization
	void Start () {
        if (itemPreview != null)
        {
            itemPreview.SetActive(false);
        }
        if (itemGreenOutline != null)
        {
            itemGreenOutline.SetActive(true);
        }
	}

    public void StartGameButtonPressed()
    {
        if (itemPreview != null)
        {
            itemPreview.SetActive(true);
        }
        if (itemGreenOutline != null)
        {
            itemGreenOutline.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
