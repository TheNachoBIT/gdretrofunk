using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSpriteIsVisible : MonoBehaviour {

    public Plane[] planes;
    public bool isVisible;
    public TestManager testM;
    public Plane[] editorPlane;
    public Camera editorCamera;

    public GameObject[] gameCameras;
    public EditObject edO;

    private int editorFrames = 0;

    private bool OnReset;
    private bool OnStart;
    private bool OnSet;

    private void Start()
    {
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        editorCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (!testM.isTesting)
        {
            OnStart = true;
            OnSet = false;

            if (testM.canEdit)
            {
                planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
                gameCameras = GameObject.FindGameObjectsWithTag("GameCamera");
            }

            if (OnReset)
            {
                if (gameObject.tag == "Objects")
                {
                    GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, 0.1f);
                }

                if (gameObject.name == "MoveTrigger")
                {
                    GetComponent<MoveTrigger>().enabled = true;
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    GetComponent<RotateTrigger>().enabled = true;
                }
                else if (gameObject.name == "ColorTrigger")
                {
                    GetComponent<ColorTrigger>().enabled = true;
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    GetComponent<ScaleTrigger>().enabled = true;
                }
                else if (gameObject.name == "StartColorTrigger")
                {
                    GetComponent<StartColor>().enabled = true;
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    GetComponent<DisableEnableTrigger>().enabled = true;
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    GetComponent<BloomTrigger>().enabled = true;
                }
                else if (gameObject.name == "TVTrigger")
                {
                    GetComponent<TVTrigger>().enabled = true;
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    GetComponent<FollowTrigger>().enabled = true;
                }
                else if (gameObject.tag == "Objects" && gameObject.name != "CustomObject1")
                {
                    GetComponent<Renderer>().enabled = true;
                }
                OnReset = false;
            }
            else
            {
                editorPlane = GeometryUtility.CalculateFrustumPlanes(editorCamera);
                if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds))
                {
                    if (gameObject.tag == "Objects")
                    {
                        GetComponent<Renderer>().enabled = true;
                    }
                    else if (gameObject.name == "StartColorTrigger")
                    {
                        GetComponent<StartColor>().enabled = true;
                    }

                    if (edO.objectSelected == gameObject)
                    {
                        if (gameObject.name == "MoveTrigger")
                        {
                            GetComponent<MoveTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "RotateTrigger")
                        {
                            GetComponent<RotateTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "ColorTrigger")
                        {
                            GetComponent<ColorTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "ScaleTrigger")
                        {
                            GetComponent<ScaleTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "StartColorTrigger")
                        {
                            GetComponent<StartColor>().enabled = true;
                        }
                        else if (gameObject.name == "DisableEnableTrigger")
                        {
                            GetComponent<DisableEnableTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "BloomTrigger")
                        {
                            GetComponent<BloomTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "TVTrigger")
                        {
                            GetComponent<TVTrigger>().enabled = true;
                        }
                        else if (gameObject.name == "FollowTrigger")
                        {
                            GetComponent<FollowTrigger>().enabled = true;
                        }
                    }
                }
                else
                {
                    if (gameObject.tag == "Objects")
                    {
                        GetComponent<Renderer>().enabled = false;
                    }

                    if (edO.objectSelected != gameObject)
                    {
                        if (gameObject.name == "MoveTrigger")
                        {
                            GetComponent<MoveTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "RotateTrigger")
                        {
                            GetComponent<RotateTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "ColorTrigger")
                        {
                            GetComponent<ColorTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "ScaleTrigger")
                        {
                            GetComponent<ScaleTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "DisableEnableTrigger")
                        {
                            GetComponent<DisableEnableTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "BloomTrigger")
                        {
                            GetComponent<BloomTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "TVTrigger")
                        {
                            GetComponent<TVTrigger>().enabled = false;
                        }
                        else if (gameObject.name == "FollowTrigger")
                        {
                            GetComponent<FollowTrigger>().enabled = false;
                        }
                    }
                }
            }
        }
        else
        {
            OnReset = true;

            if (OnStart)
            {
                if (gameObject.tag == "Objects")
                {
                    GetComponent<Renderer>().enabled = true;
                }
                else if (gameObject.name == "MoveTrigger")
                {
                    GetComponent<MoveTrigger>().enabled = true;
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    GetComponent<RotateTrigger>().enabled = true;
                }
                else if (gameObject.name == "ColorTrigger")
                {
                    GetComponent<ColorTrigger>().enabled = true;
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    GetComponent<ScaleTrigger>().enabled = true;
                }
                else if (gameObject.name == "StartColorTrigger")
                {
                    GetComponent<StartColor>().enabled = true;
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    GetComponent<DisableEnableTrigger>().enabled = true;
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    GetComponent<BloomTrigger>().enabled = true;
                }
                else if (gameObject.name == "TVTrigger")
                {
                    GetComponent<TVTrigger>().enabled = true;
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    GetComponent<FollowTrigger>().enabled = true;
                }
                OnStart = false;
                OnSet = true;
            }
            else if (OnSet)
            {
                if (gameObject.name == "MoveTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<MoveTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<RotateTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<ScaleTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<DisableEnableTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(2).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<BloomTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "TVTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(2).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<TVTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    if (!GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GetComponent<FollowTrigger>().enabled = false;
                        isVisible = false;
                    }
                }
                OnSet = false;
            }
            else if(!OnStart)
            {
                foreach (GameObject m in gameCameras)
                {
                    planes = GeometryUtility.CalculateFrustumPlanes(m.transform.GetChild(0).gameObject.GetComponent<Camera>());
                }

                if (gameObject.tag == "Objects")
                {
                    GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, 10f);
                }

                if (gameObject.tag != "Trigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
                    {
                        GetComponent<Renderer>().enabled = true;
                        isVisible = true;
                    }
                    else
                    {
                        GetComponent<Renderer>().enabled = false;
                        isVisible = false;
                    }
                }
                else if (gameObject.name == "MoveTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<MoveTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "RotateTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<RotateTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "ColorTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<ColorTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "ScaleTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<ScaleTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "StartColorTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<StartColor>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "DisableEnableTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<DisableEnableTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "BloomTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(2).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<BloomTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "TVTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(2).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<TVTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
                else if (gameObject.name == "FollowTrigger")
                {
                    if (GeometryUtility.TestPlanesAABB(planes, transform.GetChild(3).GetComponent<Renderer>().bounds))
                    {
                        GameObject player = GameObject.Find("Player");
                        if (player.transform.position.x < gameObject.transform.position.x)
                        {
                            GetComponent<FollowTrigger>().enabled = true;
                        }
                        isVisible = true;
                    }
                }
            }
        }
    }

    void FrameUpdateOnEditor()
    {

    }
}
