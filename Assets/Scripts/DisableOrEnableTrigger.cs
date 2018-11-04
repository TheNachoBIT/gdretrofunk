using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableTrigger : MonoBehaviour {

    [SerializeField] private bool disable;
    [SerializeField] private bool enable;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] objects;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
        {
            foreach(GameObject m in objects)
            {
                if (disable)
                {
                    m.SetActive(false);
                    Destroy(gameObject);
                }
                else if (enable)
                {
                    m.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
