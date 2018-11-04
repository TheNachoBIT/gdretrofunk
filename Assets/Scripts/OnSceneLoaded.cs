using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoaded : MonoBehaviour {

    [SerializeField] private Rigidbody sceneLoad;

	// Use this for initialization
	void Start () {
        Rigidbody clone;
        clone = Instantiate(sceneLoad, transform.position, transform.rotation) as Rigidbody;
        DontDestroyOnLoad(clone.gameObject);
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
