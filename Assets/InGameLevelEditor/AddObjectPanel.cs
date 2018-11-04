using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObjectPanel : MonoBehaviour {

    [SerializeField] private GameObject addObPanel;
    [SerializeField] private GameObject addTrPanel;
    [SerializeField] private Transform setObjToEdit;
    [SerializeField] private Layers layers;

    //Objects

    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject object4;
    [SerializeField] private GameObject object5;
    [SerializeField] private GameObject object6;
    [SerializeField] private GameObject object7;
    [SerializeField] private GameObject object8;
    [SerializeField] private GameObject object9;
    [SerializeField] private GameObject object10;
    [SerializeField] private GameObject object11;
    [SerializeField] private GameObject object12;
    [SerializeField] private GameObject object13;
    [SerializeField] private GameObject object14;
    [SerializeField] private GameObject object15;
    [SerializeField] private GameObject object16;
    [SerializeField] private GameObject object17;
    [SerializeField] private GameObject object18;
    [SerializeField] private GameObject object19;
    [SerializeField] private GameObject object20;
    [SerializeField] private GameObject object21;
    [SerializeField] private GameObject object22;
    [SerializeField] private GameObject object23;
    [SerializeField] private GameObject object24;
    [SerializeField] private GameObject object25;
    [SerializeField] private GameObject object26;
    [SerializeField] private GameObject object27;
    [SerializeField] private GameObject object28;
    [SerializeField] private GameObject object29;
    [SerializeField] private GameObject object30;
    [SerializeField] private GameObject object31;
    [SerializeField] private GameObject spike1;
    [SerializeField] private GameObject killzone;
    [SerializeField] private GameObject customObject1;

    //Triggers

    [SerializeField] private GameObject Color;
    [SerializeField] private GameObject Move;
    [SerializeField] private GameObject Rotate;
    [SerializeField] private GameObject Scale;
    [SerializeField] private GameObject Bloom;
    [SerializeField] private GameObject TV;
    [SerializeField] private GameObject DisableEnable;
    [SerializeField] private GameObject Follow;
    [SerializeField] private GameObject StartColor;

    [SerializeField] private Camera cameraMain;
    [SerializeField] private EditObject edO;
    [SerializeField] private MenuTools meT;

	// Use this for initialization
	void Start () {
        addObPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddObjectPanelOpen()
    {
        addObPanel.SetActive(true);
    }

    public void AddObjectPanelClose()
    {
        addObPanel.SetActive(false);
    }

    public void AddTriggerPanelOpen()
    {
        addTrPanel.SetActive(true);
    }

    public void AddTriggerPanelClose()
    {
        addTrPanel.SetActive(false);
    }

    //Add Objects

    public void AddObject1()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object1, vec, Quaternion.identity) as GameObject;
        clone.name = "Object1";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject2()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object2, vec, Quaternion.identity) as GameObject;
        clone.name = "Object2";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject3()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object3, vec, Quaternion.identity) as GameObject;
        clone.name = "Object3";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject4()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object4, vec, Quaternion.identity) as GameObject;
        clone.name = "Object4";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject5()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object5, vec, Quaternion.identity) as GameObject;
        clone.name = "Object5";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject6()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object6, vec, Quaternion.identity) as GameObject;
        clone.name = "Object6";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject7()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object7, vec, Quaternion.identity) as GameObject;
        clone.name = "Object7";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject8()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object8, vec, Quaternion.identity) as GameObject;
        clone.name = "Object8";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject9()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object9, vec, Quaternion.identity) as GameObject;
        clone.name = "Object9";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject10()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object10, vec, Quaternion.identity) as GameObject;
        clone.name = "Object10";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject11()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object11, vec, Quaternion.identity) as GameObject;
        clone.name = "Object11";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject12()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object12, vec, Quaternion.identity) as GameObject;
        clone.name = "Object12";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject13()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object13, vec, Quaternion.identity) as GameObject;
        clone.name = "Object13";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject14()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object14, vec, Quaternion.identity) as GameObject;
        clone.name = "Object14";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject15()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object15, vec, Quaternion.identity) as GameObject;
        clone.name = "Object15";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject16()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object16, vec, Quaternion.identity) as GameObject;
        clone.name = "Object16";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject17()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object17, vec, Quaternion.identity) as GameObject;
        clone.name = "Object17";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject18()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object18, vec, Quaternion.identity) as GameObject;
        clone.name = "Object18";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject19()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object19, vec, Quaternion.identity) as GameObject;
        clone.name = "Object19";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject20()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object8, vec, Quaternion.identity) as GameObject;
        clone.name = "Object20";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject21()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object21, vec, Quaternion.identity) as GameObject;
        clone.name = "Object21";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject22()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object22, vec, Quaternion.identity) as GameObject;
        clone.name = "Object22";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject23()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object23, vec, Quaternion.identity) as GameObject;
        clone.name = "Object23";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject24()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object24, vec, Quaternion.identity) as GameObject;
        clone.name = "Object24";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject25()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object25, vec, Quaternion.identity) as GameObject;
        clone.name = "Object25";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject26()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object26, vec, Quaternion.identity) as GameObject;
        clone.name = "Object26";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject27()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object27, vec, Quaternion.identity) as GameObject;
        clone.name = "Object27";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject28()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object28, vec, Quaternion.identity) as GameObject;
        clone.name = "Object28";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject29()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object29, vec, Quaternion.identity) as GameObject;
        clone.name = "Object29";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject30()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object30, vec, Quaternion.identity) as GameObject;
        clone.name = "Object30";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
    public void AddObject31()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(object31, vec, Quaternion.identity) as GameObject;
        clone.name = "Object31";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }

    public void AddSpike1()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(spike1, vec, Quaternion.identity) as GameObject;
        clone.name = "Spike1";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }

    public void AddKillZone()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(killzone, vec, Quaternion.identity) as GameObject;
        clone.name = "KillZone";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }

    //Add Triggers

    public void AddColorTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Color, vec, Quaternion.identity) as GameObject;
        clone.name = "ColorTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddMoveTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Move, vec, Quaternion.identity) as GameObject;
        clone.name = "MoveTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddRotateTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Rotate, vec, Quaternion.identity) as GameObject;
        clone.name = "RotateTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddScaleTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Scale, vec, Quaternion.identity) as GameObject;
        clone.name = "ScaleTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddBloomTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Bloom, vec, Quaternion.identity) as GameObject;
        clone.name = "BloomTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddTVTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(TV, vec, Quaternion.identity) as GameObject;
        clone.name = "TVTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddDisableEnableTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(DisableEnable, vec, Quaternion.identity) as GameObject;
        clone.name = "DisableEnableTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddFollowTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(Follow, vec, Quaternion.identity) as GameObject;
        clone.name = "FollowTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddStartColorTrigger()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(StartColor, vec, Quaternion.identity) as GameObject;
        clone.name = "StartColorTrigger";
        setObjToEdit = clone.GetComponent<Transform>();
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addTrPanel.SetActive(false);
    }

    public void AddCustomObject()
    {
        Vector3 vec = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, 0);
        GameObject clone = Instantiate(customObject1, vec, Quaternion.identity) as GameObject;
        clone.name = "CustomObject1";
        setObjToEdit = clone.GetComponent<Transform>();
        if (!layers.all)
        {
            int layerxd = (int)(layers.layer);
            setObjToEdit.GetComponent<SpriteRenderer>().sortingOrder = layerxd;
        }
        edO.objectSelected = setObjToEdit.gameObject;
        edO.isShowTime = true;
        if (meT.canUseTools)
        {
            meT.objectSelected = setObjToEdit.gameObject;
        }
        addObPanel.SetActive(false);
    }
}
