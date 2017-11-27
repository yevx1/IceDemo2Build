using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MovePlatform))]
public class Cans_BallsActivator : MonoBehaviour
{
    public List<GameObject> cansBalls;
    private MovePlatform platformMovement;
    private bool areItemsActivated;
    public List<GameObject> orbInsideLights;

    // Use this for initialization
    void Start()
    {
        platformMovement = gameObject.GetComponent<MovePlatform>();
        foreach (GameObject item in cansBalls)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            //item.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (areItemsActivated == false)
        {
            if (transform.position == platformMovement.enteringStopFinal.position)
            {
                ActivateAllListItems();
                areItemsActivated = true;
            }

        }
    }
    public void DeactivateAllItems()
    {
        if (orbInsideLights != null)
        {

            foreach (GameObject item in orbInsideLights)
            {
                item.SetActive(false);
            }
        }
        foreach (GameObject item in cansBalls)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            //item.SetActive(true);

        }
    }
    public void ActivateAllListItems()
    {
        if (orbInsideLights != null)
        {
            foreach (GameObject item in orbInsideLights)
            {
                item.SetActive(true);
            }
        }
        foreach (GameObject item in cansBalls)
        {
            Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            //item.SetActive(true);

        }
    }
}
