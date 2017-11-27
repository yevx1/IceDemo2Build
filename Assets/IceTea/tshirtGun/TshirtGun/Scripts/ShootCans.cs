using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class ShootCans : MonoBehaviour
    {

        SteamVR_Controller controller;
        public Transform canSpawnPoint;
        public GameObject bulletCan;
        private GameObject spawnedBullet;
        //GameObject goMeshCol;
        private Transform direction2Shoot;
        public Hand controllerHand;

        //private bool isBulletFired;
        private bool isThereABullet;
        // Use this for initialization
        private bool reloadNeeded;
        private bool firstReload;
        public SoundPlayOneshot shotSound;
        public Animator triggerAnimation;
        


        void Start()
        {
            reloadNeeded = true;
            direction2Shoot = transform.Find("Directionshoot").transform;
            //triggerAnimation = transform.Find("trigger").gameObject.GetComponent<Animator>();

        }
        private void OnAttachedToHand(Hand attachedHand)
        {
            controllerHand = attachedHand;
        }
    
        //IEnumerator WaitForReload()
        //{
        //    firstReload = false;
        //    yield return new WaitForSeconds(0.5f);
        //    reloadNeeded = true;

        //}

        // Update is called once per frame
        void Update()
        {
            //if (firstReload)
            //{
            //   StartCoroutine(WaitForReload());
            //}
            //if (reloadNeeded && canSpawnPoint != null && bulletCan != null)
            //{
          
            //spawnedBullet = Instantiate(bulletCan, canSpawnPoint.position, Quaternion.identity);

            //spawnedBullet.transform.parent = gameObject.transform;
            //spawnedBullet.transform.LookAt(direction2Shoot);
            //Rigidbody rb = spawnedBullet.transform.Find("SodaMesh").gameObject.GetComponent<Rigidbody>();
            //rb.isKinematic = true;
            //rb.useGravity = false;
            //reloadNeeded = false;
            //}
            if (controllerHand != null && controllerHand.GetStandardInteractionButtonDown())
            {
                triggerAnimation.SetBool("IsTriggerPulled", true);
            }
            if (controllerHand != null && controllerHand.GetStandardInteractionButtonUp())
            {
                triggerAnimation.SetBool("IsTriggerPulled", false);
            }
            if (!reloadNeeded && controllerHand != null && controllerHand.GetStandardInteractionButtonDown())
            {
                ShootCan();
            }



        }

        public void Reload()
        {
            if (reloadNeeded && canSpawnPoint != null && bulletCan != null)
            {
            spawnedBullet = Instantiate(bulletCan, canSpawnPoint.position, Quaternion.identity);

            spawnedBullet.transform.parent = gameObject.transform;
            spawnedBullet.transform.LookAt(direction2Shoot);
            Rigidbody rb = spawnedBullet.transform.Find("SodaMesh").gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            reloadNeeded = false;
            }
        }
      
        public void ShootCan()
        {
           
            Rigidbody rb = spawnedBullet.transform.Find("SodaMesh").GetComponent<Rigidbody>();
            
            rb.isKinematic = false;
            rb.useGravity = true;
            
            spawnedBullet.transform.parent = null;
            
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.AddForce((direction2Shoot.transform.position - transform.position) * 250);
            reloadNeeded = true;
            if (shotSound != null)
            {
                shotSound.Play();
            }
            StartCoroutine(LongVibration(0.1f, 1));
            //StartCoroutine(Reloading());
            //StopAllCoroutines();

            
            

        }
        //IEnumerator Reloading()
        //{

        //    yield return new WaitForSeconds(1.5f);
        //    reloadNeeded = true;
        //        }


            //length is how long the vibration should go for
            //strength is vibration strength from 0-1
            IEnumerator LongVibration(float length, float strength)
        {
            
            for (float i = 0; i < length; i += Time.deltaTime)
            {
                controllerHand.controller.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
                yield return null;
            }
          
        }
    }
}
