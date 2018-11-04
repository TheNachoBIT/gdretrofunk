using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour {

    static float attempts;
    [SerializeField] private float showAttempts;
    static float clicks;
    [SerializeField] private float showClicks;
    [SerializeField] private DeathTrigger dt;
    [SerializeField] private Text attemptsText;
    [SerializeField] private Text clicksText;
    private bool addDeath;
    [SerializeField] private Pause pause;

    // Use this for initialization
    void Start () {
        addDeath = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!pause.isOnPause)
            {
                clicks = clicks + 1;
            }
        }

        if (dt.isDead)
        {
            addDeath = true;
            dt.isDead = false;
        }

        if (addDeath)
        {
            attempts = attempts + 1;
            addDeath = false;
        }

        attemptsText.text = attempts.ToString();
        clicksText.text = clicks.ToString();
    }
}
