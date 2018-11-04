using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour {

    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private EditObject edO;
    [SerializeField] private MenuTools meT;
    [SerializeField] private Layers layers;
    [SerializeField] private GizmoTranslateScript translate;
    [SerializeField] private GizmoScaleScript scale;
    [SerializeField] private ShowKillZones skz;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Objects" || hit.collider.tag == "GameCamera")
                {
                    if (!translate.isInteracting || !scale.isInteracting)
                    {
                        if (layers.all)
                        {
                            edO.isDuplicated = false;
                            edO.objectSelected = hit.collider.gameObject;
                            edO.isShowTime = true;
                        }
                        else if (hit.collider.GetComponent<SpriteRenderer>())
                        {
                            if (hit.collider.GetComponent<SpriteRenderer>().sortingOrder == layers.layer)
                            {
                                edO.isDuplicated = false;
                                edO.objectSelected = hit.collider.gameObject;
                                edO.isShowTime = true;
                            }
                        }
                    }
                    else
                    {
                        if (!translate.isInteracting || !scale.isInteracting)
                        {
                            edO.isDuplicated = false;
                            edO.objectSelected = hit.collider.gameObject;
                            edO.isShowTime = true;
                        }
                    }
                }
                else if (hit.collider.name == "KillZone")
                {
                    if (!translate.isInteracting || !scale.isInteracting)
                    {
                        edO.isDuplicated = false;
                        edO.objectSelected = hit.collider.gameObject;
                        edO.isShowTime = true;
                    }
                }
                else if (hit.collider.tag == "Trigger")
                {
                    if (!translate.isInteracting || !scale.isInteracting)
                    {
                        edO.isDuplicated = false;
                        edO.objectSelected = hit.collider.gameObject;
                        edO.isShowTime = true;
                    }
                }
                else if (hit.collider.tag == "LCTrigger")
                {
                    if (!translate.isInteracting || !scale.isInteracting)
                    {
                        edO.isDuplicated = false;
                        edO.objectSelected = hit.collider.gameObject;
                        edO.isShowTime = true;
                    }
                }
            }
        }
	}

    
}
