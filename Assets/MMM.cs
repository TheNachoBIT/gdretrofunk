using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMM : MonoBehaviour {

    public bool _menu;
    public bool _levels;
    public bool _canInteractWithStart;
    public bool _chatOpened;
    [SerializeField] private Animator menuSelect;
    [SerializeField] private Animator logo;
    [SerializeField] private Animator levelSelect;
    [SerializeField] private Animator accountHub;
    [SerializeField] private GameObject outsideCamera;
    [SerializeField] private Animator chatPanel;
    [SerializeField] private GameObject SpecialThanksPanel;
    private string twitterURL = "https://twitter.com/TheNachoBIT";
    private string youtubeURL = "https://www.youtube.com/channel/UCgUCRsiLC6uAlcCDAKKDSdw";
    private string turnAroundURL = "https://youtu.be/B7plBbp76aU";
    private string accelerateURL = "https://youtu.be/kRCVzN2ZCW8";

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canInteractWithStart)
            {
                OnMenuSelect();
            }
        }   
	}

    void OnMenuSelect()
    {
        menuSelect.SetBool("select", true);
        logo.SetBool("select", true);
        accountHub.SetBool("select", true);
    }

    public void OnPressPlay()
    {
        _canInteractWithStart = false;
        levelSelect.SetBool("select", true);
        menuSelect.SetBool("select", false);
        chatPanel.SetBool("disable", true);
        accountHub.SetBool("select", false);
    }

    public void OnPressPlayBack()
    {
        _canInteractWithStart = true;
        levelSelect.SetBool("select", false);
        menuSelect.SetBool("select", true);
        chatPanel.SetBool("disable", false);
        accountHub.SetBool("select", true);
    }

    public void OnPressChat()
    {
        if (!_chatOpened)
        {
            _canInteractWithStart = false;
            chatPanel.SetBool("select", true);
            _chatOpened = true;
        }
        else
        {
            _canInteractWithStart = true;
            chatPanel.SetBool("select", false);
            _chatOpened = false;
        }
    }

    public void GoToTwitter()
    {
        Application.OpenURL(twitterURL);
    }

    public void GoToYoutube()
    {
        Application.OpenURL(youtubeURL);
    }

    public void GoToTurnAround()
    {
        Application.OpenURL(turnAroundURL);
    }

    public void GoToAccelerate()
    {
        Application.OpenURL(accelerateURL);
    }

    public void OpenSpecialThanksPanel()
    {
        SpecialThanksPanel.SetActive(true);
    }

    public void CloseSpecialThanksPanel()
    {
        SpecialThanksPanel.SetActive(false);
    }

    public void LoadingLevelEditor()
    {
        SceneManager.LoadSceneAsync("LoadLevelEditor");
    }

    public void Load1()
    {
        SceneManager.LoadSceneAsync("LoadingLevel1");
    }

    public void Load2()
    {
        SceneManager.LoadSceneAsync("LoadingLevel2");
    }
}
