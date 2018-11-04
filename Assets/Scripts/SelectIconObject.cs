using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectIconObject : MonoBehaviour {

    [SerializeField] GameObject i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12;
    [SerializeField] Rigidbody p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12;
    [SerializeField] private float IconID;
    [SerializeField] private bool canExcecute;
    public bool isPlayerInScene;
    public bool isSceneChanged;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this.gameObject);
        i1 = GameObject.Find("Icon1");
        i2 = GameObject.Find("Icon2");
        i3 = GameObject.Find("Icon3");
        i4 = GameObject.Find("Icon4");
        i5 = GameObject.Find("Icon5");
        i6 = GameObject.Find("Icon6");
        i7 = GameObject.Find("Icon7");
        i8 = GameObject.Find("Icon8");
        i9 = GameObject.Find("Icon9");
        i10 = GameObject.Find("Icon10");
        i11 = GameObject.Find("Icon11");
        i12 = GameObject.Find("Icon12");

        if(i1 != null)
        {
            IconID = 1;
            Destroy(i1);
        }
        else if (i2 != null)
        {
            IconID = 2;
            Destroy(i2);
        }
        else if (i3 != null)
        {
            IconID = 3;
            Destroy(i3);
        }
        else if (i4 != null)
        {
            IconID = 4;
            Destroy(i4);
        }
        else if (i5 != null)
        {
            IconID = 5;
            Destroy(i5);
        }
        else if (i6 != null)
        {
            IconID = 6;
            Destroy(i6);
        }
        else if (i7 != null)
        {
            IconID = 7;
            Destroy(i7);
        }
        else if (i8 != null)
        {
            IconID = 8;
            Destroy(i8);
        }
        else if (i9 != null)
        {
            IconID = 9;
            Destroy(i9);
        }
        else if (i10 != null)
        {
            IconID = 10;
            Destroy(i10);
        }
        else if (i11 != null)
        {
            IconID = 11;
            Destroy(i11);
        }
        else if (i12 != null)
        {
            IconID = 12;
            Destroy(i12);
        }

        if (isSceneChanged)
        {
            canExcecute = true;
            if (isPlayerInScene)
            {
                if (IconID == 1)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon1");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 2)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon2");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 3)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon3");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 4)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon4");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 5)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon5");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 6)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon6");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 7)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon7");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 8)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon8");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 9)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon9");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 10)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon10");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 11)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon11");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
                else if (IconID == 12)
                {
                    if (canExcecute)
                    {
                        GameObject ob = new GameObject("PIcon12");
                        isSceneChanged = false;
                        canExcecute = false;
                    }
                }
            }
        }
    }
}
