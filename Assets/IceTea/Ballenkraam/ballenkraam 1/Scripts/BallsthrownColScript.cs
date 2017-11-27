using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class BallsthrownColScript : MonoBehaviour
    {

        private int counter = 0;
        private ButtonManager bManager;

        private void Start()
        {
            bManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        }

        private void Update()
        {
            if (counter >= 5)
            {
                bManager.NextButton();
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("ball"))
            {
                counter++;
            }
        }

    }
}
