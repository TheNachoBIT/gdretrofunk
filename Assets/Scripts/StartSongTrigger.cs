using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSongTrigger : MonoBehaviour {

    [SerializeField] private AudioSource au;
    private GameObject player;

	// Use this for initialization
	void Start () {
        au.Stop();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
        {
            au.Play();
            Destroy(this.gameObject);
        }
	}
}
