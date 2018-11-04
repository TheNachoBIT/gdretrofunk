using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsTrigger : MonoBehaviour {

    [SerializeField] private PlayerController pc;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Swing")
        {
            pc.Swing = true;
            pc.Cube = false;
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if(other.gameObject.tag == "Cube")
        {
            pc.Cube = true;
            pc.Swing = false;
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Swing")
        {
            pc.Swing = true;
            pc.Cube = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.gameObject.tag == "Cube")
        {
            pc.Cube = true;
            pc.Swing = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
