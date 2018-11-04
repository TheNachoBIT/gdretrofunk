using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartColor : MonoBehaviour {

    public float group;
    public Color groupColor;
    public bool findPosition;
    public TestManager testM;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerPoint;

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

    // Use this for initialization
    void Start()
    {
        findPosition = true;
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        wait = new WaitForSeconds(0.02f);
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
        playerPoint = GameObject.Find("PlayerPoint");
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        allObjects = GameObject.FindGameObjectsWithTag("Objects");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        player = GameObject.Find("Player");

        if (!testM.isTesting)
        {
            onStart = true;

            foreach (GameObject m in allObjects)
            {
                if (m.GetComponent<ObjectPriorities>().group == group)
                {
                    if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                    {
                        if (m.name != "CustomObject1" || m.name != "KillZone")
                        {
                            if (!ObjectsInsideGroup.Contains(m))
                            {
                                ObjectsInsideGroup.Add(m);
                            }
                        }
                        else
                        {
                            if (!ObjectsInsideGroup.Contains(m.transform.GetChild(0).gameObject))
                            {
                                ObjectsInsideGroup.Add(m.transform.GetChild(0).gameObject);
                            }
                        }
                    }
                }
                else
                {
                    if (m.name != "CustomObject1" || m.name != "KillZone")
                    {
                        ObjectsInsideGroup.Remove(m);
                    }
                    else
                    {
                        ObjectsInsideGroup.Remove(m.transform.GetChild(0).gameObject);
                    }
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
                            if (m.GetComponent<ColorTrigger>())
                            {
                                if (!TriggersInsideGroup.Contains(m))
                                {
                                    TriggersInsideGroup.Add(m);
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
                else
                {
                    TriggersInsideGroup.Remove(m);
                }
            }
        }

        if (!testM.isTesting)
        {
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

            foreach (GameObject m in ObjectsInsideGroup)
            {
                m.GetComponent<SpriteRenderer>().color = new Color(groupColor.r, groupColor.g, groupColor.b, m.GetComponent<SpriteRenderer>().color.a);
            }

            foreach (GameObject m in CamerasInsideGroup)
            {
                m.transform.GetChild(0).GetComponent<Camera>().backgroundColor = groupColor;
            }

            foreach (GameObject m in TriggersInsideGroup)
            {
                m.GetComponent<ColorTrigger>().rStart = groupColor.r;
                m.GetComponent<ColorTrigger>().gStart = groupColor.g;
                m.GetComponent<ColorTrigger>().bStart = groupColor.b;
                m.GetComponent<ColorTrigger>().aStart = groupColor.a;
            }

            if (transform.position.x != playerPoint.transform.position.x)
            {
                Vector3 vec = new Vector3(playerPoint.transform.position.x, transform.position.y, transform.position.z);

                transform.position = vec;
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
                        if (m.name != "CustomObject1" || m.name != "KillZone")
                        {
                            if (!ObjectsInsideGroup.Contains(m))
                            {
                                ObjectsInsideGroup.Add(m);
                            }
                        }
                        else
                        {
                            if (!ObjectsInsideGroup.Contains(m.transform.GetChild(0).gameObject))
                            {
                                ObjectsInsideGroup.Add(m.transform.GetChild(0).gameObject);
                            }
                        }
                    }
                }
                else
                {
                    if (m.name != "CustomObject1" || m.name != "KillZone")
                    {
                        ObjectsInsideGroup.Remove(m);
                    }
                    else
                    {
                        ObjectsInsideGroup.Remove(m.transform.GetChild(0).gameObject);
                    }
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
                            if (m.GetComponent<ColorTrigger>())
                            {
                                if (!TriggersInsideGroup.Contains(m))
                                {
                                    TriggersInsideGroup.Add(m);
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
                else
                {
                    TriggersInsideGroup.Remove(m);
                }
            }
            onStart = false;
        }
    }

}

