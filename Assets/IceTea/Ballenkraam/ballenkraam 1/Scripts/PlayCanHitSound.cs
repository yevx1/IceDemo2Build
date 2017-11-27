using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem
{
    public class PlayCanHitSound : MonoBehaviour
    {
        public SoundPlayOneshot collisionSound;
        
        private void Start()
        {
           
        }
        private void OnCollisionEnter(Collision collision)
        {
            
                    collisionSound.Play();
            

            
                    

                
        }
    }
}
