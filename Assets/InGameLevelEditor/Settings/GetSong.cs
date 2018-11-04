using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GetSong : MonoBehaviour {

    public ResourcesManager rM;

    bool one;
    bool two;

    public string nameWav;
    public string nameMp3;

    public bool wavDone;
    public bool mp3Done;

    [SerializeField] private Button load;
    [SerializeField] private Button play;
    [SerializeField] private Button stop;

    [SerializeField] private InputField typeWav;
    [SerializeField] private InputField typeMp3;

    public bool canPause;
    public bool isLoading;

    public Text info;

    AudioClip clip;
    public GameObject Song;

    // Use this for initialization
    void Start () {
        typeWav.text = nameWav;
        typeMp3.text = nameMp3;
	}
	
	// Update is called once per frame
	void Update () {
        if (!clip)
        {
            play.interactable = false;
            stop.interactable = false;
        }

        if (canPause)
        {
            if (!isLoading)
            {
                play.interactable = false;
                stop.interactable = true;
            }
        }
        else
        {
            if (clip)
            {
                if (!isLoading)
                {
                    play.interactable = true;
                    stop.interactable = false;
                }
            }
        }

        if (isLoading)
        {
            play.interactable = false;
            stop.interactable = false;
        }

        nameWav = typeWav.text;
        nameMp3 = typeMp3.text;
	}

    public void StartDownload()
    {
        isLoading = true;
        if (Song.GetComponent<AudioSource>().enabled)
        {
            Song.GetComponent<AudioSource>().Stop();
            Song.GetComponent<AudioSource>().enabled = false;
            canPause = false;
            play.interactable = false;
            stop.interactable = false;
        }
        StartCoroutine(DownloadSong(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + rM.levelName + "/Song/" + nameWav, System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + rM.levelName + "/Song/" + nameMp3));
    }

    public void PlaySong()
    {
        canPause = true;
        info.text = "<color=#FFFF00FF>Playing Song...</color>";
        Song.GetComponent<AudioSource>().enabled = true;
        Song.GetComponent<AudioSource>().Play();
    }

    public void StopSong()
    {
        canPause = false;
        info.text = "<color=#FFFF00FF>Song Stopped.</color>";
        Song.GetComponent<AudioSource>().Stop();
        Song.GetComponent<AudioSource>().enabled = false;
    }

    IEnumerator DownloadSong(string urlwav, string urlmp3)
    {

        WWW wwwWav = new WWW(urlwav);
        Debug.Log("Loading WAV...");

        WWW wwwMp3 = new WWW(urlmp3);
        Debug.Log("Loading WAV...");

        info.text = "<color=#FFFF00FF>Loading Song...</color>";
        if(info.text == "<color=#FFFF00FF>Loading Song...</color>")
        {
            one = false;
            two = false;
            load.interactable = false;
        }

        yield return wwwWav;

        if (!string.IsNullOrEmpty(wwwWav.error))
        {
            info.text = "<color=#FF8787FF>ERROR: The .WAV file is missing!</color>";
            one = true;
            isLoading = false;
            load.interactable = true;
        }
        else if (wwwWav.isDone)
        {
            info.text = "<color=#5DFF00FF>.WAV file Loaded!</color>";
            one = false;
        }

        Debug.Log("WAV finished loading!");
        wavDone = true;

        yield return wwwMp3;

        if (!string.IsNullOrEmpty(wwwMp3.error))
        {
            info.text = "<color=#FF8787FF>ERROR: The .MP3 file is missing!</color>";
            two = true;
            isLoading = false;
            load.interactable = true;
        }
        else if (wwwMp3.isDone)
        {
            if (!one)
            {
                info.text = "<color=#5DFF00FF>.MP3 file Loaded!</color>";
            }
            two = false;
        }

        Debug.Log("MP3 finished loading!");
        mp3Done = true;

        if(one && two)
        {
            info.text = "<color=#FF8787FF>ERROR: Both audio files, .MP3 and .WAV are missing!</color>";
        }

        if (wavDone && mp3Done)
        {
            if (string.IsNullOrEmpty(wwwWav.error) && string.IsNullOrEmpty(wwwMp3.error))
            {
                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    clip = wwwMp3.GetAudioClipCompressed(false, AudioType.MPEG);
                    Song.GetComponent<AudioSource>().clip = clip;
                    info.text = "<color=#5DFF00FF>Song Loaded!</color>";
                    isLoading = false;
                    load.interactable = true;
                }
                else
                {
                    clip = wwwWav.GetAudioClipCompressed(false, AudioType.WAV);
                    Song.GetComponent<AudioSource>().clip = clip;
                    info.text = "<color=#5DFF00FF>Song Loaded!</color>";
                    isLoading = false;
                    load.interactable = true;
                }
            }
            else
            {
                wavDone = false;
                mp3Done = false;
            }
        }
    }
}
