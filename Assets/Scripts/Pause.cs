using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject song;
    [SerializeField] private GameObject fadeOutCanvas;
    public bool isOnPause;
    public bool isDead;

	// Use this for initialization
	void Start () {
        song = GameObject.FindGameObjectWithTag("Song");
        canvas.SetActive(false);
        isOnPause = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOnPause = true;
            canvas.SetActive(true);
            Time.timeScale = 0f;
            song.GetComponent<AudioSource>().Pause();
            fadeOutCanvas.SetActive(false);
        }
	}

    public void PauseButton()
    {
        if (!isDead)
        {
            isOnPause = true;
            canvas.SetActive(true);
            Time.timeScale = 0f;
            song.GetComponent<AudioSource>().Pause();
            fadeOutCanvas.SetActive(false);
        }
    }

    public void Continue()
    {
        isOnPause = false;
        canvas.SetActive(false);
        Time.timeScale = 1f;
        song.GetComponent<AudioSource>().Play();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingMenu", LoadSceneMode.Single);
    }
}
