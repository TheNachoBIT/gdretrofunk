using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccCutsceneTrigger : MonoBehaviour {

    [SerializeField] private AudioSource au;
    private GameObject player;
    [SerializeField] private GameObject[] disable;
    [SerializeField] private GameObject qorgCanvas;

    // Use this for initialization
    void Start()
    {
        qorgCanvas.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
        {
            au.volume = 0;
            foreach (GameObject m in disable)
            {
                m.SetActive(false);
            }
            qorgCanvas.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
