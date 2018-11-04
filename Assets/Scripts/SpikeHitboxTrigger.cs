using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHitboxTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpikeFix")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
