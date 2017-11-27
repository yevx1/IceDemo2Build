using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ScoreboardCollision : MonoBehaviour
    {
        ScoreboardInputField gunGame;
        ScoreboardInputField archerGame;
        // Use this for initialization
        void Start()
        {
            gunGame = GameObject.Find("IceTeaGunGame").GetComponent<ScoreboardInputField>();
            archerGame = GameObject.Find("IceTeaArcherGame").GetComponent<ScoreboardInputField>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.CompareTag("targetCan"))
            {
                GetComponentInParent<ScoreboardInputField>().counter++;
            }
            if (collision.gameObject.CompareTag("targetGun"))
            {
               gunGame.counter++;
            }
            if (collision.gameObject.CompareTag("targetArcher"))
            {
                archerGame.counter++;
            }

            else
            {
                return;
            }



        }
    }
}
