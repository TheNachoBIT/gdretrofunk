using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomObject : MonoBehaviour {

    private SpriteRenderer sr;
    public string nameImage;
    private GameObject editObject;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        editObject = GameObject.Find("EditObject");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator DownloadImage(string url)
    {
        WWW www = new WWW(url);
		yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            editObject.GetComponent<EditObject>().OnFailedLoadImage();
        }

        if (www.isDone)
        {
            sr.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
			transform.localScale = new Vector2((100f / transform.parent.localScale.x) / www.texture.width * transform.parent.localScale.x, (100f / transform.parent.localScale.y) / www.texture.height * transform.parent.localScale.y);
			editObject.GetComponent<EditObject>().OnFinishedLoadImage();
        }
    }
}
