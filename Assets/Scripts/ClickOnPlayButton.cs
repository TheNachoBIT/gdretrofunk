using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnPlayButton : MonoBehaviour {

    [SerializeField] private Animator outsideCamera, canvas;
    [SerializeField] private GameObject levelSelection;

	public void OnClick()
    {
        outsideCamera.SetBool("play", true);
        canvas.SetBool("play", true);
        StartCoroutine("Be");
    }

    IEnumerator Be()
    {
        yield return new WaitForSeconds(2f);
        levelSelection.SetActive(true);
    }
}
