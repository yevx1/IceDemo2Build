using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Valve.VR.InteractionSystem
{
    public class ScoreboardInputField : MonoBehaviour
    {

        public InputField scoretext;
        public int counter = 0;



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            scoretext.text = counter.ToString();
        }
    }
}
