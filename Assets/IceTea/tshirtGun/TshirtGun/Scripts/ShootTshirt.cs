using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShootTshirt : MonoBehaviour
{


    //GunManager gunManager;

    SteamVR_Controller controller;
    GameObject shirtLoading;
    GameObject shirtLerpPoints;
    GameObject lerpEndPoint;
    GameObject bulletShirt;
    //GameObject goMeshCol;
    GameObject direction2Shoot;
    public Hand controllerHand;

    //private bool isBulletFired;
    private bool isThereABullet;
    // Use this for initialization


    public SoundPlayOneshot shotSound;


    void Start()
    {
        //gunManager = GameObject.Find("GunManager").GetComponent<GunManager>();
    }
    private void OnAttachedToHand(Hand attachedHand)
    {
        controllerHand = attachedHand;
    }
    // Update is called once per frame
    void Update()
    {

        //controllerHand =  gameObject.GetComponentInParent<Hand>();
        if (isThereABullet)
        {
            if (bulletShirt.GetComponent<TShirtInteractable>().isGunLoaded && controllerHand != null && controllerHand.GetStandardInteractionButtonDown())
            {
                ShootShirt();
            }
        }
        //if (isBulletFired)
        //{
        //    if (shirtLoading == null && shirtLerpPoints == null)
        //    {
        //        shirtLoading = transform.Find("ShirtLoadingColliders").GetComponent<GameObject>();
        //        shirtLerpPoints = transform.Find("ShirtLerpPositions").GetComponent<GameObject>();
        //        lerpEndPoint = shirtLerpPoints.transform.Find("EndPosition").gameObject;
        //    }

        //    shirtLoading.SetActive(true);
        //    shirtLerpPoints.SetActive(true);
        //    lerpEndPoint.SetActive(true);
        //}
    }

    public void DeactivateReloadColliders()
    {
        //check in all the children of GunPrefab if shirt is added as a child
        foreach (Transform item in transform)
        {
            if (item.gameObject.CompareTag("tshirt"))
            {
                bulletShirt = item.gameObject;
                isThereABullet = true;
            }
        }
        //if (shirtLoading == null && shirtLerpPoints == null /*&& goMeshCol == null*/ && direction2Shoot == null)
        //{
        shirtLoading = transform.Find("ShirtLoadingColliders").gameObject;
        shirtLerpPoints = transform.Find("ShirtLerpPositions").gameObject;
        //goMeshCol = transform.Find("tshirtGunCombined7").gameObject;
        direction2Shoot = transform.Find("Directionshoot").gameObject;
        //lerpEndPoint = shirtLerpPoints.transform.Find("EndPosition").gameObject;

        //}

        shirtLoading.SetActive(false);


    }
    public void ActivateReloadColliders()
    {
        if (shirtLoading == null && shirtLerpPoints == null)
        {
            shirtLoading = transform.Find("ShirtLoadingColliders").GetComponent<GameObject>();
            //shirtLerpPoints = transform.Find("ShirtLerpPositions").GetComponent<GameObject>();
            //lerpEndPoint = shirtLerpPoints.transform.Find("EndPosition").gameObject;
        }

        shirtLoading.SetActive(true);
        //shirtLerpPoints.SetActive(true);
        //lerpEndPoint.SetActive(true);
    }
    public void ShootShirt()
    {
        //shirtLerpPoints.SetActive(false);
        Rigidbody rb = bulletShirt.GetComponent<Rigidbody>();
        //Collider col = goMeshCol.GetComponent<Collider>();

        //col.enabled = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        bulletShirt.transform.LookAt(direction2Shoot.transform);
        bulletShirt.transform.parent = null;
        bulletShirt.GetComponent<TShirtInteractable>().ShirtIsPartOfGun = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.AddForce((direction2Shoot.transform.position - transform.position) * 10000);
        bulletShirt.GetComponent<TShirtInteractable>().isGunLoaded = false;
        if (shotSound != null)
        {
            shotSound.Play();
        }
        StartCoroutine(LongVibration(0.1f, 1));
        

        isThereABullet = false;
        ActivateReloadColliders();

    }


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
