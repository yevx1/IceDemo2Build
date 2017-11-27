using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Disabled : MonoBehaviour {


   public Button button;


    public void ButtonHasBeenPressed()
    {
        button.interactable = false;
    }
}
