using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject groupOfMainCameras;
    [SerializeField] private Pause pause;
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private AudioSource song;
    [SerializeField] private PlayerController pc;
    public bool isDead;
    private bool addPoint;
    public bool clickDetector;
    [SerializeField] private GameObject levelCompletedTrigger;
    [SerializeField] private bool ifIsZeroPointTwo;
    [SerializeField] private GameObject player;
    public bool canDestroy;
    public bool levelEditor;
    [SerializeField] private LevelSpeed[] levelSpeeds;
    [SerializeField] private TestManager testM;

	// Use this for initialization
	void Start () {
        isDead = false;
        player.GetComponent<Pause>().isDead = false;
        addPoint = true;

        if (levelEditor)
        {
            testM = GameObject.Find("TestManager").GetComponent<TestManager>();
        }

        if (!testM)
        {
            pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            pause = GameObject.FindGameObjectWithTag("Player").GetComponent<Pause>();
            levelSpeeds = LevelSpeed.FindObjectsOfType<LevelSpeed>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (addPoint)
        {
            if (!testM)
            {
                if (other.gameObject.tag == "Player")
                {
                    player.GetComponent<Pause>().isDead = true;
                    gameOverScreen.SetActive(true);
                    groupOfMainCameras.SetActive(false);
                    levelCompleted.SetActive(false);
                    song.Stop();
                    StartCoroutine("SecondsToRestart");
                    isDead = true;
                    addPoint = false;
                    pause.enabled = false;
                    foreach (LevelSpeed m in levelSpeeds)
                    {
                        m.enabled = false;
                    }
                }

                else if (other.gameObject.tag == "Kill")
                {
                    player.GetComponent<Pause>().isDead = true;
                    gameOverScreen.SetActive(true);
                    groupOfMainCameras.SetActive(false);
                    levelCompleted.SetActive(false);
                    song.Stop();
                    StartCoroutine("SecondsToRestart");
                    isDead = true;
                    addPoint = false;
                    pause.enabled = false;
                    foreach (LevelSpeed m in levelSpeeds)
                    {
                        m.enabled = false;
                    }
                }
            }
            else
            {
                if (other.gameObject.tag == "Player")
                {
                    testM.isDead = true;
                }
            }
        }
    }

    IEnumerator SecondsToRestart()
    {
        yield return new WaitForSeconds(1.5f);
        canDestroy = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
