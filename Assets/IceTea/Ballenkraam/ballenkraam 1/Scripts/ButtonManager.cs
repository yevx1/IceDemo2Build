using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class ButtonManager : MonoBehaviour
    {


        public GameObject StartBallenKraamButton;
        public GameObject StartGunShirtButton;
        public GameObject StartArcherButton;
        private int counter = 0 ;
       
        // Use this for initialization
        void Start()
        {
            ActivateBallenKraamButton();
               
            
        }

       

       public void NextButton()
        {
            counter++;
            if (counter == 1)
            {
                ActivateGunShirtGameButton();
                
            }
            if (counter == 2)
            {
                ActivateArcherGameButton();
            }
        }


        private void ActivateBallenKraamButton()
        {
            StartBallenKraamButton.SetActive(true);
            StartGunShirtButton.SetActive(false);
            StartArcherButton.SetActive(false);
            
        }

        private void ActivateGunShirtGameButton()
        {
            StartBallenKraamButton.SetActive(false);
            StartGunShirtButton.SetActive(true);
            StartArcherButton.SetActive(false);
            
            
        }

        private void ActivateArcherGameButton()
        {
            StartBallenKraamButton.SetActive(false);
            StartGunShirtButton.SetActive(false);
            StartArcherButton.SetActive(true);
        }


    }
}
