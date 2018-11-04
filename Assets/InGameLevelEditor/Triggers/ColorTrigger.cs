using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour {

    public float group;
    public float seconds;
    [SerializeField] private GameObject[] allObjects;
    [SerializeField] private GameObject[] allCameras;
    [SerializeField] private GameObject[] allTriggers;
    public Color color;
    public Color getSpriteColor;
    public float rStart;
    public float bStart;
    public float gStart;
    public float aStart;
    public Color colorBegin;
    public Color colorFinish;
    public float r = 255;
    public float g = 255;
    public float b = 255;
    public float a = 255;
    private float startTime;
    [SerializeField] private float rFloat;
    [SerializeField] private float gFloat;
    [SerializeField] private float bFloat;
    [SerializeField] private float aFloat;
    public TestManager testM;

    private bool onStart;

    [SerializeField] private bool takeSpriteColorsAtOnce;

    [SerializeField] private bool startTransition;

    private EditObject edO;

    public List<GameObject> ObjectsInsideGroup;
    public List<GameObject> CamerasInsideGroup;
    public List<GameObject> TriggersInsideGroup;

    [SerializeField] private float progressTwo;
    [SerializeField] private float incrementTwo;

    [SerializeField] private bool resetCameraColor;

    YieldInstruction wait;
    WaitForSeconds waitForDisable;

    bool r1;
    bool r2;
    bool g1;
    bool g2;
    bool b1;
    bool b2;
    bool a1;
    bool a2;

    public bool rReady;
    public bool gReady;
    public bool bReady;
    public bool aReady;

    private int frames = 0;

    // Use this for initialization
    void Start () {
        rStart = color.r * 255;
        bStart = color.b * 255;
        gStart = color.g * 255;
        aStart = color.a * 255;
        startTime = Time.time;
        takeSpriteColorsAtOnce = true;
        wait = new WaitForFixedUpdate();
        waitForDisable = new WaitForSeconds(0.2f);
        edO = GameObject.Find("EditObject").GetComponent<EditObject>();
    }

    private void LateUpdate()
    {
        rFloat = color.r;
        gFloat = color.g;
        bFloat = color.b;
        aFloat = color.a;

        allObjects = GameObject.FindGameObjectsWithTag("Objects");
        allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
        allTriggers = GameObject.FindGameObjectsWithTag("Trigger");
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


            if (!testM.canReturnPositions)
            {
                foreach (GameObject m in CamerasInsideGroup)
                {
                    rStart = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor.r * 255;
                    gStart = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor.g * 255;
                    bStart = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor.b * 255;
                    aStart = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor.a * 255;
                }
            }
        }

        if (!testM.isTesting)
        {
            if (edO.objectSelected == gameObject)
            {
                foreach (GameObject m in ObjectsInsideGroup)
                {
                    if (!testM.isTesting)
                    {
                        rStart = m.GetComponent<SpriteRenderer>().color.r * 255;
                        gStart = m.GetComponent<SpriteRenderer>().color.g * 255;
                        bStart = m.GetComponent<SpriteRenderer>().color.b * 255;
                        aStart = m.GetComponent<SpriteRenderer>().color.a * 255;
                    }
                }
                colorFinish = new Color(r / 255, g / 255, b / 255, a / 255);
                foreach (GameObject m in allObjects)
                {
                    if (m.GetComponent<ObjectPriorities>().group == group)
                    {
                        if (m.GetComponent<ObjectPriorities>().group != 0 || group != 0)
                        {
                            if (m.gameObject.name != "CustomObject1")
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
                                if (m.GetComponent<ColorTrigger>())
                                {
                                    if (m.GetComponent<ColorTrigger>() != this.GetComponent<ColorTrigger>())
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

                    if (m == null)
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

        foreach (GameObject m in ObjectsInsideGroup)
        {
            if (testM.isTesting)
            {
                getSpriteColor = m.GetComponent<SpriteRenderer>().color;
            }
            else
            {
                getSpriteColor = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
                color = m.GetComponent<SpriteRenderer>().color;
                takeSpriteColorsAtOnce = true;
            }
        }

        foreach (GameObject m in CamerasInsideGroup)
        {
            if (testM.isTesting)
            {
                if (ObjectsInsideGroup.Count == 0)
                {
                    getSpriteColor = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor;
                }
            }
            else
            {
                if (ObjectsInsideGroup.Count == 0)
                {

                    getSpriteColor = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
                    color = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor;
                    takeSpriteColorsAtOnce = true;
                }
            }
        }

        frames++;
        if(frames % 2 == 0)
        {
            FrameUpdate();
            frames = 0;
        }
    }

    // Update is called once per frame
    void FrameUpdate () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            if (group != 0)
            {
                if (testM.isTesting)
                {
                    if (takeSpriteColorsAtOnce)
                    {
                        if (CamerasInsideGroup.Count == 0)
                        {
                            foreach (GameObject m in ObjectsInsideGroup)
                            {
                                getSpriteColor = m.GetComponent<SpriteRenderer>().color;
                                color = getSpriteColor;
                            }
                        }
                        else
                        {
                            foreach (GameObject m in CamerasInsideGroup)
                            {
                                getSpriteColor = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor;
                                color = getSpriteColor;
                            }
                        }
                    }

                    if (player.transform.position.x == gameObject.transform.position.x || player.transform.position.x > gameObject.transform.position.x)
                    {

                        if (takeSpriteColorsAtOnce)
                        {
                            color = getSpriteColor;
                            takeSpriteColorsAtOnce = false;
                        }

                        foreach (GameObject m in ObjectsInsideGroup)
                        {

                            foreach (GameObject y in TriggersInsideGroup)
                            {
                                if (TriggersInsideGroup != null)
                                {
                                    y.GetComponent<ColorTrigger>().rReady = false;
                                    y.GetComponent<ColorTrigger>().gReady = false;
                                    y.GetComponent<ColorTrigger>().bReady = false;
                                    y.GetComponent<ColorTrigger>().aReady = false;
                                    y.GetComponent<ColorTrigger>().enabled = false;
                                }
                            }

                            if (seconds > 0.0001f)
                            {

                                m.GetComponent<SpriteRenderer>().color = color;

                                color = Color.LerpUnclamped(color, colorFinish, Time.deltaTime / seconds);

                                //===========================================================

                                if (color.r == colorFinish.r)
                                {
                                    color.r = colorFinish.r;
                                    rReady = true;
                                }
                                else if (color.g == colorFinish.g)
                                {
                                    color.g = colorFinish.g;
                                    rReady = true;
                                }
                                else if (color.b == colorFinish.b)
                                {
                                    color.b = colorFinish.b;
                                    bReady = true;
                                }
                                else if (color.a == colorFinish.a)
                                {
                                    color.a = colorFinish.a;
                                    aReady = true;
                                }
                            }
                            else
                            {
                                m.GetComponent<SpriteRenderer>().color = color;
                                color.r = colorFinish.r;
                                color.g = colorFinish.g;
                                color.b = colorFinish.b;
                                color.a = colorFinish.a;
                                StopCoroutine("WaitForDisable");
                            }
                        }

                        foreach (GameObject m in CamerasInsideGroup)
                        {
                            if (seconds > 0.0001f)
                            {
                                m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor = color;

                                color = Color.LerpUnclamped(color, colorFinish, Time.deltaTime / seconds);

                                if (color.r > 0.9f && color.g > 0.9f && color.b > 0.9f && color.a > 0.9f)
                                {
                                    color = colorFinish;
                                    rReady = true;
                                    gReady = true;
                                    bReady = true;
                                    aReady = true;
                                }
                                else if (color.r < 0.1f && color.g < 0.1f && color.b < 0.1f && color.a < 0.1f)
                                {
                                    color = colorFinish;
                                    rReady = true;
                                    gReady = true;
                                    bReady = true;
                                    aReady = true;
                                }

                                //===========================================================

                                if (color.r == colorFinish.r)
                                {
                                    color.r = colorFinish.r;
                                    rReady = true;
                                }
                                else if (color.g == colorFinish.g)
                                {
                                    color.g = colorFinish.g;
                                    rReady = true;
                                }
                                else if (color.b == colorFinish.b)
                                {
                                    color.b = colorFinish.b;
                                    bReady = true;
                                }
                                else if (color.a == colorFinish.a)
                                {
                                    color.a = colorFinish.a;
                                    aReady = true;
                                }
                            }
                            else
                            {
                                m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor = color;
                                color.r = colorFinish.r;
                                color.g = colorFinish.g;
                                color.b = colorFinish.b;
                                color.a = colorFinish.a;
                                StopCoroutine("WaitForDisable");
                            }
                        }
                    }
                }
                else if (!testM.isTesting)
                {
                    rReady = false;
                    gReady = false;
                    bReady = false;
                    aReady = false;

                    if (testM.canReturnPositions)
                    {
                        StopCoroutine("ChangeColor");
                        foreach (GameObject m in ObjectsInsideGroup)
                        {
                            m.GetComponent<LerpColorInCT>().isLerping = false;
                        }
                        progressTwo = 0.1f;
                        color = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
                        color = getSpriteColor;
                        takeSpriteColorsAtOnce = true;
                        ResetEverything();

                        if (seconds < 0.1f)
                        {
                            ResetEverything();
                        }
                    }
                }
            }
        }

        if (rReady && gReady && bReady && aReady)
        {
            if (takeSpriteColorsAtOnce) {
                if (seconds > 0.0001f || seconds == 0.0001f)
                {
                    if (testM.isTesting)
                    {
                        color = colorFinish;
                        rReady = false;
                        gReady = false;
                        bReady = false;
                        aReady = false;
                        GetComponent<LevelSpeed>().enabled = false;
                        StartCoroutine("WaitForDisable");
                    }
                    else if (!testM.isTesting)
                    {

                        if (testM.canReturnPositions)
                        {
                            color = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
                            color = getSpriteColor;
                            takeSpriteColorsAtOnce = true;
                            enabled = true;
                        }
                    }
                    progressTwo = 0;
                }
            }
        }
        else if (color == colorFinish)
        {
            if (!takeSpriteColorsAtOnce)
            {
                if (testM.isTesting)
                {
                    foreach (GameObject m in ObjectsInsideGroup)
                    {
                        getSpriteColor = m.GetComponent<SpriteRenderer>().color;
                    }
                    foreach (GameObject m in CamerasInsideGroup)
                    {
                        getSpriteColor = m.transform.GetChild(0).gameObject.GetComponent<Camera>().backgroundColor;
                    }
                    rReady = false;
                    gReady = false;
                    bReady = false;
                    aReady = false;
                    StartCoroutine("WaitForDisable");
                }
            }
            else
            {
                if (!testM.isTesting)
                {
                    if (testM.canReturnPositions)
                    {
                        ResetEverythingAnyways();
                        color = getSpriteColor;
                        takeSpriteColorsAtOnce = true;
                    }
                }
            }
            progressTwo = 0;
        }
	}

    void ResetEverything()
    {
        if (testM.canReturnPositions)
        {
            progressTwo = 0.3f;
            color = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
            color = getSpriteColor;
            takeSpriteColorsAtOnce = true;
            enabled = true;
        }
    }

    void ResetEverythingAnyways()
    {
        color = new Color(rStart / 255, gStart / 255, bStart / 255, aStart / 255);
        color = getSpriteColor;
        takeSpriteColorsAtOnce = true;
        enabled = true;
    }

    IEnumerator WaitForDisable()
    {
        yield return waitForDisable;
        enabled = false;
    }
}
