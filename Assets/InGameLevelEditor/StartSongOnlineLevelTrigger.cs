using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSongOnlineLevelTrigger : MonoBehaviour {

    public AudioSource au;
    public TestManager testM;


	// Use this for initialization
	void Start () {
        au = GameObject.FindGameObjectWithTag("Song").GetComponent<AudioSource>();
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        au.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (testM.isTesting)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
            {
                au.enabled = true;
                au.Play();
                enabled = false;
            }
        }
    }
}
