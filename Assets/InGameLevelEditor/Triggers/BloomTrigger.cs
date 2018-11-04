using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BloomTrigger : MonoBehaviour {

    public float seconds;

    public float intensity;
    public float pppIntensity;
    public float startIntensity;
    public float intensityGoal;

    public float threshold;
    public float pppThreshold;
    public float startThreshold;
    public float thresholdGoal;

    public bool findPosition;
    public TestManager testM;
    [SerializeField] private GameObject player;

    [SerializeField] private PostProcessingProfile ppp;

    private EditObject edO;

    private bool OnStart;

    [SerializeField] private GameObject[] allTriggers;

    [SerializeField] private List<GameObject> allObjectsInsideTriggers;

    public Vector3 _startPosition;

    public float t;
    public float s;

    public WaitForSeconds wait;

    public List<GameObject> TriggersInsideGroup;

    private GameObject levelObjectsManager;

    private WaitForSeconds xd;
    public bool once;

    public bool one;
    public bool two;
    public bool one2;
    public bool two2;

    public bool done;

    // Use this for initialization
    void Start()
    {
        xd = new WaitForSeconds(0.1f);

        findPosition = true;
        levelObjectsManager = GameObject.FindGameObjectWithTag("LevelObjects");
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();

        BloomModel.Settings bloomSettings = ppp.bloom.settings;

        bloomSettings.bloom.intensity = 5;
        intensity = bloomSettings.bloom.intensity;
        startIntensity = bloomSettings.bloom.intensity;

        bloomSettings.bloom.threshold = 1.1f;
        threshold = bloomSettings.bloom.threshold;
        startThreshold = bloomSettings.bloom.threshold;

        ppp.bloom.settings = bloomSettings;

        once = true;

        wait = new WaitForSeconds(0.02f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BloomModel.Settings bloomSettings = ppp.bloom.settings;
        pppIntensity = bloomSettings.bloom.intensity;
        pppThreshold = bloomSettings.bloom.threshold;

        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
        player = GameObject.Find("Player");

        if (!testM.isTesting)
        {

            for (var i = TriggersInsideGroup.Count - 1; i > -1; i--)
            {
                if (TriggersInsideGroup[i] == null)
                    TriggersInsideGroup.RemoveAt(i);
            }
        }

        if (testM.canEdit)
        {
            done = false;
            once = true;
            one = false;
            two = false;
            one2 = false;
            two2 = false;
            startIntensity = 5;
            startThreshold = 1.1f;
            bloomSettings.bloom.intensity = startIntensity;
            bloomSettings.bloom.threshold = startThreshold;
            ppp.bloom.settings = bloomSettings;
        }
        foreach (GameObject m in allTriggers)
        {
            if (m.GetComponent<BloomTrigger>())
            {
                if (m.GetComponent<BloomTrigger>() != this.GetComponent<BloomTrigger>())
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
            else
            {
                TriggersInsideGroup.Remove(m);
            }
        }

        if (player)
        {
            if (testM.isTesting)
            {
                if (player.transform.position.x == gameObject.transform.position.x || player.transform.position.x > gameObject.transform.position.x)
                {
                    if (once)
                    {
                        foreach (GameObject m in TriggersInsideGroup)
                        {
                            m.GetComponent<BloomTrigger>().enabled = false;
                        }

                        intensity = pppIntensity;
                        threshold = pppThreshold;

                        if (intensity == pppIntensity && threshold == pppThreshold)
                        {
                            once = false;
                        }
                    }

                    if (!once)
                    {
                        foreach (GameObject m in TriggersInsideGroup)
                        {
                            m.GetComponent<BloomTrigger>().enabled = false;
                        }

                        bloomSettings.bloom.intensity = intensity;
                        bloomSettings.bloom.threshold = threshold;

                        if (seconds > 0.1f || seconds == 0.1f)
                        {
                            if (intensity < intensityGoal)
                            {
                                intensity += (intensityGoal / seconds) / 20f;
                                one = true;
                            }
                            else if (intensity > intensityGoal)
                            {
                                intensity -= (intensityGoal / seconds) / 1.5f;
                                two = true;
                            }

                            if (threshold < thresholdGoal)
                            {
                                threshold += (thresholdGoal / seconds) / 20f;
                                one2 = true;
                            }
                            else if (threshold > thresholdGoal)
                            {
                                threshold -= (thresholdGoal / seconds) / 1.5f;
                                two2 = true;
                            }
                        }
                        else
                        {
                            intensity = intensityGoal;
                            threshold = thresholdGoal;
                        }

                        ppp.bloom.settings = bloomSettings;
                    }
                }
            }
        }

        if (!done)
        {
            if (seconds > 0.1f || seconds == 0.1f)
            {
                if (one)
                {
                    if (bloomSettings.bloom.intensity == intensityGoal || bloomSettings.bloom.intensity > intensityGoal)
                    {
                        bloomSettings.bloom.intensity = intensityGoal;
                        ppp.bloom.settings = bloomSettings;
                        done = true;
                    }
                }
                else if (two)
                {
                    if (bloomSettings.bloom.intensity == intensityGoal || bloomSettings.bloom.intensity < intensityGoal)
                    {
                        bloomSettings.bloom.intensity = intensityGoal;
                        ppp.bloom.settings = bloomSettings;
                        done = true;
                    }
                }

                if (one2)
                {
                    if (bloomSettings.bloom.threshold == thresholdGoal || bloomSettings.bloom.threshold > thresholdGoal)
                    {
                        bloomSettings.bloom.threshold = thresholdGoal;
                        ppp.bloom.settings = bloomSettings;
                        done = true;
                    }
                }
                else if (two2)
                {
                    if (bloomSettings.bloom.threshold == thresholdGoal || bloomSettings.bloom.threshold < thresholdGoal)
                    {
                        bloomSettings.bloom.threshold = thresholdGoal;
                        ppp.bloom.settings = bloomSettings;
                        done = true;
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
            one = false;
            two = false;
            one2 = false;
            two2 = false;
            if (!once)
            {
                bloomSettings.bloom.intensity = intensityGoal;
                bloomSettings.bloom.threshold = thresholdGoal;
                ppp.bloom.settings = bloomSettings;
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
            yield return xd;
            intensity = 5;
            threshold = 1.1f;
            enabled = false;
        }
    }
}
