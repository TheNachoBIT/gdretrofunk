using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseIconSelect : MonoBehaviour {

    [SerializeField] private GameObject selectIconCanvas;

    private void Start()
    {
        selectIconCanvas.SetActive(false);
    }

    public void Open()
    {
        selectIconCanvas.SetActive(true);
    }

    public void Close()
    {
        selectIconCanvas.SetActive(false);
    }
}
