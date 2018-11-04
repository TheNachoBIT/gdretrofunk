using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPasteDuplicate : MonoBehaviour {

    [SerializeField] private EditObject edO;
    [SerializeField] private string objectName;
    [SerializeField] private GameObject objectCopied;
    [SerializeField] private Camera cameraMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (edO.objectSelected)
        {
            objectName = edO.objectSelected.name;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (edO.objectSelected && edO.objectSelected.name != "LevelCompletedTrigger")
                {
                    objectCopied = edO.objectSelected;
                }
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                if(objectCopied && edO.objectSelected.name != "LevelCompletedTrigger")
                {
                    edO.isDuplicated = true;
                    Vector3 vec = new Vector3(edO.objectSelected.transform.position.x, edO.objectSelected.transform.position.y, edO.objectSelected.transform.position.z);
                    GameObject clone = Instantiate(objectCopied, vec, Quaternion.identity) as GameObject;
                    clone.name = objectName;
                    if (clone.name == "ColorTrigger")
                    {
                        clone.GetComponent<ColorTrigger>().color = new Color(1f, 1f, 1f, 1f);
                    }
                    else if(clone.name == "StartColor")
                    {
                        clone.GetComponent<ObjectPriorities>().group = 0;
                        clone.GetComponent<StartColor>().group = 0;
                    }
                    edO.objectSelected = clone.gameObject;
                    edO.isShowTime = true;
                }
            }
        }
	}
}
