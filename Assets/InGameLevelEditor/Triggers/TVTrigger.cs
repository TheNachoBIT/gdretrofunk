using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class TVTrigger : MonoBehaviour {

    public float seconds;


    public float scanLines;
    public float colorDrift;

    public float scanLinesStart;
    public float colorDriftStart;

    public float scanLinesGoal;
    public float colorDriftGoal;

    public float group;
    public bool findPosition;
    public TestManager testM;

    private EditObject edO;
    private bool onStart;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] allCameras;
    [SerializeField] private GameObject[] allTriggers;

    [SerializeField] private List<GameObject> allObjectsInsideTriggers;

    public Vector3 _startPosition;

    public float t;
    public float s;

    public WaitForSeconds wait;

    public List<GameObject> TriggersInsideGroup;

    private GameObject levelObjectsManager;

    public bool once;

    public bool one1;
    public bool two1;
    public bool one2;
    public bool two2;

    public bool done;

    // Use this for initialization
    void Start()
    {
        findPosition = true;
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();

        foreach (GameObject m in allCameras)
        {
            scanLinesStart = m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter;
            colorDriftStart = m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift;
        }

        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        wait = new WaitForSeconds(0.1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        player = GameObject.Find("Player");

        if (!testM.isTesting)
        {
            onStart = true;

            for (var i = TriggersInsideGroup.Count - 1; i > -1; i--)
            {
                if (TriggersInsideGroup[i] == null)
                    TriggersInsideGroup.RemoveAt(i);
            }

            if (edO.objectSelected == gameObject)
            {
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

        if (testM.canEdit)
        {
            done = false;
            once = true;
            one1 = false;
            two1 = false;
            one2 = false;
            two2 = false;
            scanLinesStart = 0.3f;
            colorDriftStart = 0.1f;

            foreach (GameObject m in allCameras)
            {
                m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter = scanLinesStart;
                m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift = colorDriftStart;
            }
        }

        if(testM.isTesting && onStart)
        {
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
            if (testM.isTesting)
            {
                if (player.transform.position.x == gameObject.transform.position.x || player.transform.position.x > gameObject.transform.position.x)
                {
                    Debug.Log("Changed");
                    foreach (GameObject m in TriggersInsideGroup)
                    {
                        m.GetComponent<TVTrigger>().enabled = false;
                    }

                    if (once)
                    {
                        foreach (GameObject m in allCameras)
                        {
                            scanLines = m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter;
                            colorDrift = m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift;

                            if (scanLines == m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter &&
                                colorDrift == m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift)
                            {
                                once = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameObject m in allCameras)
                        {
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter = scanLines;
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift = colorDrift;


                            if (seconds > 0.1f || seconds == 0.1f)
                            {
                                if (scanLines < scanLinesGoal)
                                {
                                    scanLines += (scanLinesGoal / seconds) / 20f;
                                    one1 = true;
                                }
                                else if (scanLines > scanLinesGoal)
                                {
                                    scanLines -= (scanLinesGoal / seconds) / 1.5f;
                                    two1 = true;
                                }


                                if (colorDrift < colorDriftGoal)
                                {
                                    colorDrift += (colorDriftGoal / seconds) / 20f;
                                    one2 = true;
                                }
                                else if (colorDrift > colorDriftGoal)
                                {
                                    colorDrift -= (colorDriftGoal / seconds) / 1.5f;
                                    two2 = true;
                                }
                            }
                            else
                            {
                                scanLines = scanLinesGoal;
                                colorDrift = colorDriftGoal;
                            }
                        }
                    }
                }
            }
        }

        if (!done)
        {
            if (seconds > 0.1f || seconds == 0.1f)
            {
                if (one1)
                {
                    foreach (GameObject m in allCameras)
                    {
                        if (m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter == scanLinesGoal ||
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter > scanLinesGoal)
                        {
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter = scanLinesGoal;
                            done = true;
                        }
                    }
                }
                else if (two1)
                {
                    foreach (GameObject m in allCameras)
                    {
                        if (m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter == scanLinesGoal ||
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter < scanLinesGoal)
                        {
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter = scanLinesGoal;
                            done = true;
                        }
                    }
                }


                if (one2)
                {
                    foreach (GameObject m in allCameras)
                    {
                        if (m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift == colorDriftGoal ||
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift > colorDriftGoal)
                        {
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift = colorDriftGoal;
                            done = true;
                        }
                    }
                }
                else if (two2)
                {
                    foreach (GameObject m in allCameras)
                    {
                        if (m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift == colorDriftGoal ||
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift < colorDriftGoal)
                        {
                            m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift = colorDriftGoal;
                            done = true;
                        }
                    }
                }
            }
            else
            {
                done = true;
            }
        }
        else
        {
            one1 = false;
            two1 = false;
            one2 = false;
            two2 = false;
            if (!once)
            {
                scanLines = scanLinesGoal;
                colorDrift = colorDriftGoal;
                StartCoroutine("OnDisableCorountine");
            }
        }

        if (t == 500f)
        {
            t = 0;
        }

        if (!testM.isTesting)
        {
            findPosition = true;
        }
    }

    IEnumerator OnDisableCorountine()
    {
        if (!once)
        {
            yield return wait;
            foreach (GameObject m in allCameras)
            {
                m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().scanLineJitter = scanLinesGoal;
                m.transform.GetChild(0).gameObject.GetComponent<AnalogGlitch>().colorDrift = colorDriftGoal;
            }
            scanLines = 0.3f;
            colorDrift = 0.1f;
            enabled = false;
        }
    }
}
