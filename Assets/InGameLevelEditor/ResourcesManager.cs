using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesManager : MonoBehaviour {

    public string levelName;
    private string filePath;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if(!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + levelName +  "/Song"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + levelName + "/Song");
            Debug.Log("Song Directory Created! :D");
        }

        if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + levelName + "/Sprites"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + levelName + "/Sprites");
            Debug.Log("Sprites Directory Created! :D");
        }
    }
}
