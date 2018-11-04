using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKillZones : MonoBehaviour {

    [SerializeField] private TestManager testM;
    public bool show;
    [SerializeField] private GameObject[] allTriggers;
    [SerializeField] private List<GameObject> allKillZones;
    private bool onStart;

	// Use this for initialization
	void Start () {
        testM = GameObject.Find("TestManager").GetComponent<TestManager>();
        ShowKillZone(true);
    }

    private void Update()
    {
        if (!testM.isTesting)
        {
            onStart = true;
            allTriggers = GameObject.FindGameObjectsWithTag("Trigger");

            for (var i = allKillZones.Count - 1; i > -1; i--)
            {
                if (allKillZones[i] == null)
                    allKillZones.RemoveAt(i);
            }

            foreach (GameObject a in allTriggers)
            {
                if (a.name == "KillZone")
                {
                    if (!allKillZones.Contains(a))
                    {
                        allKillZones.Add(a);
                    }
                }
            }
        }
        else
        {
            if (allKillZones != null)
            {
                if (onStart)
                {
                    foreach (GameObject a in allKillZones)
                    {
                        a.SetActive(true);
                    }
                    onStart = false;
                }
            }
        }
    }

    public void ShowKillZone (bool change) {
        if (!testM.isTesting)
        {
            show = change;

            if (show)
            {
                foreach(GameObject a in allKillZones)
                {
                    a.SetActive(true);
                    a.GetComponent<SpriteRenderer>().color = new Color(a.GetComponent<SpriteRenderer>().color.r, a.GetComponent<SpriteRenderer>().color.g, a.GetComponent<SpriteRenderer>().color.b,0.7f);
                    a.GetComponent<SpriteRenderer>().sortingOrder = 50;
                }
            }
            else
            {
                foreach (GameObject a in allKillZones)
                {
                    a.SetActive(false);
                    a.GetComponent<SpriteRenderer>().color = new Color(a.GetComponent<SpriteRenderer>().color.r, a.GetComponent<SpriteRenderer>().color.g, a.GetComponent<SpriteRenderer>().color.b, 0f);
                    a.GetComponent<SpriteRenderer>().sortingOrder = 50;
                }
            }
        }
	}
}
