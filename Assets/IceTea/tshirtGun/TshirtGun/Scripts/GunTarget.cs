using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTarget : MonoBehaviour {

    public Light lightAboveTarget;
    

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
                lightAboveTarget.color = Color.red;
            }
        }
    }
}
