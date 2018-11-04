using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserAccount : MonoBehaviour {

    private string _createUserURL = "https://vxempire.xyz/cgi-bin/do.cgi";
    private string _loginUserURL = "https://vxempire.xyz/cgi-bin/login.cgi";
    [SerializeField] private GameObject _registerPanel, _registerImage, _loginPanel, _loadingBox, _YaySign, _NotOkSign, _notLoggedInHub, _LoggedInHub;
    [SerializeField] private Text _YaySignText, _NotOkSignText, _loggedUsernameHub;
    [SerializeField] private InputField _registerUsername, _registerPassword, _loginUsername, _loginPassword;

    public string _username;
    public string _email;
    public string _password;

    public string _loggedUsername;

    private bool _isOnRegister, _isOnLogin, _isConnecting;

	// Use this for initialization
	void Start () {
        _registerPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (_isOnRegister && !_isConnecting)
        {
            _username = _registerUsername.text;
            _password = _registerPassword.text;
        }
        else if(_isOnLogin && !_isConnecting)
        {
            _username = _loginUsername.text;
            _password = _loginPassword.text;
        }
	}

    public void OpenRegisterPanel()
    {
        _registerPanel.SetActive(true);
        _registerImage.SetActive(true);
        _isOnRegister = true;
    }

    public void CloseRegisterPanel()
    {
        _registerPanel.SetActive(false);
        _registerImage.SetActive(false);
        _isOnRegister = false;
    }

    public void OpenLoginPanel()
    {
        _loginPanel.SetActive(true);
        _registerImage.SetActive(true);
        _isOnLogin = true;
    }

    public void CloseLoginPanel()
    {
        _loginPanel.SetActive(false);
        _registerImage.SetActive(false);
        _isOnLogin = false;
    }

    public void CloseExtraWindows()
    {
        _YaySign.SetActive(false);
        _NotOkSign.SetActive(false);
    }

    public void RegisterUser()
    {
        StartCoroutine(UploadUserToDB());
        _loadingBox.SetActive(true);
    }

    public void LoginUser()
    {
        StartCoroutine(LoginUserFromDB());
        _loadingBox.SetActive(true);
    }

    IEnumerator UploadUserToDB()
    {
        WWWForm _form = new WWWForm();
        _form.AddField("user post parameter", _username);
        _form.AddField("password post parameter", _password);


        using (var w = UnityWebRequest.Post(_createUserURL, _form))
        {
            yield return w.Send();
            _isConnecting = true;
            _loadingBox.SetActive(true);
            if(w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("Sending Data...");
                if(w.downloadHandler.text == "0")
                {
                    print("This user is now in the database! :D");
                    _isConnecting = false;
                    _loadingBox.SetActive(false);
                    _YaySign.SetActive(true);
                    _YaySignText.text = "User succesfully created! :D";
                    _registerPanel.SetActive(false);
                    _registerImage.SetActive(false);
                    _isOnRegister = false;
                }
                else if (w.downloadHandler.text == "1")
                {
                    print("Sorry, this username already exists...");
                    _isConnecting = false;
                    _loadingBox.SetActive(false);
                    _NotOkSign.SetActive(true);
                    _NotOkSignText.text = "Sorry, this username already exists... Try out a different name. :(";
                }
            }

        }
    }

    IEnumerator LoginUserFromDB()
    {
        WWWForm _form = new WWWForm();
        _form.AddField("Usuario", _username);
        _form.AddField("pass", _password);

        using (var w = UnityWebRequest.Post(_loginUserURL, _form))
        {
            _isConnecting = true;
            _loadingBox.SetActive(true);
            yield return w.Send();
            if(w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("Sending Data...");
                print(w.downloadHandler.text);
                if(w.downloadHandler.text == "1")
                {
                    _isConnecting = false;
                    _loadingBox.SetActive(false);
                    _YaySign.SetActive(true);
                    print("You're logged in! :D");
                    _YaySignText.text = "Succesfully logged in as: <color=yellow>" + _username + "</color> :D";
                    _loginPanel.SetActive(false);
                    _registerImage.SetActive(false);
                    _isOnLogin = false;

                    _loggedUsername = _username;
                    _LoggedInHub.SetActive(true);
                    _notLoggedInHub.SetActive(false);
                    _loggedUsernameHub.text = _loggedUsername;
                }
                else if(w.downloadHandler.text == "0")
                {
                    print("Username or password are incorrect");
                    _isConnecting = false;
                    _loadingBox.SetActive(false);
                    _NotOkSign.SetActive(true);
                    _NotOkSignText.text = "Sorry, but the username/password are incorrect... :(";
                }
            }
        }
    }
}
