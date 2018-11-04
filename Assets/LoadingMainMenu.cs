using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMainMenu : MonoBehaviour {

    private WaitForSeconds wait;

	// Use this for initialization
	void Start () {

        wait = new WaitForSeconds(4.5f);
        StartCoroutine(LoadMenu());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadMenu()
    {
        yield return wait;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
