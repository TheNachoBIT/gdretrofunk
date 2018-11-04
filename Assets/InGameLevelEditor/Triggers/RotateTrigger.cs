using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{

	public float seconds;
	public float group;
	public float groupObject;
	public float x;
	public float y;
	public float z;
	public GameObject objectInRotate;
	public bool rotateInObject;

	public TestManager testM;

    private EditObject edO;

    private bool onStart;

    [SerializeField] private GameObject player;

	[SerializeField] private GameObject[] allObjects;
	[SerializeField] private GameObject[] allCameras;
	[SerializeField] private GameObject[] allTriggers;
	private Quaternion endRotation;
	private bool execute;

	public List<GameObject> ObjectsInsideGroup;
	public List<GameObject> CamerasInsideGroup;
	public List<GameObject> TriggersInsideGroup;

	private GameObject levelObjectsManager;

	// Use this for initialization
	void Start()
	{
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
		if (!testM.isTesting)
		{
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

            execute = true;
		}
		allObjects = GameObject.FindGameObjectsWithTag("Objects");
		allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
		allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
		player = GameObject.Find("Player");

		if (!rotateInObject && objectInRotate != null)
		{
			objectInRotate = null;
		}

        if (!testM.isTesting)
        {
            if (edO.objectSelected == gameObject)
            {
                foreach (GameObject m in allObjects)
                {
                    if (m.GetComponent<ObjectPriorities>().group == groupObject && rotateInObject)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            objectInRotate = m;
                        }
                    }
                    else if (!rotateInObject && m.GetComponent<ObjectPriorities>().isOnCenter)
                    {
                        m.GetComponent<ObjectPriorities>().isOnCenter = false;
                    }
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
                    if (m.GetComponent<ObjectPriorities>().group == groupObject && rotateInObject)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            objectInRotate = m;
                        }
                    }
                    else if (!rotateInObject && m.GetComponent<ObjectPriorities>().isOnCenter)
                    {
                        m.GetComponent<ObjectPriorities>().isOnCenter = false;
                    }
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
                                if (m.GetComponent<RotateTrigger>())
                                {
                                    if (m.GetComponent<RotateTrigger>() != this.GetComponent<RotateTrigger>())
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
                    foreach(GameObject m in ObjectsInsideGroup)
                    {
                        if (rotateInObject)
                        {
                            m.transform.parent = objectInRotate.transform;
                        }
                    }

					if (player.transform.position.x == gameObject.transform.position.x || player.transform.position.x > gameObject.transform.position.x)
					{
						foreach (GameObject m in TriggersInsideGroup)
						{
							m.GetComponent<RotateTrigger>().enabled = false;
						}
						foreach (GameObject m in ObjectsInsideGroup)
						{
							if (!execute)
							{
                                enabled = false;
								break;
							}
							if (rotateInObject)
							{
								endRotation = Quaternion.Euler(objectInRotate.transform.rotation.x + x, objectInRotate.transform.rotation.y + y, objectInRotate.transform.rotation.z + z);
							}
							else
							{
								Quaternion rot = m.GetComponent<ReturnPositionAfterPlay>().rotation;
								endRotation = Quaternion.Euler(rot.x + x, rot.y + y, rot.z + z);
							}
							if (seconds > 0.0001f)
							{
								if (rotateInObject)
								{
									objectInRotate.transform.rotation = Quaternion.LerpUnclamped(objectInRotate.transform.rotation, endRotation, Time.deltaTime / seconds);
									if (objectInRotate.transform.rotation == endRotation)
									{
										execute = false;
									}
								}
								else
								{
									m.transform.rotation = Quaternion.LerpUnclamped(m.transform.rotation, endRotation, Time.deltaTime / seconds);
									if (m.transform.rotation == endRotation)
									{
										execute = false;
									}
								}
							}
							else
							{
								if (rotateInObject)
								{
									objectInRotate.transform.rotation = endRotation;
								}
								else
								{
									m.transform.rotation = endRotation;
								}
							}
						}
						foreach (GameObject m in CamerasInsideGroup)
						{
							if (!execute)
							{
								break;
							}
							if (rotateInObject)
							{
								endRotation = Quaternion.Euler(objectInRotate.transform.rotation.x + x, objectInRotate.transform.rotation.y + y, objectInRotate.transform.rotation.z + z);
							}
							else
							{
								Quaternion rot = m.GetComponent<ReturnPositionAfterPlay>().rotation;
								endRotation = Quaternion.Euler(rot.x + x, rot.y + y, rot.z + z);
							}
							if (seconds > 0.0001f)
							{
								if (rotateInObject)
								{
									objectInRotate.transform.rotation = Quaternion.LerpUnclamped(objectInRotate.transform.rotation, endRotation, Time.deltaTime / seconds);
									if (objectInRotate.transform.rotation == endRotation)
									{
										execute = false;
									}
								}
								else
								{
									m.transform.rotation = Quaternion.LerpUnclamped(m.transform.rotation, endRotation, Time.deltaTime / seconds);
									if (m.transform.rotation == endRotation)
									{
										execute = false;
									}
								}
							}
							else
							{
								if (rotateInObject)
								{
									objectInRotate.transform.rotation = endRotation;
								}
								else
								{
									m.transform.rotation = endRotation;
								}
							}
						}
						if (seconds < 0.0001f)
						{
							execute = false;
						}
					}
				}
			}
		}
	}
}
