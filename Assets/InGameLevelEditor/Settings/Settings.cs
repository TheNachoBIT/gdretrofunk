using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    [SerializeField] private GameObject settings;
    [SerializeField] private GhostFreeRoamCamera editorView;

	// Use this for initialization
	void Start () {
        settings.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenSettings()
    {
        settings.SetActive(true);
        editorView.enabled = false;
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        editorView.enabled = true;
    }
}
