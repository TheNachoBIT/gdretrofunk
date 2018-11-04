using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColorInCT : MonoBehaviour {

    public ColorTrigger ct;
    public TestManager testM;
    public Color color;
    public bool isLerping;
    private bool Once;
    public float secondsResults;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        testM = GameObject.FindGameObjectWithTag("TestManager").GetComponent<TestManager>();
        if (ct)
        {

            if (Once)
            {
                secondsResults = Time.deltaTime / ct.seconds;
            }

            if (isLerping)
            {
                Once = false;
                GetComponent<SpriteRenderer>().color = ct.color;
                if(ct.colorFinish.r > ct.color.r)
                {
                    ct.color.r += secondsResults;
                }
                else if(ct.colorFinish.r < ct.color.r)
                {
                    ct.color.r -= secondsResults;
                }

                if (ct.colorFinish.g > ct.color.g)
                {
                    ct.color.g += secondsResults;
                }
                else if (ct.colorFinish.g < ct.color.g)
                {
                    ct.color.g -= secondsResults;
                }

                if (ct.colorFinish.b > ct.color.b)
                {
                    ct.color.b += secondsResults;
                }
                else if (ct.colorFinish.b < ct.color.b)
                {
                    ct.color.b -= secondsResults;
                }

                if (ct.colorFinish.a > ct.color.a)
                {
                    ct.color.a += secondsResults;
                }
                else if (ct.colorFinish.a < ct.color.a)
                {
                    ct.color.a -= secondsResults;
                }


                //===========================================================

                if(ct.colorFinish.r == ct.color.r)
                {
                    ct.color.r = ct.colorFinish.r;
                }
                else if(ct.colorFinish.g == ct.color.g)
                {
                    ct.color.g = ct.colorFinish.g;
                }
                else if (ct.colorFinish.b == ct.color.b)
                {
                    ct.color.b = ct.colorFinish.b;
                }
                else if (ct.colorFinish.a == ct.color.a)
                {
                    ct.color.a = ct.colorFinish.a;
                }
            }
        }

        if (!ct.testM.isTesting)
        {
            isLerping = false;
            Once = true;
        }
	}
}
