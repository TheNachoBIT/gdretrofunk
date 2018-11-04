using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layers : MonoBehaviour {

    public float layer;
    public TestManager testM;
    public GameObject[] allSpriteRenderer;

    public List<SpriteRenderer> allCustomSpriteRenderer;

    public List<SpriteRenderer> customSpritesInLayout;
    public List<SpriteRenderer> customSpritesNotInLayout;

    public List<SpriteRenderer> spritesInLayout;
    public List<SpriteRenderer> spritesNotInLayout;


    public List<SpriteRenderer> spritesChanged;
    public bool all;
    public bool opacity;
    public Toggle allBool;
    public Toggle opacityBool;
    public bool onChange;

    public InputField ass;

	// Use this for initialization
	void Start () {

        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();

        onChange = true;

        if (!all)
        {
            ass.text = layer.ToString();
            allBool.isOn = false;
            ass.interactable = true;
        }
        else
        {
            ass.text = "ALL";
            allBool.isOn = true;
            ass.interactable = false;
        }

        if (opacity)
        {
            opacityBool.isOn = true;
        }
        else
        {
            opacityBool.isOn = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!testM.isTesting)
        {
            for (var i = spritesInLayout.Count - 1; i > -1; i--)
            {
                if (spritesInLayout[i] == null)
                    spritesInLayout.RemoveAt(i);
            }

            for (var i = spritesNotInLayout.Count - 1; i > -1; i--)
            {
                if (spritesNotInLayout[i] == null)
                    spritesNotInLayout.RemoveAt(i);
            }

            for (var i = customSpritesInLayout.Count - 1; i > -1; i--)
            {
                if (customSpritesInLayout[i] == null)
                    customSpritesInLayout.RemoveAt(i);
            }

            for (var i = customSpritesNotInLayout.Count - 1; i > -1; i--)
            {
                if (customSpritesNotInLayout[i] == null)
                {
                    customSpritesNotInLayout.RemoveAt(i);
                }
            }

            for (var i = allCustomSpriteRenderer.Count - 1; i > -1; i--)
            {
                if (allCustomSpriteRenderer[i] == null)
                {
                    allCustomSpriteRenderer.RemoveAt(i);
                }
            }

            if (!all)
            {
                if (onChange)
                {
                    ass.text = layer.ToString();
                    onChange = false;
                }
                else
                {
                    if (ass.isFocused)
                    {
                        layer = float.Parse(ass.text);
                    }
                    else
                    {
                        ass.text = layer.ToString();
                    }
                }
                ass.interactable = true;
            }
            else
            {
                onChange = true;
                ass.text = "ALL";
                ass.interactable = false;
            }

            allSpriteRenderer = GameObject.FindGameObjectsWithTag("Objects");

            foreach (GameObject m in allSpriteRenderer)
            {
                if (m.name == "CustomObject1")
                {
                    if (!allCustomSpriteRenderer.Contains(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()))
                    {
                        allCustomSpriteRenderer.Add(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>());
                    }
                }
            }

            foreach (GameObject m in allSpriteRenderer)
            {
                if (!all)
                {
                    if (m.name != "CustomObject1")
                    {
                        if (m.GetComponent<SpriteRenderer>())
                        {
                            if (m.GetComponent<SpriteRenderer>().sortingOrder == layer)
                            {
                                if (!spritesInLayout.Contains(m.GetComponent<SpriteRenderer>()))
                                {
                                    spritesInLayout.Add(m.GetComponent<SpriteRenderer>());
                                    spritesNotInLayout.Remove(m.GetComponent<SpriteRenderer>());
                                }
                            }
                            else if (m.GetComponent<SpriteRenderer>().sortingOrder != layer)
                            {
                                if (!spritesNotInLayout.Contains(m.GetComponent<SpriteRenderer>()))
                                {
                                    spritesNotInLayout.Add(m.GetComponent<SpriteRenderer>());
                                    spritesInLayout.Remove(m.GetComponent<SpriteRenderer>());
                                }
                            }
                        }
                    }

                    else if (m.name == "CustomObject1")
                    {
                        if (m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>())
                        {
                            if (m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder == layer)
                            {
                                if (!customSpritesInLayout.Contains(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()))
                                {
                                    customSpritesInLayout.Add(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>());
                                    customSpritesNotInLayout.Remove(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>());
                                }
                            }
                            else if (m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder != layer)
                            {
                                if (!customSpritesNotInLayout.Contains(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()))
                                {
                                    customSpritesNotInLayout.Add(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>());
                                    customSpritesInLayout.Remove(m.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>());
                                }
                            }
                        }
                    }
                }
            }

            if (allSpriteRenderer.Length != 0)
            {
                if (all)
                {
                    foreach (GameObject m in allSpriteRenderer)
                    {
                        if (m.name != "CustomObject1")
                        {
                            m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 1f);
                        }
                    }

                    foreach(SpriteRenderer m in allCustomSpriteRenderer)
                    {
                        m.color = new Color(m.color.r, m.color.g, m.color.b, 1f);
                    }
                }
                else if (!all)
                {
                    foreach (SpriteRenderer m in spritesInLayout)
                    {
                        if (m.name != "CustomObject1")
                        {
                            m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 1f);
                        }
                    }

                    foreach (SpriteRenderer m in customSpritesInLayout)
                    {
                        m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 1f);
                    }

                    foreach (SpriteRenderer m in spritesNotInLayout)
                    {
                        if (opacity)
                        {
                            if (m.name != "CustomObject1")
                            {
                                m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 0.25f);
                            }
                        }
                        else
                        {
                            if (m.name != "CustomObject1")
                            {
                                m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 0f);
                            }
                        }
                    }

                    foreach (SpriteRenderer m in customSpritesNotInLayout)
                    {
                        if (opacity)
                        {
                            m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 0.25f);
                        }
                        else
                        {
                            m.GetComponent<SpriteRenderer>().color = new Color(m.GetComponent<SpriteRenderer>().color.r, m.GetComponent<SpriteRenderer>().color.g, m.GetComponent<SpriteRenderer>().color.b, 0f);
                        }
                    }
                }
            }
        }
	}

    public void All(bool yesnt)
    {
        all = yesnt;
    }

    public void Opacity(bool nont)
    {
        opacity = nont;
    }

    public void PlusOne()
    {
        if (!all)
        {
            layer += 1;
        }
    }

    public void MinusOne()
    {
        if (!all)
        {
            layer -= 1;
        }
    }
}
