using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedTrigger : MonoBehaviour {

    [SerializeField] private GameObject levelCompletedScreen;
    [SerializeField] private bool isOnEditor;
    [SerializeField] private TestManager testM;
    [SerializeField] private GameObject FlashLCScreen;
    [SerializeField] private GameObject GroupOfMCs;
    public bool isCompleted;

	// Use this for initialization
	void Start () {
        testM = GameObject.Find("TestManager").GetComponent<TestManager>();
        levelCompletedScreen = GameObject.Find("LevelCompleted");
        levelCompletedScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (testM)
        {
            if (testM.isTesting)
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                bool canTrigger = true;
                if (player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
                {
                    if (canTrigger)
                    {
                        isCompleted = true;
                        levelCompletedScreen.SetActive(true);

                        if (isOnEditor && canTrigger)
                        {
                            levelCompletedScreen.transform.GetChild(1).transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
                        }

                        canTrigger = false;
                        StartCoroutine("AAAAA");
                    }
                }
            }
            else
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                enabled = false;
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            bool canTrigger = true;
            if (player.transform.position.x == this.transform.position.x || player.transform.position.x > this.transform.position.x)
            {
                if (canTrigger)
                {
                    levelCompletedScreen.SetActive(true);
                    canTrigger = false;
                    StartCoroutine("AAAAA");
                    GroupOfMCs.SetActive(false);
                }
            }
        }
    }

    IEnumerator AAAAA()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(FlashLCScreen);
    }
}
