using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableTrigger : MonoBehaviour {


    public float group;
    public bool findPosition;
    public bool disableOrEnable;
    public TestManager testM;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] allObjects;
    [SerializeField] private GameObject[] allCameras;
    [SerializeField] private GameObject[] allTriggers;

    [SerializeField] private List<GameObject> allObjectsInsideTriggers;

    private EditObject edO;

    private bool onStart;

    public WaitForSeconds wait;

    public List<GameObject> ObjectsInsideGroup;
    public List<GameObject> CamerasInsideGroup;
    public List<GameObject> TriggersInsideGroup;

    private GameObject levelObjectsManager;

    private bool isReadyToGo;

    // Use this for initialization
    void Start()
    {
        findPosition = true;
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        wait = new WaitForSeconds(0.02f);
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        allObjects = GameObject.FindGameObjectsWithTag("Objects");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        player = GameObject.Find("Player");

        switch (testM.isTesting)
        {
            case false:

                onStart = true;

                for (var i = ObjectsInsideGroup.Count - 1; i > -1; i--)
                {
                    if (ObjectsInsideGroup[i] == null)
                        ObjectsInsideGroup.RemoveAt(i);
                }

                for (var i = CamerasInsideGroup.Count - 1; i > -1; i--)
                {
                    if (CamerasInsideGroup[i] == null)
                        CamerasInsideGroup.RemoveAt(i);
                }

                for (var i = TriggersInsideGroup.Count - 1; i > -1; i--)
                {
                    if (TriggersInsideGroup[i] == null)
                        TriggersInsideGroup.RemoveAt(i);
                }
                break;
        }

        if (!testM.isTesting)
        {
            if (edO.objectSelected == gameObject)
            {
                foreach (GameObject m in allObjects)
                {
                    if (m.GetComponent<ObjectPriorities>().group == group)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            if (!ObjectsInsideGroup.Contains(m))
                            {
                                ObjectsInsideGroup.Add(m);
                            }
                        }
                    }
                    else
                    {
                        ObjectsInsideGroup.Remove(m);
                    }
                }

                foreach (GameObject m in allCameras)
                {
                    if (m.GetComponent<ObjectPriorities>().group == group)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            if (!CamerasInsideGroup.Contains(m))
                            {
                                CamerasInsideGroup.Add(m);
                            }
                        }
                    }
                    else
                    {
                        CamerasInsideGroup.Remove(m);
                    }
                }

                foreach (GameObject m in allTriggers)
                {
                    if (m.GetComponent<ObjectPriorities>())
                    {
                        if (m.GetComponent<ObjectPriorities>().group == group)
                        {
                            if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                            {
                                if (m.GetComponent<MoveTrigger>())
                                {
                                    if (m.GetComponent<MoveTrigger>() != this.GetComponent<MoveTrigger>())
                                    {
                                        if (m.transform.position.x < transform.position.x)
                                        {
                                            if (!TriggersInsideGroup.Contains(m))
                                            {
                                                TriggersInsideGroup.Add(m);
                                            }
                                        }
                                        else
                                        {
                                            Debug.Log("xd");
                                            TriggersInsideGroup.Remove(m);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        TriggersInsideGroup.Remove(m);
                    }
                }
            }

            foreach (GameObject m in ObjectsInsideGroup)
            {
                m.SetActive(true);
                isReadyToGo = false;
            }
            foreach (GameObject m in CamerasInsideGroup)
            {
                m.SetActive(true);
                isReadyToGo = false;
            }
        }

        if(testM.isTesting && onStart)
        {
            foreach (GameObject m in allObjects)
            {
                if (m.GetComponent<ObjectPriorities>().group == group)
                {
                    if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                    {
                        if (!ObjectsInsideGroup.Contains(m))
                        {
                            ObjectsInsideGroup.Add(m);
                        }
                    }
                }
                else
                {
                    ObjectsInsideGroup.Remove(m);
                }
            }

            foreach (GameObject m in allCameras)
            {
                if (m.GetComponent<ObjectPriorities>().group == group)
                {
                    if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                    {
                        if (!CamerasInsideGroup.Contains(m))
                        {
                            CamerasInsideGroup.Add(m);
                        }
                    }
                }
                else
                {
                    CamerasInsideGroup.Remove(m);
                }
            }

            foreach (GameObject m in allTriggers)
            {
                if (m.GetComponent<ObjectPriorities>())
                {
                    if (m.GetComponent<ObjectPriorities>().group == group)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            if (m.GetComponent<MoveTrigger>())
                            {
                                if (m.GetComponent<MoveTrigger>() != this.GetComponent<MoveTrigger>())
                                {
                                    if (m.transform.position.x < transform.position.x)
                                    {
                                        if (!TriggersInsideGroup.Contains(m))
                                        {
                                            TriggersInsideGroup.Add(m);
                                        }
                                    }
                                    else
                                    {
                                        Debug.Log("xd");
                                        TriggersInsideGroup.Remove(m);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    TriggersInsideGroup.Remove(m);
                }
            }
            onStart = false;
        }

        if (player)
        {
            if (group != 0)
            {
                if (testM.isTesting)
                {
                    if (player.transform.position.x == gameObject.transform.position.x || player.transform.position.x > gameObject.transform.position.x)
                    {

                        switch (disableOrEnable)
                        {
                            case true:
                                foreach (GameObject m in ObjectsInsideGroup)
                                {
                                    m.SetActive(true);
                                    isReadyToGo = true;
                                }
                                foreach (GameObject m in CamerasInsideGroup)
                                {
                                    m.SetActive(true);
                                    isReadyToGo = true;
                                }
                                Debug.Log("enable!");
                                break;
                            case false:
                                foreach (GameObject m in ObjectsInsideGroup)
                                {
                                    m.SetActive(false);
                                    isReadyToGo = true;
                                }
                                foreach (GameObject m in CamerasInsideGroup)
                                {
                                    m.SetActive(false);
                                    isReadyToGo = true;
                                }
                                Debug.Log("disable!");
                                break;
                        }

                        if (isReadyToGo)
                        {
                            enabled = false;
                        }
                    }
                }
            }
        }
    }
}
