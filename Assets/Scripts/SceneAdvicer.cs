using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAdvicer : MonoBehaviour {

    [SerializeField] SelectIconObject sio;
    [SerializeField] GameObject player;
    private bool isPlayer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this.gameObject);
        sio = GameObject.Find("SelectIconObject").GetComponent<SelectIconObject>();
        if(sio != null)
        {
            sio.isSceneChanged = true;
            if (isPlayer)
            {
                sio.isPlayerInScene = true;
            }
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
