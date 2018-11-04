using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour {

    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
        {
            anim.SetTrigger("flash");
            Destroy(this.gameObject);
        }
    }
}
