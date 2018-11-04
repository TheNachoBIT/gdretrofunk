using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTools : MonoBehaviour {

    public GameObject objectSelected;
    public bool canUseTools;
    public bool canMove;
    public bool canRotate;
    public bool canScale;
    [SerializeField] private GameObject moveGizmos;
    public GameObject rotateGizmos;
    [SerializeField] private GameObject scaleGizmos;
    [SerializeField] private Button moveButton;
    [SerializeField] private Button rotateButton;
    [SerializeField] private Button scaleButton;
    [SerializeField] private Button noneButton;
    [SerializeField] private Button deselectButton;
    [SerializeField] private Text moveTextButton;
    [SerializeField] private Text rotateTextButton;
    [SerializeField] private Text scaleTextButton;
    [SerializeField] private Text noneTextButton;
    [SerializeField] private Color colorButtonNormal;
    [SerializeField] private Color colorTextNormal;
    [SerializeField] private Color colorButtonPressed;
    [SerializeField] private Color colorTextPressed;
    [SerializeField] private EditObject edO;

    // Use this for initialization
    void Start () {
        moveGizmos.SetActive(false);
        rotateGizmos.SetActive(false);
        scaleGizmos.SetActive(false);
    }
	
	// Update is called once per frame
	void LateUpdate () {

        if(edO.objectSelected == null)
        {
            noneButton.gameObject.SetActive(false);
            deselectButton.gameObject.SetActive(false);
        }
        else
        {
            noneButton.gameObject.SetActive(true);
            deselectButton.gameObject.SetActive(true);
        }

        if (canUseTools)
        {
            if (canMove)
            {
                moveButton.GetComponent<Image>().color = colorButtonPressed;
                moveTextButton.GetComponent<Text>().color = colorTextPressed;
                moveGizmos.GetComponent<GizmoTranslateScript>().enabled = true;
                moveGizmos.GetComponent<GizmoTranslateScript>().translateTarget = objectSelected;
                moveGizmos.transform.position = objectSelected.transform.position;
            }
            else
            {
                moveButton.GetComponent<Image>().color = colorButtonNormal;
                moveTextButton.GetComponent<Text>().color = colorTextNormal;
                moveGizmos.SetActive(false);
            }
            if (canScale)
            {
                scaleButton.GetComponent<Image>().color = colorButtonPressed;
                scaleTextButton.GetComponent<Text>().color = colorTextPressed;
                scaleGizmos.GetComponent<GizmoScaleScript>().enabled = true;
                scaleGizmos.GetComponent<GizmoScaleScript>().scaleTarget = objectSelected;
                scaleGizmos.transform.position = objectSelected.transform.position;
            }
            else
            {
                scaleButton.GetComponent<Image>().color = colorButtonNormal;
                scaleTextButton.GetComponent<Text>().color = colorTextNormal;
                scaleGizmos.SetActive(false);
            }
        }

        if (canMove)
        {
            Debug.Log("enabled Move");
            moveGizmos.SetActive(true);
            scaleGizmos.SetActive(false);
        }
        else if (canScale)
        {
            Debug.Log("enabled Scale");
            moveGizmos.SetActive(false);
            scaleGizmos.SetActive(true);
        }
    }

    public void OnMove()
    {
        canUseTools = true;
        canMove = true;
        canRotate = false;
        canScale = false;
        noneButton.GetComponent<Image>().color = colorButtonNormal;
        noneTextButton.GetComponent<Text>().color = colorTextNormal;
        moveGizmos.SetActive(true);
        scaleGizmos.SetActive(false);
    }
    public void OnRotate()
    {
        canUseTools = true;
        canMove = false;
        canRotate = true;
        canScale = false;
    }

    public void OnScale()
    {
        canUseTools = true;
        canMove = false;
        canRotate = false;
        canScale = true;
        noneButton.GetComponent<Image>().color = colorButtonNormal;
        noneTextButton.GetComponent<Text>().color = colorTextNormal;
        moveGizmos.SetActive(false);
        scaleGizmos.SetActive(true);
    }

    public void OnDeselect()
    {
        canUseTools = false;
        canMove = false;
        canRotate = false;
        canScale = false;
        moveButton.GetComponent<Image>().color = colorButtonNormal;
        moveTextButton.GetComponent<Text>().color = colorTextNormal;
        scaleButton.GetComponent<Image>().color = colorButtonNormal;
        scaleTextButton.GetComponent<Text>().color = colorTextNormal;
        noneButton.GetComponent<Image>().color = colorButtonPressed;
        noneTextButton.GetComponent<Text>().color = colorTextPressed;
        moveGizmos.SetActive(false);
        scaleGizmos.SetActive(false);
    }

    public void DeselectObject()
    {
        edO.objectSelected = null;
        canUseTools = false;
        canMove = false;
        canRotate = false;
        canScale = false;
        moveGizmos.SetActive(false);
        scaleGizmos.SetActive(false);
    }
}
