using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResolutionIfMobile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Screen.SetResolution(640, 360, true);
            QualitySettings.SetQualityLevel(0);
        }
        else
        {
            QualitySettings.SetQualityLevel(0);
        }

        Destroy(this.gameObject);

    }
}
