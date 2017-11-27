using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{

    public class Reloading : MonoBehaviour {

       

        public bool ColliderGunPoint = false;
        public bool ColliderAtEndPoint = false;
        public bool ShirtIsPartOfGun = false;

        Transform GunObject;
        private Transform StartPositionGO;
        private Transform EndPositionGO;
        float StartTime;
        float TotalDistanceToDestination;
        Rigidbody rb;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("ColAtEnd"))
            {
                ColliderAtEndPoint = true;
            }
            if (other.gameObject.CompareTag("ColAtGunPoint"))
            {
                ColliderGunPoint = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("ColAtEnd"))
            {
                ColliderAtEndPoint = false;
            }
            if (other.gameObject.CompareTag("ColAtGunPoint"))
            {
                ColliderGunPoint = false;
            }
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("ColAtEnd"))
        //    {
        //        ColliderAtEndPoint = true;
        //    }
        //    if (collision.gameObject.CompareTag("ColAtGunPoint"))
        //    {
        //        ColliderGunPoint = true;
        //    }
        //}

        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("ColAtEnd"))
        //    {
        //        ColliderAtEndPoint = false;
        //    }
        //    if (collision.gameObject.CompareTag("ColAtGunPoint"))
        //    {
        //        ColliderGunPoint = false;
        //    }
        //}


        // Use this for initialization
        void Start() {

            rb = gameObject.GetComponent<Rigidbody>();
            Debug.Log("hallo");

        }

        // Update is called once per frame
        void Update() {
            Hand controllerHand = GetComponent<Hand>();
            if (ColliderAtEndPoint && ColliderGunPoint && !ShirtIsPartOfGun && controllerHand != null && controllerHand.GetStandardInteractionButtonUp())
            {
                
                rb.isKinematic = true;
                rb.useGravity = false;
                GunObject = GameObject.Find("ShirtGunPrefab(Clone)").GetComponent<Transform>();
                if (GunObject != null)
                {
                    gameObject.transform.parent = GunObject.transform;
                    ShirtIsPartOfGun = true;
                    StartPositionGO = GameObject.Find("StartPosition").transform;
                    EndPositionGO = GameObject.Find("EndPosition").transform;
                    StartTime = Time.time;
                    TotalDistanceToDestination = Vector3.Distance(StartPositionGO.position, EndPositionGO.position);
                }              
            }
            if (ShirtIsPartOfGun)
            {
                float currentDuration = Time.time - StartTime;
                float journeyFraction = currentDuration / TotalDistanceToDestination;
                transform.position = Vector3.Lerp(StartPositionGO.position, EndPositionGO.position, journeyFraction);
                
            }
            if (EndPositionGO != null)
            {
                if (transform.position == EndPositionGO.position)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

            }
           
        }


       
    }
}
