using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve;



public class Openportal : MonoBehaviour
{

    public GameObject portal;

    public Transform spawnPoint;
    private GameObject spawnedObject;
    public Transform direction2look;
    private GameObject floor;

    private void Start()
    {
        floor = GameObject.Find("Floor");
    }

    // Update is called once per frame
    private void Update()
    {
        var deviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        if (deviceIndex != -1 && SteamVR_Controller.Input(deviceIndex).GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            spawnedObject = Instantiate(portal, spawnPoint.position, Quaternion.identity);
            //spawnedObject.transform.parent = gameObject.transform;
            
            spawnedObject.transform.parent = null;
            //float height = spawnedObject.transform.position.y - floor.transform.position.y;
           
            spawnedObject.transform.LookAt(direction2look.position);
            Vector3 position = new Vector3(spawnPoint.position.x, floor.transform.position.y + 0.5f, spawnPoint.position.z);
            spawnedObject.transform.position = position;


            Quaternion rotation = Quaternion.Euler(0, spawnedObject.transform.rotation.y, spawnedObject.transform.rotation.z);
            spawnedObject.transform.rotation = rotation;

        }
    }

}

