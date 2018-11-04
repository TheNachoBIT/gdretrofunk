using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{

	public float seconds;
	public float group;
	public float x;
	public float y;
	public float z;
	public TestManager testM;

	[SerializeField] private GameObject player;

	[SerializeField] private GameObject[] allObjects;
	[SerializeField] private GameObject[] allTriggers;
	private bool execute;
	private Vector3 endScale;

    private EditObject edO;

    private bool onStart;

    public List<GameObject> ObjectsInsideGroup;
	public List<GameObject> TriggersInsideGroup;

	private GameObject levelObjectsManager;

	// Use this for initialization
	void Start()
	{
		levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
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

            for (var i = TriggersInsideGroup.Count - 1; i > -1; i--)
            {
                if (TriggersInsideGroup[i] == null)
                    TriggersInsideGroup.RemoveAt(i);
            }

            execute = true;
		}
		allObjects = GameObject.FindGameObjectsWithTag("Objects");
		allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
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

                foreach (GameObject m in allTriggers)
                {
                    if (m.GetComponent<ObjectPriorities>())
                    {
                        if (m.GetComponent<ObjectPriorities>().group == group)
                        {
                            if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                            {
                                if (m.GetComponent<ScaleTrigger>())
                                {
                                    if (m.GetComponent<ScaleTrigger>() != this.GetComponent<ScaleTrigger>())
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

            foreach (GameObject m in allTriggers)
            {
                if (m.GetComponent<ObjectPriorities>())
                {
                    if (m.GetComponent<ObjectPriorities>().group == group)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            if (m.GetComponent<ScaleTrigger>())
                            {
                                if (m.GetComponent<ScaleTrigger>() != this.GetComponent<ScaleTrigger>())
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
						foreach (GameObject m in TriggersInsideGroup)
						{
							m.GetComponent<ScaleTrigger>().enabled = false;
						}
						foreach (GameObject m in ObjectsInsideGroup)
						{
							if (!execute)
							{
								break;
							}
							Vector3 sca = m.GetComponent<ReturnPositionAfterPlay>().scale;
							endScale = new Vector3(sca.x + x, sca.y + y, sca.z + z);
							if (seconds > 0.0001f)
							{
								m.transform.localScale += new Vector3(x * Time.deltaTime / seconds, y * Time.deltaTime / seconds, z * Time.deltaTime / seconds);
								if (x > 0 && m.transform.localScale.x >= endScale.x
								   || x < 0 && m.transform.localScale.x <= endScale.x
								   || y > 0 && m.transform.localScale.y >= endScale.y
								   || y < 0 && m.transform.localScale.y <= endScale.y
								   || z > 0 && m.transform.localScale.z >= endScale.z
								   || z < 0 && m.transform.localScale.z <= endScale.z)
								{
									m.transform.localScale = endScale;
									execute = false;
								}
							}
							else
							{
								m.transform.localScale = endScale;
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