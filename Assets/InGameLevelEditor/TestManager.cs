using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    [SerializeField] GameObject[] EditorObjects;
    [SerializeField] GameObject[] allTools;
    [SerializeField] GameObject[] GameObjects;
    [SerializeField] GameObject[] allLevelObjects;
    [SerializeField] GameObject levelCompletedTrigger;
    [SerializeField] GameObject levelCompletedCanvas;
    [SerializeField] GameObject[] allTriggers;
    [SerializeField] GameObject[] allCameras;
    [SerializeField] GameObject[] EditorTools;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerPoint;
    [SerializeField] GameObject fadeOutCanvas;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject onlineLevelSong;
    [SerializeField] GameObject TwoDGrid;
    [SerializeField] GameObject ThreeDGrid;

    public bool isDead;

    public GameObject levelObjectsManager;
    public bool isTesting;
    public bool canReturnPositions;
    public bool canReturnInGamePositions;
    public bool canEdit;
    public bool getEverythingSet;

	// Use this for initialization
	void Start () {
        fadeOutCanvas.SetActive(false);
        allLevelObjects = GameObject.FindGameObjectsWithTag("Objects");
        levelCompletedTrigger = GameObject.FindGameObjectWithTag("LCTrigger");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        foreach (GameObject p in allCameras)
        {
            p.GetComponentInChildren<Camera>().enabled = false;
            p.GetComponentInChildren<CameraFollow>().enabled = false;
        }
        TwoDGrid.SetActive(true);
        ThreeDGrid.SetActive(true);
        getEverythingSet = true;
    }
	
	// Update is called once per frame
	void Update () {
        allLevelObjects = GameObject.FindGameObjectsWithTag("Objects");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");

        if (canEdit)
        {
            TwoDGrid.SetActive(true);
            ThreeDGrid.SetActive(true);
        }

        if (isTesting)
        {
            if (getEverythingSet)
            {
                levelCompletedTrigger.GetComponent<LevelCompletedTrigger>().enabled = true;
                canEdit = false;
                TwoDGrid.SetActive(false);
                ThreeDGrid.SetActive(false);
                foreach (GameObject m in allCameras)
                {
                    m.GetComponentInChildren<Camera>().enabled = true;
                    m.GetComponentInChildren<CameraFollow>().enabled = true;
                }

                levelCompletedTrigger.transform.parent = levelObjectsManager.transform;

                foreach (GameObject s in EditorTools)
                {
                    s.SetActive(false);
                }

                foreach(GameObject s in allTools)
                {
                    s.SetActive(false);
                }

                if (allLevelObjects != null)
                {
                    foreach (GameObject p in allLevelObjects)
                    {
                        if (!p.GetComponent<ObjectPriorities>().isOnCenter)
                        {
                            p.transform.parent = levelObjectsManager.transform;
                        }
                    }
                }

                levelObjectsManager.GetComponent<LevelSpeed>().enabled = true;

                if (allTriggers != null)
                {
                    foreach (GameObject p in allTriggers)
                    {
                        p.transform.parent = levelObjectsManager.transform;

                        if(p.name == "KillZone")
                        {
                            p.GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }
                }


                foreach (GameObject n in GameObjects)
                {
                    n.SetActive(true);
                }

                foreach (GameObject m in EditorObjects)
                {
                    m.SetActive(false);
                }

                getEverythingSet = false;
            }
        }
        else
        {
            levelCompletedTrigger.GetComponent<SpriteRenderer>().enabled = true;
            levelCompletedTrigger.transform.parent = null;

            foreach (GameObject p in allLevelObjects)
            {
                levelObjectsManager.GetComponent<LevelSpeed>().enabled = false;
                p.transform.parent = null;
            }
            foreach (GameObject n in GameObjects)
            {
                n.SetActive(false);
            }
            foreach (GameObject p in allTriggers)
            {
                levelObjectsManager.GetComponent<LevelSpeed>().enabled = false;
                p.transform.parent = null;
                if (p.name == "ColorTrigger")
                {
                    p.GetComponent<ColorTrigger>().enabled = true;
                }
                else if (p.name == "BloomTrigger")
                {
                    p.GetComponent<BloomTrigger>().enabled = true;
                }
                else if (p.name == "KillZone")
                {
                    p.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }

        if (isDead)
        {
            fadeOutCanvas.SetActive(false);
            foreach (GameObject p in allLevelObjects)
            {
                levelObjectsManager.GetComponent<LevelSpeed>().enabled = false;
                p.transform.parent = null;
            }

            foreach(GameObject p in allTriggers)
            {
                levelObjectsManager.GetComponent<LevelSpeed>().enabled = false;
                p.transform.parent = null;
            }

            foreach (GameObject m in allCameras)
            {
                m.GetComponentInChildren<Camera>().enabled = true;
                m.GetComponentInChildren<CameraFollow>().enabled = true;
            }

            onlineLevelSong.GetComponent<AudioSource>().Stop();
            deathScreen.SetActive(true);
            isTesting = false;
            StartCoroutine("ReturningPositionsInDeath");
            StartCoroutine("ReturnPositionInDeath");
        }
    }

    public void TestMode()
    {
        fadeOutCanvas.SetActive(true);
        isTesting = true;
        player.SetActive(true);
        player.transform.position = playerPoint.transform.position;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        foreach(GameObject m in allLevelObjects)
        {
            if (m.name != "CustomObject1")
            {
                m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 1f);
            }
        }
        foreach(GameObject m in allCameras)
        {
            Vector3 vec = new Vector3(m.transform.position.x, m.transform.position.y, m.transform.position.z);
            m.transform.GetChild(0).gameObject.transform.position = vec;
        }
        foreach(GameObject p in allTriggers)
        {
            if (p.name == "ColorTrigger")
            {
                p.GetComponent<ColorTrigger>().color = new Color(p.GetComponent<ColorTrigger>().rStart / 255, p.GetComponent<ColorTrigger>().gStart / 255, p.GetComponent<ColorTrigger>().bStart / 255, p.GetComponent<ColorTrigger>().aStart / 255);
            }
        }
        
    }

    public void ReturnPos()
    {
        isTesting = false;
        levelCompletedCanvas.SetActive(false);
        fadeOutCanvas.SetActive(false);
        player.SetActive(false);
        getEverythingSet = true;
        StartCoroutine("ReturningPosition");
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject p in allCameras)
        {
            p.GetComponentInChildren<Camera>().enabled = false;
            p.GetComponentInChildren<CameraFollow>().enabled = false;
        }
        foreach (GameObject m in EditorObjects)
        {
            m.SetActive(true);
        }
        canEdit = true;
        canReturnPositions = false;
    }

    IEnumerator ReturningPosition()
    {
        yield return new WaitForSeconds(0.5f);
        TwoDGrid.SetActive(true);
        ThreeDGrid.SetActive(true);
        canReturnPositions = true;
    }

    IEnumerator ReturningPositionsInDeath()
    {
        yield return new WaitForSeconds(0.1f);
        canReturnInGamePositions = true;
    }

    public IEnumerator ReturnPositionInDeath()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject p in allCameras)
        {
            p.GetComponentInChildren<Camera>().enabled = true;
            p.GetComponentInChildren<CameraFollow>().enabled = true;
        }
        canReturnInGamePositions = false;
        isDead = false;
        fadeOutCanvas.SetActive(true);
        deathScreen.SetActive(false);
        if (!isTesting)
        {
            TestMode();
            canEdit = false;
            getEverythingSet = true;
        }
    }
}
