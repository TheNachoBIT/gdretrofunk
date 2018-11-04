using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSpriteIsVisibleOL : MonoBehaviour {

    [SerializeField] private Camera ThisCamera;
    [SerializeField] private Plane[] plane;
    [SerializeField] private GameObject[] objectsToDisable;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        plane = GeometryUtility.CalculateFrustumPlanes(ThisCamera);
        foreach (GameObject a in objectsToDisable)
        {
            if (!GeometryUtility.TestPlanesAABB(plane, a.GetComponent<Renderer>().bounds))
            {
                a.SetActive(false);
            }
            else
            {
                a.SetActive(true);
            }
        }
    }
}
