using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    //verificar una coalision
    void OnTriggerEnter2D(Collider2D theObject){
        if (theObject.tag=="Player")
        {
            PlayerController.sharedInstance.KillPlayer();
        }

    }
}
