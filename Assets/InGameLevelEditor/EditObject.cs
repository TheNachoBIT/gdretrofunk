using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditObject : MonoBehaviour {

    public GameObject objectSelected;

    [SerializeField] private GameObject selectedSprite;
    [SerializeField] private GameObject duplicatedSprite;
    public bool isDuplicated;
    [SerializeField] private bool DupIsDiscableOnSelectAnotherObj;

    [SerializeField] private GameObject move;
    [SerializeField] private GameObject moveButton;
    [SerializeField] private GameObject rotate;
    [SerializeField] private GameObject scale;
    [SerializeField] private GameObject scaleButton;
    [SerializeField] private GameObject cameraSelectedView;
    [SerializeField] private GameObject cameraSelected;
    public bool isACamera;
    [SerializeField] private MenuTools mt;
    [SerializeField] private TestManager tm;

    [SerializeField] private GameObject moveTool;
    [SerializeField] private GameObject scaleTool;

    [SerializeField] private GameObject inspectorContent;
    [SerializeField] private Transform inspectorResetPosition;

    //Object Priorities

    [SerializeField] private GameObject objectProperties;
    [SerializeField] private ObjectPriorities objPro;
    [SerializeField] private InputField layerInput;
    [SerializeField] private float objectGroup;

    //Color Properties

    [SerializeField] private GameObject ColorProperties;
    [SerializeField] private Slider rSlider;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Slider bSlider;
    [SerializeField] private Slider aSlider;
    [SerializeField] private InputField rInput;
    [SerializeField] private InputField gInput;
    [SerializeField] private InputField bInput;
    [SerializeField] private InputField aInput;
    [SerializeField] private Color colorPreview;
    [SerializeField] private Image colorPreviewImage;
    [SerializeField] private float colorSeconds;
    [SerializeField] private InputField inputSeconds;
    [SerializeField] private TextMesh groupVisual;

    //Move Properties

    [SerializeField] private GameObject MoveProperties;
    [SerializeField] private InputField xMoveInput;
    [SerializeField] private InputField yMoveInput;
    [SerializeField] private InputField zMoveInput;
    [SerializeField] private float moveSeconds;
    [SerializeField] private InputField inputMoveSeconds;
    [SerializeField] private TextMesh moveVisual;

    //Rotate Properties

    [SerializeField] private GameObject RotateProperties;
    [SerializeField] private InputField xRotateInput;
    [SerializeField] private InputField yRotateInput;
    [SerializeField] private InputField zRotateInput;
    [SerializeField] private float rotateSeconds;
    [SerializeField] private InputField inputRotateSeconds;
    [SerializeField] private InputField inputCenterIsAnotherGroup;
    [SerializeField] private TextMesh rotateVisual;

    //Scale Properties

    [SerializeField] private GameObject ScaleProperties;
    [SerializeField] private InputField xScaleInput;
    [SerializeField] private InputField yScaleInput;
    [SerializeField] private InputField zScaleInput;
    [SerializeField] private float scaleSeconds;
    [SerializeField] private InputField inputScaleSeconds;
    [SerializeField] private TextMesh scaleVisual;

    //Bloom Properties

    [SerializeField] private GameObject BloomProperties;
    [SerializeField] private InputField bIntensityInput;
    [SerializeField] private InputField bThresholdInput;
    [SerializeField] private InputField bSecondsInput;
    [SerializeField] private float bloomSeconds;

    //TV Properties

    [SerializeField] private GameObject TVProperties;
    [SerializeField] private Slider scanLinesSlider;
    [SerializeField] private Slider colorDriftSlider;
    [SerializeField] private InputField tvSecondsInput;
    [SerializeField] private float tvSeconds;

    //Disable Enable Properties

    [SerializeField] private GameObject DisableEnableProperties;
    [SerializeField] private TextMesh disableEnableVisual;
    [SerializeField] private TextMesh disableEnableTitle;
    [SerializeField] private Sprite disableSprite;
    [SerializeField] private Sprite enableSprite;
    [SerializeField] private Toggle disableEnableBool;

    //Follow Properties

    [SerializeField] private GameObject FollowProperties;
    [SerializeField] private TextMesh followVisual;
    [SerializeField] private InputField groupFollowInput;
    [SerializeField] private Toggle followUnfollowBool;

    //Custom Object Properties

    [SerializeField] private GameObject CustomObjectProperties;
    [SerializeField] private InputField inputImageFileName;
    [SerializeField] private Text imageFileInfo;
    [SerializeField] private Button loadButton;

    //Start Trigger Properties

    [SerializeField] private GameObject StartColorProperties;
    [SerializeField] private Slider SCRSlider;
    [SerializeField] private Slider SCGSlider;
    [SerializeField] private Slider SCBSlider;
    [SerializeField] private Slider SCASlider;
    [SerializeField] private InputField SCRInput;
    [SerializeField] private InputField SCGInput;
    [SerializeField] private InputField SCBInput;
    [SerializeField] private InputField SCAInput;
    [SerializeField] private Color SCColorPreview;
    [SerializeField] private Image SCColorPreviewImage;
    [SerializeField] private TextMesh startColorVisual;

    public bool meEnganza;

    private float posX;
    private float posY;
    private float posZ;

    private float rotX;
    private float rotY;
    private float rotZ;

    private float scaX;
    private float scaY;
    private float scaZ;

    public bool isShowTime;

    [SerializeField] private InputField posXI;
    [SerializeField] private InputField posYI;
    [SerializeField] private InputField posZI;

    [SerializeField] private InputField rotXI;
    [SerializeField] private InputField rotYI;
    [SerializeField] private InputField rotZI;

    [SerializeField] private InputField scaXI;
    [SerializeField] private InputField scaYI;
    [SerializeField] private InputField scaZI;

    [SerializeField] private InputField groupInput;

    [SerializeField] private GameObject groupNumber;
    [SerializeField] private GameObject Layer;

    [SerializeField] private ResourcesManager rM;

    [SerializeField] private CopyPasteDuplicate cpd;

    // Use this for initialization
    void Start () {
        selectedSprite.SetActive(false);
        if (meEnganza)
        {
            Debug.Log("el editor me enganza xd");
        }
        rM = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();
	}

    public void ExitEditor()
    {
        SceneManager.LoadSceneAsync("LoadingMenu", LoadSceneMode.Single);
    }
	
	// Update is called once per frame
	void LateUpdate () {

        tm = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        if (objectSelected)
        {
            objPro = objectSelected.GetComponent<ObjectPriorities>();
            if (objectSelected.name == "CameraControl")
            {
                move.SetActive(true);
                rotate.SetActive(true);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                MoveProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                RotateProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                FollowProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                cameraSelectedView.SetActive(true);
                cameraSelected = objectSelected.transform.GetChild(2).gameObject;
                cameraSelected.GetComponent<CameraFollow>().enabled = false;
                cameraSelected.GetComponent<Camera>().enabled = true;
                objectProperties.SetActive(true);
                Debug.Log("Camera Selected!");
            }
            else if (objectSelected.name == "LevelCompletedTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                TVProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                RotateProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                cameraSelectedView.SetActive(false);
                DisableEnableProperties.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }

                EditLevelCompletedTrigger();

                Debug.Log("Object Selected!");
            }
            else if (objectSelected.name == "Spike1")
            {
                move.SetActive(true);
                rotate.SetActive(true);
                moveButton.SetActive(true);
                scale.SetActive(true);
                scaleButton.SetActive(true);
                objectProperties.SetActive(true);
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                TVProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                RotateProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                cameraSelectedView.SetActive(false);
                DisableEnableProperties.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                Debug.Log("Spike Selected!");
            }
            else if (objectSelected.name == "KillZone")
            {
                move.SetActive(true);
                rotate.SetActive(true);
                moveButton.SetActive(true);
                scale.SetActive(true);
                scaleButton.SetActive(true);
                objectProperties.SetActive(true);
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                TVProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                RotateProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                cameraSelectedView.SetActive(false);
                DisableEnableProperties.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }

                groupNumber.SetActive(true);
                Layer.SetActive(false);

                Debug.Log("Kill Zone Selected!");
            }
            else if (objectSelected.name == "ColorTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(true);
                moveVisual = null;
                scaleVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                FollowProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                TVProperties.SetActive(false);
                MoveProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                groupVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditColorTrigger();

                Debug.Log("Color Trigger Selected!");
            }
            else if (objectSelected.name == "MoveTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                scaleVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                TVProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                FollowProperties.SetActive(false);
                MoveProperties.SetActive(true);
                ScaleProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                RotateProperties.SetActive(false);
                moveVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditMoveTrigger();

                Debug.Log("Move Trigger Selected!");
            }
            else if (objectSelected.name == "ScaleTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                CustomObjectProperties.SetActive(false);
                FollowProperties.SetActive(false);
                MoveProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                BloomProperties.SetActive(false);
                TVProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                ScaleProperties.SetActive(true);
                scaleVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditScaleTrigger();

                Debug.Log("Scale Trigger Selected!");
            }
            else if (objectSelected.name == "RotateTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                scaleVisual = null;
                MoveProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                BloomProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                FollowProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                RotateProperties.SetActive(true);
                rotateVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditRotateTrigger();

                Debug.Log("Scale Trigger Selected!");
            }
            else if (objectSelected.name == "DisableEnableTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                scaleVisual = null;
                MoveProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                BloomProperties.SetActive(false);
                FollowProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(true);
                disableEnableVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();
                disableEnableTitle = objectSelected.transform.GetChild(1).gameObject.GetComponent<TextMesh>();

                EditDisableEnableTrigger();
            }
            else if (objectSelected.name == "FollowTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                scaleVisual = null;
                MoveProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                BloomProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                FollowProperties.SetActive(true);
                followVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditFollowTrigger();
            }
            else if (objectSelected.name == "BloomTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                StartColorProperties.SetActive(false);
                FollowProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                MoveProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(false);
                BloomProperties.SetActive(true);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);

                EditBloomTrigger();

                Debug.Log("Bloom Trigger Selected!");
            }
            else if (objectSelected.name == "TVTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                BloomProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(true);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                scaleVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditTVTrigger();

                Debug.Log("TV Trigger Selected!");
            }
            else if (objectSelected.name == "CustomObject1")
            {
                move.SetActive(true);
                rotate.SetActive(true);
                moveButton.SetActive(true);
                scale.SetActive(true);
                scaleButton.SetActive(true);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                StartColorProperties.SetActive(false);
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                BloomProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                TVProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                CustomObjectProperties.SetActive(true);

                EditCustomObject();

                Debug.Log("Custom Object Selected!");
            }
            else if (objectSelected.name == "StartColorTrigger")
            {
                move.SetActive(true);
                rotate.SetActive(false);
                moveButton.SetActive(true);
                scale.SetActive(false);
                scaleButton.SetActive(false);
                objectProperties.SetActive(true);
                cameraSelectedView.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                StartColorProperties.SetActive(true);
                ColorProperties.SetActive(false);
                moveVisual = null;
                scaleVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                FollowProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                TVProperties.SetActive(false);
                MoveProperties.SetActive(false);
                RotateProperties.SetActive(false);
                DisableEnableProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                startColorVisual = objectSelected.transform.GetChild(2).gameObject.GetComponent<TextMesh>();

                EditStartColorTrigger();

                Debug.Log("Start Color Trigger Selected!");
            }
            else if (objectSelected.tag == "Objects")
            {
                move.SetActive(true);
                rotate.SetActive(true);
                moveButton.SetActive(true);
                scale.SetActive(true);
                scaleButton.SetActive(true);
                objectProperties.SetActive(true);
                ColorProperties.SetActive(false);
                groupVisual = null;
                moveVisual = null;
                rotateVisual = null;
                BloomProperties.SetActive(false);
                MoveProperties.SetActive(false);
                FollowProperties.SetActive(false);
                TVProperties.SetActive(false);
                ScaleProperties.SetActive(false);
                RotateProperties.SetActive(false);
                CustomObjectProperties.SetActive(false);
                StartColorProperties.SetActive(false);
                cameraSelectedView.SetActive(false);
                DisableEnableProperties.SetActive(false);
                if (cameraSelected != null)
                {
                    cameraSelected.GetComponent<Camera>().enabled = false;
                    cameraSelected = null;
                }
                Debug.Log("Object Selected!");
            }
        }
        else if (!objectSelected)
        {
            scale.SetActive(false);
            scaleButton.SetActive(false);
            cameraSelectedView.SetActive(false);
            if (cameraSelected != null)
            {
                cameraSelected.GetComponent<Camera>().enabled = false;
                cameraSelected = null;
            }
            move.SetActive(false);
            rotate.SetActive(false);
            moveButton.SetActive(false);
            ColorProperties.SetActive(false);
            groupVisual = null;
            moveVisual = null;
            rotateVisual = null;
            DisableEnableProperties.SetActive(false);
            MoveProperties.SetActive(false);
            objectProperties.SetActive(false);
            RotateProperties.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (tm.canEdit && objectSelected.name != "LevelCompletedTrigger")
            {
                objectSelected.GetComponent<ObjectPriorities>().group = 0;

                if (objectSelected.GetComponent<ObjectPriorities>().group == 0)
                {
                    Destroy(objectSelected);
                    objectSelected = null;
                }
            }
        }


        if (objectSelected)
        {
            if (!tm.isTesting)
            {
                if (!isDuplicated)
                {
                    selectedSprite.SetActive(true);
                    duplicatedSprite.SetActive(false);
                }
                else
                {
                    selectedSprite.SetActive(false);
                    duplicatedSprite.SetActive(true);
                }
            }
            else
            {
                selectedSprite.SetActive(false);
                duplicatedSprite.SetActive(false);
            }

            if (DupIsDiscableOnSelectAnotherObj)
            {
                if (isShowTime)
                {
                    isDuplicated = false;
                    DupIsDiscableOnSelectAnotherObj = false;
                }
            }

            if (mt)
            {
                mt.objectSelected = objectSelected;
            }

            if (isShowTime)
            {
                inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

                groupNumber.SetActive(true);
                Layer.SetActive(true);

                posX = objectSelected.transform.position.x;
                posY = objectSelected.transform.position.y;
                posZ = objectSelected.transform.position.z;

                rotX = objectSelected.transform.localEulerAngles.x;
                rotY = objectSelected.transform.localEulerAngles.y;
                rotZ = objectSelected.transform.localEulerAngles.z;

                scaX = objectSelected.transform.localScale.x;
                scaY = objectSelected.transform.localScale.y;
                scaZ = objectSelected.transform.localScale.z;

                posXI.text = posX.ToString();
                posYI.text = posY.ToString();
                posZI.text = posZ.ToString();

                rotXI.text = rotX.ToString();
                rotYI.text = rotY.ToString();
                rotZI.text = rotZ.ToString();

                scaXI.text = scaX.ToString();
                scaYI.text = scaY.ToString();
                scaZI.text = scaZ.ToString();

                selectedSprite.transform.position = objectSelected.transform.position;
                selectedSprite.transform.rotation = objectSelected.transform.rotation;
                selectedSprite.transform.localScale = objectSelected.transform.localScale;

                duplicatedSprite.transform.position = objectSelected.transform.position;
                duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
                duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

                objectGroup = objPro.group;
                groupInput.text = objectGroup.ToString();

                if (objectSelected.GetComponent<SpriteRenderer>())
                {
                    layerInput.text = objectSelected.GetComponent<SpriteRenderer>().sortingOrder.ToString();
                }
                else if(objectSelected.name == "CameraControl")
                {
                    layerInput.text = objectSelected.transform.GetChild(0).gameObject.GetComponent<Camera>().depth.ToString();
                }
                else if(objectSelected.name != "CustomObject1")
                {
                    Layer.SetActive(false);
                }

                if (isDuplicated)
                {
                    DupIsDiscableOnSelectAnotherObj = true;
                }

                isShowTime = false;
            }
            else
            {
                if (mt && !mt.canUseTools)
                {
                    posX = float.Parse(posXI.text);
                    posY = float.Parse(posYI.text);
                    posZ = float.Parse(posZI.text);

                    rotX = float.Parse(rotXI.text);
                    rotY = float.Parse(rotYI.text);
                    rotZ = float.Parse(rotZI.text);

                    scaX = float.Parse(scaXI.text);
                    scaY = float.Parse(scaYI.text);
                    scaZ = float.Parse(scaZI.text);

                    if (objectSelected.name != "LevelCompletedTrigger")
                    {
                        objectGroup = float.Parse(groupInput.text);
                    }

                    Vector3 xD = new Vector3(posX, posY, posZ);
                    Quaternion xD2 = Quaternion.Euler(rotX, rotY, rotZ);
                    Vector3 xD3 = new Vector3(scaX, scaY, scaZ);
                    objectSelected.transform.position = xD;
                    objectSelected.transform.rotation = xD2;
                    objectSelected.transform.localScale = xD3;

                    selectedSprite.transform.position = objectSelected.transform.position;
                    selectedSprite.transform.rotation = objectSelected.transform.rotation;
                    selectedSprite.transform.localScale = objectSelected.transform.localScale;

                    duplicatedSprite.transform.position = objectSelected.transform.position;
                    duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
                    duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

                    moveTool.transform.rotation = xD2;
                    scaleTool.transform.rotation = xD2;

                    objPro.group = objectGroup;

                    if (objectSelected.GetComponent<SpriteRenderer>())
                    {
                        if (objectSelected.name != "LevelCompletedTrigger")
                        {
                            objectSelected.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(layerInput.text);
                        }
                    }
                    else if(objectSelected.name == "CameraControl")
                    {
                        objectSelected.transform.GetChild(0).gameObject.GetComponent<Camera>().depth = int.Parse(layerInput.text);
                    }
                    else
                    {
                        Layer.SetActive(false);
                    }

                }
                else
                {
                    posX = objectSelected.transform.position.x;
                    posY = objectSelected.transform.position.y;
                    posZ = objectSelected.transform.position.z;

                    rotX = objectSelected.transform.localEulerAngles.x;
                    rotY = objectSelected.transform.localEulerAngles.y;
                    rotZ = objectSelected.transform.localEulerAngles.z;

                    scaX = objectSelected.transform.localScale.x;
                    scaY = objectSelected.transform.localScale.y;
                    scaZ = objectSelected.transform.localScale.z;

                    posXI.text = posX.ToString();
                    posYI.text = posY.ToString();
                    posZI.text = posZ.ToString();

                    rotXI.text = rotX.ToString();
                    rotYI.text = rotY.ToString();
                    rotZI.text = rotZ.ToString();

                    scaXI.text = scaX.ToString();
                    scaYI.text = scaY.ToString();
                    scaZI.text = scaZ.ToString();

                    selectedSprite.transform.position = objectSelected.transform.position;
                    selectedSprite.transform.rotation = objectSelected.transform.rotation;
                    selectedSprite.transform.localScale = objectSelected.transform.localScale;

                    duplicatedSprite.transform.position = objectSelected.transform.position;
                    duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
                    duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

                    if (objectSelected.GetComponent<SpriteRenderer>())
                    {
                        objectSelected.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(layerInput.text);
                    }
                    else if (objectSelected.name == "CameraControl")
                    {
                        objectSelected.transform.GetChild(0).gameObject.GetComponent<Camera>().depth = int.Parse(layerInput.text);
                    }
                    else
                    {
                        Layer.SetActive(false);
                    }

                    objectGroup = float.Parse(groupInput.text);
                    objPro.group = objectGroup;
                }
            }

            if (posXI.isFocused || posYI.isFocused || posZI.isFocused || rotXI.isFocused || rotYI.isFocused || rotZI.isFocused || scaXI.isFocused || scaYI.isFocused || scaZI.isFocused)
            {
                moveTool.transform.position = objectSelected.transform.position;
                scaleTool.transform.position = objectSelected.transform.position;
                mt.canUseTools = false;
                mt.canMove = false;
                mt.canRotate = false;
                mt.canScale = false;
            }
        }
        else
        {
            selectedSprite.SetActive(false);
            duplicatedSprite.SetActive(false);
            mt.canUseTools = false;
            mt.canMove = false;
            mt.canRotate = false;
            mt.canScale = false;
            moveTool.SetActive(false);
            moveButton.SetActive(false);
            scaleTool.SetActive(false);
            scaleButton.SetActive(false);
            mt.OnDeselect();
        }
	}

    public void EditColorTrigger()
    {

        colorPreview = new Color(objectSelected.GetComponent<ColorTrigger>().r / 255, objectSelected.GetComponent<ColorTrigger>().g / 255, objectSelected.GetComponent<ColorTrigger>().b / 255, objectSelected.GetComponent<ColorTrigger>().a / 255);
        colorPreviewImage.color = colorPreview;

        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            rSlider.value = objectSelected.GetComponent<ColorTrigger>().r / 255;
            gSlider.value = objectSelected.GetComponent<ColorTrigger>().g / 255;
            bSlider.value = objectSelected.GetComponent<ColorTrigger>().b / 255;
            aSlider.value = objectSelected.GetComponent<ColorTrigger>().a / 255;

            rInput.text = objectSelected.GetComponent<ColorTrigger>().r.ToString();
            gInput.text = objectSelected.GetComponent<ColorTrigger>().g.ToString();
            bInput.text = objectSelected.GetComponent<ColorTrigger>().b.ToString();
            aInput.text = objectSelected.GetComponent<ColorTrigger>().a.ToString();

            colorSeconds = objectSelected.GetComponent<ColorTrigger>().seconds;
            inputSeconds.text = colorSeconds.ToString();

            groupVisual.text = objPro.group.ToString();

            isShowTime = false;
        }
        else
        {

            objectSelected.GetComponent<ColorTrigger>().seconds = colorSeconds;
            colorSeconds = float.Parse(inputSeconds.text);

            objectSelected.GetComponent<ColorTrigger>().group = objPro.group;

            groupVisual.text = objPro.group.ToString();

            if (rInput.isFocused || gInput.isFocused || bInput.isFocused || aInput.isFocused)
            {

                objectSelected.GetComponent<ColorTrigger>().r = float.Parse(rInput.text);
                objectSelected.GetComponent<ColorTrigger>().g = float.Parse(gInput.text);
                objectSelected.GetComponent<ColorTrigger>().b = float.Parse(bInput.text);
                objectSelected.GetComponent<ColorTrigger>().a = float.Parse(aInput.text);

                rSlider.value = objectSelected.GetComponent<ColorTrigger>().r / 255;
                gSlider.value = objectSelected.GetComponent<ColorTrigger>().g / 255;
                bSlider.value = objectSelected.GetComponent<ColorTrigger>().b / 255;
                aSlider.value = objectSelected.GetComponent<ColorTrigger>().a / 255;


                //if the value is more than 255

                if (objectSelected.GetComponent<ColorTrigger>().r > 255)
                {
                    objectSelected.GetComponent<ColorTrigger>().r = 255;
                    rInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().g > 255)
                {
                    objectSelected.GetComponent<ColorTrigger>().g = 255;
                    gInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().b > 255)
                {
                    objectSelected.GetComponent<ColorTrigger>().b = 255;
                    bInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().a > 255)
                {
                    objectSelected.GetComponent<ColorTrigger>().a = 255;
                    aInput.text = 255.ToString();
                }

                //if the value is more than 0

                if (objectSelected.GetComponent<ColorTrigger>().r < 0)
                {
                    objectSelected.GetComponent<ColorTrigger>().r = 0;
                    rInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().g < 0)
                {
                    objectSelected.GetComponent<ColorTrigger>().g = 0;
                    gInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().b < 0)
                {
                    objectSelected.GetComponent<ColorTrigger>().b = 0;
                    bInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<ColorTrigger>().a < 0)
                {
                    objectSelected.GetComponent<ColorTrigger>().a = 0;
                    aInput.text = 0.ToString();
                }
            }
            else
            {
                objectSelected.GetComponent<ColorTrigger>().r = rSlider.value * 255;
                objectSelected.GetComponent<ColorTrigger>().g = gSlider.value * 255;
                objectSelected.GetComponent<ColorTrigger>().b = bSlider.value * 255;
                objectSelected.GetComponent<ColorTrigger>().a = aSlider.value * 255;

                rInput.text = (rSlider.value * 255).ToString();
                gInput.text = (gSlider.value * 255).ToString();
                bInput.text = (bSlider.value * 255).ToString();
                aInput.text = (aSlider.value * 255).ToString();
            }
        }
    }

    public void EditMoveTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            xMoveInput.text = objectSelected.GetComponent<MoveTrigger>().x.ToString();
            yMoveInput.text = objectSelected.GetComponent<MoveTrigger>().y.ToString();
            zMoveInput.text = objectSelected.GetComponent<MoveTrigger>().z.ToString();
            moveSeconds = objectSelected.GetComponent<MoveTrigger>().seconds;
            inputMoveSeconds.text = moveSeconds.ToString();

            moveVisual.text = objPro.group.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<MoveTrigger>().seconds = moveSeconds;
            moveSeconds = float.Parse(inputMoveSeconds.text);

            objectSelected.GetComponent<MoveTrigger>().group = objPro.group;

            moveVisual.text = objPro.group.ToString();

            objectSelected.GetComponent<MoveTrigger>().x = float.Parse(xMoveInput.text);
            objectSelected.GetComponent<MoveTrigger>().y = float.Parse(yMoveInput.text);
            objectSelected.GetComponent<MoveTrigger>().z = float.Parse(zMoveInput.text);
        }
    }

    public void EditRotateTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            xRotateInput.text = objectSelected.GetComponent<RotateTrigger>().x.ToString();
            yRotateInput.text = objectSelected.GetComponent<RotateTrigger>().y.ToString();
            zRotateInput.text = objectSelected.GetComponent<RotateTrigger>().z.ToString();
            rotateSeconds = objectSelected.GetComponent<RotateTrigger>().seconds;
            inputRotateSeconds.text = rotateSeconds.ToString();
            inputCenterIsAnotherGroup.text = objectSelected.GetComponent<RotateTrigger>().groupObject.ToString();

            rotateVisual.text = objPro.group.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<RotateTrigger>().seconds = rotateSeconds;
            rotateSeconds = float.Parse(inputRotateSeconds.text);

            objectSelected.GetComponent<RotateTrigger>().groupObject = float.Parse(inputCenterIsAnotherGroup.text);

            objectSelected.GetComponent<RotateTrigger>().group = objPro.group;

            rotateVisual.text = objPro.group.ToString();

            objectSelected.GetComponent<RotateTrigger>().x = float.Parse(xRotateInput.text);
            objectSelected.GetComponent<RotateTrigger>().y = float.Parse(yRotateInput.text);
            objectSelected.GetComponent<RotateTrigger>().z = float.Parse(zRotateInput.text);
        }
    }

    public void CIAG(bool change)
    {
        objectSelected.GetComponent<RotateTrigger>().rotateInObject = change;
        inputCenterIsAnotherGroup.gameObject.SetActive(change);
    }

    public void EditScaleTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            xScaleInput.text = objectSelected.GetComponent<ScaleTrigger>().x.ToString();
            yScaleInput.text = objectSelected.GetComponent<ScaleTrigger>().y.ToString();
            zScaleInput.text = objectSelected.GetComponent<ScaleTrigger>().z.ToString();
            scaleSeconds = objectSelected.GetComponent<ScaleTrigger>().seconds;
            inputScaleSeconds.text = scaleSeconds.ToString();

            scaleVisual.text = objPro.group.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<ScaleTrigger>().seconds = scaleSeconds;
            scaleSeconds = float.Parse(inputScaleSeconds.text);

            objectSelected.GetComponent<ScaleTrigger>().group = objPro.group;

            scaleVisual.text = objPro.group.ToString();

            objectSelected.GetComponent<ScaleTrigger>().x = float.Parse(xScaleInput.text);
            objectSelected.GetComponent<ScaleTrigger>().y = float.Parse(yScaleInput.text);
            objectSelected.GetComponent<ScaleTrigger>().z = float.Parse(zScaleInput.text);
        }
    }

    public void EditBloomTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(false);
            Layer.SetActive(false);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            bIntensityInput.text = objectSelected.GetComponent<BloomTrigger>().intensityGoal.ToString();
            bThresholdInput.text = objectSelected.GetComponent<BloomTrigger>().thresholdGoal.ToString();
            bloomSeconds = objectSelected.GetComponent<BloomTrigger>().seconds;
            bSecondsInput.text = bloomSeconds.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<BloomTrigger>().seconds = bloomSeconds;
            bloomSeconds = float.Parse(bSecondsInput.text);

            objectSelected.GetComponent<BloomTrigger>().intensityGoal = float.Parse(bIntensityInput.text);
            objectSelected.GetComponent<BloomTrigger>().thresholdGoal = float.Parse(bThresholdInput.text);
        }
    }

    public void EditTVTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(false);
            Layer.SetActive(false);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            scanLinesSlider.value = objectSelected.GetComponent<TVTrigger>().scanLinesGoal;
            colorDriftSlider.value = objectSelected.GetComponent<TVTrigger>().colorDriftGoal;
            tvSeconds = objectSelected.GetComponent<TVTrigger>().seconds;
            tvSecondsInput.text = tvSeconds.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<TVTrigger>().seconds = tvSeconds;
            tvSeconds = float.Parse(tvSecondsInput.text);

            objectSelected.GetComponent<TVTrigger>().scanLinesGoal = scanLinesSlider.value;
            objectSelected.GetComponent<TVTrigger>().colorDriftGoal = colorDriftSlider.value;
        }
    }

    public void EditDisableEnableTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            disableEnableVisual.text = objPro.group.ToString();

            if (objectSelected.GetComponent<DisableEnableTrigger>().disableOrEnable)
            {
                disableEnableBool.isOn = true;
            }
            else
            {
                disableEnableBool.isOn = false;
            }

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<DisableEnableTrigger>().group = objPro.group;
            disableEnableVisual.text = objPro.group.ToString();
        }
    }

    public void Disable(bool enable)
    {
        if (enable)
        {
            disableEnableTitle.text = "ENABLE";
            objectSelected.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = enableSprite;
        }
        else
        {
            disableEnableTitle.text = "DISABLE";
            objectSelected.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = disableSprite;
        }

        objectSelected.GetComponent<DisableEnableTrigger>().disableOrEnable = enable;
    }

    public void EditFollowTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            groupFollowInput.text = objectSelected.GetComponent<FollowTrigger>().groupToFollow.ToString();

            followVisual.text = objPro.group.ToString();

            if (objectSelected.GetComponent<FollowTrigger>().follow)
            {
                followUnfollowBool.isOn = true;
            }
            else
            {
                followUnfollowBool.isOn = false;
            }

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<FollowTrigger>().group = objPro.group;
            followVisual.text = objPro.group.ToString();
            objectSelected.GetComponent<FollowTrigger>().groupToFollow = float.Parse(groupFollowInput.text);
        }
    }

    public void FollowUnfollow(bool enable)
    {
        objectSelected.GetComponent<FollowTrigger>().follow = enable;
    }

    public void EditCustomObject()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(true);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            inputImageFileName.text = objectSelected.transform.GetChild(0).gameObject.GetComponent<CustomObject>().nameImage;
            loadButton.interactable = true;

            imageFileInfo.text = "";

            layerInput.text = objectSelected.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.transform.GetChild(0).gameObject.GetComponent<CustomObject>().nameImage = inputImageFileName.text;
            objectSelected.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(layerInput.text);
        }
    }

    public void LoadImage()
    {
        StartCoroutine(objectSelected.transform.GetChild(0).gameObject.GetComponent<CustomObject>().DownloadImage(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + rM.levelName + "/Sprites/" + objectSelected.transform.GetChild(0).gameObject.GetComponent<CustomObject>().nameImage));
        imageFileInfo.text = "<color=#FFFF00FF>Loading Image...</color>";
        loadButton.interactable = false;
    }

    public void OnFailedLoadImage()
    {
        loadButton.interactable = true;
        imageFileInfo.text = "<color=#FF8787FF>ERROR: Image File not found!</color>";
    }

    public void OnFinishedLoadImage()
    {
        loadButton.interactable = true;
        imageFileInfo.text = "<color=#5DFF00FF>Image Loaded!</color>";
    }

    public void EditStartColorTrigger()
    {

        SCColorPreview = objectSelected.GetComponent<StartColor>().groupColor;
        SCColorPreviewImage.color = SCColorPreview;

        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(true);
            Layer.SetActive(false);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            objectGroup = objPro.group;
            groupInput.text = objectGroup.ToString();

            SCRSlider.value = objectSelected.GetComponent<StartColor>().groupColor.r;
            SCGSlider.value = objectSelected.GetComponent<StartColor>().groupColor.g;
            SCBSlider.value = objectSelected.GetComponent<StartColor>().groupColor.b;
            SCASlider.value = objectSelected.GetComponent<StartColor>().groupColor.a;

            SCRInput.text = (objectSelected.GetComponent<StartColor>().groupColor.r * 255).ToString();
            SCGInput.text = (objectSelected.GetComponent<StartColor>().groupColor.g * 255).ToString();
            SCBInput.text = (objectSelected.GetComponent<StartColor>().groupColor.b * 255).ToString();
            SCAInput.text = (objectSelected.GetComponent<StartColor>().groupColor.a * 255).ToString();

            startColorVisual.text = objPro.group.ToString();

            isShowTime = false;
        }
        else
        {
            objectSelected.GetComponent<StartColor>().group = objPro.group;

            startColorVisual.text = objPro.group.ToString();

            if (SCRInput.isFocused || SCGInput.isFocused || SCBInput.isFocused || SCAInput.isFocused)
            {
                objectSelected.GetComponent<StartColor>().groupColor.r = float.Parse(SCRInput.text) / 255;
                objectSelected.GetComponent<StartColor>().groupColor.g = float.Parse(SCGInput.text) / 255;
                objectSelected.GetComponent<StartColor>().groupColor.b = float.Parse(SCGInput.text) / 255;
                objectSelected.GetComponent<StartColor>().groupColor.a = float.Parse(SCAInput.text) / 255;

                SCRSlider.value = objectSelected.GetComponent<StartColor>().groupColor.r;
                SCGSlider.value = objectSelected.GetComponent<StartColor>().groupColor.g;
                SCBSlider.value = objectSelected.GetComponent<StartColor>().groupColor.b;
                SCASlider.value = objectSelected.GetComponent<StartColor>().groupColor.a;


                //if the value is more than 255

                if (objectSelected.GetComponent<StartColor>().groupColor.r > 1f)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.r = 1f;
                    SCRInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.g > 1f)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.g = 1f;
                    SCGInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.b > 1f)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.b = 1f;
                    SCBInput.text = 255.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.a > 1f)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.a = 1f;
                    SCAInput.text = 255.ToString();
                }

                //if the value is more than 0

                if (objectSelected.GetComponent<StartColor>().groupColor.r < 0)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.r = 0;
                    SCRInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.g < 0)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.g = 0;
                    SCGInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.b < 0)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.b = 0;
                    SCBInput.text = 0.ToString();
                }
                else if (objectSelected.GetComponent<StartColor>().groupColor.a < 0)
                {
                    objectSelected.GetComponent<StartColor>().groupColor.a = 0;
                    SCAInput.text = 0.ToString();
                }
            }
            else
            {
                objectSelected.GetComponent<StartColor>().groupColor.r = SCRSlider.value;
                objectSelected.GetComponent<StartColor>().groupColor.g = SCGSlider.value;
                objectSelected.GetComponent<StartColor>().groupColor.b = SCBSlider.value;
                objectSelected.GetComponent<StartColor>().groupColor.a = SCASlider.value;

                SCRInput.text = (objectSelected.GetComponent<StartColor>().groupColor.r * 255).ToString();
                SCGInput.text = (objectSelected.GetComponent<StartColor>().groupColor.g * 255).ToString();
                SCBInput.text = (objectSelected.GetComponent<StartColor>().groupColor.b * 255).ToString();
                SCAInput.text = (objectSelected.GetComponent<StartColor>().groupColor.a * 255).ToString();
            }
        }
    }

    public void EditLevelCompletedTrigger()
    {
        if (isShowTime)
        {
            inspectorContent.transform.position = new Vector3(inspectorContent.transform.position.x, inspectorResetPosition.position.y, inspectorContent.transform.position.z);

            groupNumber.SetActive(false);
            Layer.SetActive(false);

            posX = objectSelected.transform.position.x;
            posY = objectSelected.transform.position.y;
            posZ = objectSelected.transform.position.z;

            rotX = objectSelected.transform.localEulerAngles.x;
            rotY = objectSelected.transform.localEulerAngles.y;
            rotZ = objectSelected.transform.localEulerAngles.z;

            scaX = objectSelected.transform.localScale.x;
            scaY = objectSelected.transform.localScale.y;
            scaZ = objectSelected.transform.localScale.z;

            posXI.text = posX.ToString();
            posYI.text = posY.ToString();
            posZI.text = posZ.ToString();

            rotXI.text = rotX.ToString();
            rotYI.text = rotY.ToString();
            rotZI.text = rotZ.ToString();

            scaXI.text = scaX.ToString();
            scaYI.text = scaY.ToString();
            scaZI.text = scaZ.ToString();

            selectedSprite.transform.position = objectSelected.transform.position;
            selectedSprite.transform.rotation = objectSelected.transform.rotation;
            selectedSprite.transform.localScale = objectSelected.transform.localScale;

            duplicatedSprite.transform.position = objectSelected.transform.position;
            duplicatedSprite.transform.rotation = objectSelected.transform.rotation;
            duplicatedSprite.transform.localScale = objectSelected.transform.localScale;

            isShowTime = false;
        }
    }
}
