using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour {

    public float speed1;
    public Vector3 vec;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void FixedUpdate()
    {
        vec = new Vector3(-speed1, 0, 0);
        transform.position += vec;
    }
}
