using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {

    public float seconds;
    public float group;
    public float x;
    public float y;
    public float z;

    public TestManager testM;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] allObjects;
    [SerializeField] private GameObject[] allCameras;
    [SerializeField] private GameObject[] allTriggers;
    [SerializeField] private GameObject[] allKillZones;

    private EditObject edO;
	private Vector3 endPosition;
	private bool execute;

    public List<GameObject> ObjectsInsideGroup;
    public List<GameObject> CamerasInsideGroup;
    public List<GameObject> TriggersInsideGroup;

    private GameObject levelObjectsManager;
	private float xCount;
    private bool onStart;

    // Use this for initialization
    void Start () {
		execute = true;
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
		if (!testM.isTesting)
		{
			execute = true;
			xCount = 0;
            onStart = true;
		}
		allObjects = GameObject.FindGameObjectsWithTag("Objects");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        allKillZones = GameObject.FindGameObjectsWithTag("Kill");
        player = GameObject.Find("Player");

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

                foreach (GameObject m in allKillZones)
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
        }

        if (testM.isTesting && onStart)
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
                        foreach(GameObject m in TriggersInsideGroup)
                        {
                            m.GetComponent<MoveTrigger>().enabled = false;
                        }
                        foreach(GameObject m in ObjectsInsideGroup)
                        {
							if (!execute)
							{
								break;
							}
							Vector3 pos = m.GetComponent<ReturnPositionAfterPlay>().position;
							endPosition = new Vector3(0, pos.y + y, pos.z + z);
							if (seconds > 0.0001f)
							{
								if (x > 0 && xCount >= x
								   || x < 0 && xCount <= x
								   || y > 0 && m.transform.position.y >= endPosition.y
								   || y < 0 && m.transform.position.y <= endPosition.y
								   || z > 0 && m.transform.position.z >= endPosition.z
								   || z < 0 && m.transform.position.z <= endPosition.z)
								{
									m.transform.position = new Vector3(m.transform.position.x, endPosition.y, endPosition.z);
									execute = false;
								}
								else
								{
									m.transform.position += new Vector3(x * Time.deltaTime / seconds, y * Time.deltaTime / seconds, z * Time.deltaTime / seconds);
								}
							}
							else if (execute)
							{
								m.transform.position += new Vector3(x, y, z);
							}
						}

                        foreach (GameObject m in CamerasInsideGroup)
                        {
							if (!execute)
							{
								break;
							}
                            Vector3 pos = m.GetComponent<ReturnPositionAfterPlay>().position;
							endPosition = new Vector3(0, pos.y + y, pos.z + z);
							if (seconds > 0.0001f)
							{
								if (x > 0 && xCount >= x
								   || x < 0 && xCount <= x
								   || y > 0 && m.transform.position.y >= endPosition.y
								   || y < 0 && m.transform.position.y <= endPosition.y
								   || z > 0 && m.transform.position.z >= endPosition.z
								   || z < 0 && m.transform.position.z <= endPosition.z)
								{
									m.transform.position = new Vector3(m.transform.position.x, endPosition.y, endPosition.z);
									execute = false;
								}
								else
								{
									m.transform.position += new Vector3(x * Time.deltaTime / seconds, y * Time.deltaTime / seconds, z * Time.deltaTime / seconds);
								}
							}
							else if(execute)
							{
								m.transform.position += new Vector3(x, y, z);
                                enabled = false;
							}
                        }
						if (seconds < 0.0001f)
						{
							execute = false;
						}
						xCount += x * Time.deltaTime / seconds;
					}
                }
            }
        }
    }
}
