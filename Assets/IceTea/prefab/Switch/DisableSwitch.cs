using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSwitch : MonoBehaviour {

    public Button button;
    public InputField inputfieldText;


    public void ButtonHasBeenPressed()
    {
        button.interactable = false;
        inputfieldText.text= "Activated";
        inputfieldText.transform.Find("Text").GetComponent<Text>().color = Color.red;
    }


    // Use this for initialization
    void Start () {
        //inputfieldText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
