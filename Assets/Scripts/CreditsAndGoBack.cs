using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAndGoBack : MonoBehaviour {

    [SerializeField] private GameObject specialThanksCanvas;

	public void Credits()
    {
        specialThanksCanvas.SetActive(true);
    }

    public void GoBack()
    {
        specialThanksCanvas.SetActive(false);
    }
}
