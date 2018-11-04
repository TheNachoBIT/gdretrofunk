using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollisionTrigger : MonoBehaviour {

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

    // Use this for initialization
    void Start()
    {
        isDead = false;
        addPoint = true;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pause = GameObject.FindGameObjectWithTag("Player").GetComponent<Pause>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kill")
        {
            gameOverScreen.SetActive(true);
            groupOfMainCameras.SetActive(false);
            levelCompleted.SetActive(false);
            song.Stop();
            StartCoroutine("SecondsToRestart");
            isDead = true;
            addPoint = false;
            pause.enabled = false;
        }
    }

    IEnumerator SecondsToRestart()
    {
        yield return new WaitForSeconds(1.5f);
        canDestroy = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
