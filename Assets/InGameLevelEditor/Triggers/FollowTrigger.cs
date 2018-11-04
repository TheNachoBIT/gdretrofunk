using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrigger : MonoBehaviour
{

    public float group;
    public float groupToFollow;
    public bool findPosition;
    public bool follow;
    public Transform groupParent;
    public TestManager testM;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] allObjects;
    [SerializeField] private GameObject[] allCameras;
    [SerializeField] private GameObject[] allTriggers;

    private EditObject edO;
    private bool onStart;

    [SerializeField] private List<GameObject> allObjectsInsideTriggers;

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

        if (!testM.isTesting)
        {
            onStart = true;

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

                    if (m.GetComponent<ObjectPriorities>().group == groupToFollow)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || groupToFollow != 0)
                        {
                            if (!groupParent)
                            {
                                groupParent = m.transform;
                            }
                        }
                    }
                    else
                    {
                        groupParent = null;
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
        }

        switch (testM.isTesting)
        {
            case false:
                isReadyToGo = false;
                break;
        }

        if (!testM.isTesting && onStart)
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

                if (m.GetComponent<ObjectPriorities>().group == groupToFollow)
                {
                    if (m.GetComponent<ObjectPriorities>().group != 0 || groupToFollow != 0)
                    {
                        if (!groupParent)
                        {
                            groupParent = m.transform;
                        }
                    }
                }
                else
                {
                    groupParent = null;
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
                        switch (follow) {
                            case true:
                                foreach (GameObject m in ObjectsInsideGroup)
                                {
                                    if (groupParent)
                                    {
                                        m.transform.parent = groupParent;
                                        isReadyToGo = true;
                                    }
                                }
                                foreach (GameObject m in CamerasInsideGroup)
                                {
                                    if (groupParent)
                                    {
                                        m.transform.parent = groupParent;
                                        isReadyToGo = true;
                                    }
                                }
                                break;
                            case false:
                                foreach (GameObject m in ObjectsInsideGroup)
                                {
                                    m.transform.parent = levelObjectsManager.transform;
                                    isReadyToGo = true;
                                }
                                foreach (GameObject m in CamerasInsideGroup)
                                {
                                    m.transform.parent = levelObjectsManager.transform;
                                    isReadyToGo = true;
                                }
                                break;
                        }

                        switch (isReadyToGo) {
                            case true:
                                enabled = false;
                                break;
                        }
                        
                    }
                }
            }
        }
    }
}
