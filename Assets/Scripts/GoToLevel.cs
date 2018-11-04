using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour {

    [SerializeField] private byte levelNumber;

	public void OnClickToLoading()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNumber);
    }
}
