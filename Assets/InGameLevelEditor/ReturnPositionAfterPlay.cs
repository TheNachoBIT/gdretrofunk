using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPositionAfterPlay : MonoBehaviour {

    private LevelSpeed leS;
    [SerializeField] private TestManager testM;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float rotX;
    [SerializeField] private float rotY;
    [SerializeField] private float rotZ;
    [SerializeField] private float scaX;
    [SerializeField] private float scaY;
    [SerializeField] private float scaZ;
    [SerializeField] private GameObject returnPosPrefab;
    [SerializeField] private Transform returnPos;
    [SerializeField] private GameObject waitASecCanvas;
    [SerializeField] private bool returningPosition;
    [SerializeField] private bool returningPositionInGame;
    [SerializeField] private float r;
    [SerializeField] private float g;
    [SerializeField] private float b;
    [SerializeField] private float a;

	public Vector3 position;
	public Vector3 scale;
	public Quaternion rotation;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        waitASecCanvas = GameObject.FindGameObjectWithTag("WaitASecCanvas");
        if (testM.canEdit)
        {
            x = gameObject.transform.position.x;
            y = gameObject.transform.position.y;
            z = gameObject.transform.position.z;

            rotX = gameObject.transform.localEulerAngles.x;
            rotY = gameObject.transform.localEulerAngles.y;
            rotZ = gameObject.transform.localEulerAngles.z;

            scaX = gameObject.transform.localScale.x;
            scaY = gameObject.transform.localScale.y;
            scaZ = gameObject.transform.localScale.z;

			position = gameObject.transform.position;
			scale = gameObject.transform.localScale;
			rotation = gameObject.transform.rotation;

            if (gameObject.name == "ColorTrigger")
            {
                gameObject.GetComponent<ColorTrigger>().enabled = true;
                a = gameObject.GetComponent<ColorTrigger>().aStart;
                b = gameObject.GetComponent<ColorTrigger>().bStart;
                g = gameObject.GetComponent<ColorTrigger>().gStart;
                r = gameObject.GetComponent<ColorTrigger>().rStart;
            }
            else if (gameObject.name == "TVTrigger")
            {
                gameObject.GetComponent<TVTrigger>().enabled = true;
            }
            else if (gameObject.name == "BloomTrigger")
            {
                gameObject.GetComponent<BloomTrigger>().enabled = true;
            }
            else if (gameObject.name == "ScaleTrigger")
            {
                gameObject.GetComponent<ScaleTrigger>().enabled = true;
            }
            else if (gameObject.name == "RotateTrigger")
            {
                gameObject.GetComponent<RotateTrigger>().enabled = true;
            }
            else if (gameObject.name == "FollowTrigger")
            {
                gameObject.GetComponent<FollowTrigger>().enabled = true;
            }
            else if (gameObject.name == "DisableEnableTrigger")
            {
                gameObject.GetComponent<DisableEnableTrigger>().enabled = true;
            }
            else if (gameObject.name == "StartSongTrigger")
            {
                if (!testM.canEdit)
                {
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().enabled = true;
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.Stop();
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.enabled = false;
                }
            }

            waitASecCanvas.transform.GetChild(0).gameObject.SetActive(false);
            if(returnPos != null)
            {
                Destroy(returnPos.gameObject);
            }
        }

        if (testM.isTesting)
        {
            returningPosition = true;
            returningPositionInGame = true;
        }

        if (testM.canReturnPositions)
        {
            if (returningPosition)
            {
                Vector3 vec = new Vector3(x, y, z);
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                Vector3 sca = new Vector3(scaX, scaY, scaZ);
                GameObject clone = Instantiate(returnPosPrefab, vec, Quaternion.identity) as GameObject;
                returnPos = clone.GetComponent<Transform>();
                gameObject.transform.position = returnPos.position;
                gameObject.transform.rotation = rot;
                gameObject.transform.localScale = sca;
                waitASecCanvas.transform.GetChild(0).gameObject.SetActive(true);
                testM.StartCoroutine("WaitASec");

                if (gameObject.name == "CameraControl")
                {
                    transform.GetChild(0).gameObject.GetComponent<CameraFollow>().enabled = false;
                    transform.GetChild(2).gameObject.GetComponent<CameraFollow>().enabled = false;
                    transform.GetChild(0).position = new Vector3(0, 0, 0);
                    transform.GetChild(2).position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
                else if (gameObject.name == "MoveTrigger")
                {
                    gameObject.GetComponent<MoveTrigger>().enabled = true;
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    gameObject.GetComponent<BloomTrigger>().enabled = true;
                }
                else if (gameObject.name == "TVTrigger")
                {
                    gameObject.GetComponent<TVTrigger>().enabled = true;
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    gameObject.GetComponent<ScaleTrigger>().enabled = true;
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    gameObject.GetComponent<RotateTrigger>().enabled = true;
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    gameObject.GetComponent<FollowTrigger>().enabled = true;
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    gameObject.GetComponent<DisableEnableTrigger>().enabled = true;
                    foreach (GameObject m in gameObject.GetComponent<DisableEnableTrigger>().ObjectsInsideGroup)
                    {
                        m.transform.parent = null;
                        m.transform.position = returnPos.position;
                        m.transform.rotation = rot;
                        m.transform.localScale = sca;
                    }
                }
                else if (gameObject.name == "StartSongTrigger")
                {
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().enabled = true;
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.Stop();
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.enabled = false;
                }
                else if (gameObject.name == "ColorTrigger")
                {
                    gameObject.GetComponent<ColorTrigger>().enabled = true;
                    gameObject.GetComponent<ColorTrigger>().aStart = a;
                    gameObject.GetComponent<ColorTrigger>().bStart = b;
                    gameObject.GetComponent<ColorTrigger>().gStart = g;
                    gameObject.GetComponent<ColorTrigger>().rStart = r;
                    foreach (GameObject m in gameObject.GetComponent<ColorTrigger>().ObjectsInsideGroup)
                    {
                        m.GetComponent<SpriteRenderer>().color = new Color(r / 255, g / 255, b / 255, a / 255);
                    }
                    foreach (GameObject m in gameObject.GetComponent<ColorTrigger>().CamerasInsideGroup)
                    {
                        m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor = new Color(r / 255, g / 255, b / 255, a / 255);
                        m.transform.GetChild(0).position = new Vector3(0, 0, 0);
                        m.transform.GetChild(2).position = new Vector3(0, 0, 0);
                    }
                }
                returningPosition = false;
            }
        }
        else if (testM.canReturnInGamePositions)
        {
            if (returningPositionInGame)
            {
                Vector3 vec = new Vector3(x, y, z);
                Quaternion rot = Quaternion.Euler(rotX, rotY, rotZ);
                Vector3 sca = new Vector3(scaX, scaY, scaZ);
                GameObject clone = Instantiate(returnPosPrefab, vec, Quaternion.identity) as GameObject;
                returnPos = clone.GetComponent<Transform>();
                gameObject.transform.position = returnPos.position;
                gameObject.transform.rotation = rot;
                gameObject.transform.localScale = sca;

                if (gameObject.name == "CameraControl")
                {
                    transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
                    transform.GetChild(0).gameObject.GetComponent<CameraFollow>().enabled = true;
                    transform.GetChild(0).position = new Vector3(0, 0, 0);
                }
                else if (gameObject.name == "MoveTrigger")
                {
                    gameObject.GetComponent<MoveTrigger>().enabled = true;
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    gameObject.GetComponent<BloomTrigger>().enabled = true;
                }
                else if (gameObject.name == "TVTrigger")
                {
                    gameObject.GetComponent<TVTrigger>().enabled = true;
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    gameObject.GetComponent<ScaleTrigger>().enabled = true;
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    gameObject.GetComponent<RotateTrigger>().enabled = true;
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    gameObject.GetComponent<FollowTrigger>().enabled = true;
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    gameObject.GetComponent<DisableEnableTrigger>().enabled = true;
                    foreach (GameObject m in gameObject.GetComponent<DisableEnableTrigger>().ObjectsInsideGroup)
                    {
                        m.transform.parent = null;
                        m.transform.position = returnPos.position;
                        m.transform.rotation = rot;
                        m.transform.localScale = sca;
                    }
                }
                else if (gameObject.name == "StartSongTrigger")
                {
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().enabled = true;
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.Stop();
                    gameObject.GetComponent<StartSongOnlineLevelTrigger>().au.enabled = false;
                }
                else if (gameObject.name == "ColorTrigger")
                {
                    gameObject.GetComponent<ColorTrigger>().enabled = true;
                    gameObject.GetComponent<ColorTrigger>().aStart = a;
                    gameObject.GetComponent<ColorTrigger>().bStart = b;
                    gameObject.GetComponent<ColorTrigger>().gStart = g;
                    gameObject.GetComponent<ColorTrigger>().rStart = r;
                    foreach (GameObject m in gameObject.GetComponent<ColorTrigger>().ObjectsInsideGroup)
                    {
                        m.GetComponent<SpriteRenderer>().color = new Color(r / 255, g / 255, b / 255, a / 255);
                    }
                    foreach (GameObject m in gameObject.GetComponent<ColorTrigger>().CamerasInsideGroup)
                    {
                        m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor = new Color(r / 255, g / 255, b / 255, a / 255);
                        m.transform.GetChild(0).position = new Vector3(0, 0, 0);
                        m.transform.GetChild(2).position = new Vector3(0, 0, 0);
                    }
                }
                testM.isDead = false;
                returningPositionInGame = false;
            }
        }
	}
}
