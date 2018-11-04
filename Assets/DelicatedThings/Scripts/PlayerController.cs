using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public bool isJumping;
    [SerializeField] private float jumpForce;
    private bool canRotate;
    [SerializeField] private Pause pause;
    public bool Cube;
    public bool Swing;
    [SerializeField] private GameObject PlayerSprite;
    [SerializeField] private GameObject SwingSprite;
    [SerializeField] private bool isZeroPointOne;
    [SerializeField] private bool isZeroPointTwo;
    [SerializeField] private GameObject SwingTrail;
    [SerializeField] private bool ChangeGravity;
    public bool canClick;
    [SerializeField] private GameObject sceneLoad;
    [SerializeField] private DeathTrigger dt;
    [SerializeField] private GameObject ps1, ps2, ps3, ps4, ps5, ps6, ps7, ps8, ps9, ps10, ps11, ps12;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        canClick = true;
        if (Cube)
        {
            Physics.gravity = new Vector3(0, -120.0F, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Cube)
        {
            Physics.gravity = new Vector3(0, -120.0F, 0);
            if (!isZeroPointOne)
            {
                PlayerSprite.SetActive(true);
                SwingSprite.SetActive(false);
                SwingTrail.SetActive(false);
            }
            if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 3 + 0.4f))
            {
                canRotate = false;
                isJumping = false;
                Quaternion rot = transform.rotation;
                rot.z = Mathf.Round(rot.z / 90) * 90;
                transform.rotation = rot;
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    if (canClick)
                    {
                        if (pause && !pause.isOnPause)
                        {
                            isJumping = true;
                            rb.velocity = new Vector3(0, jumpForce, 0);
                        }
                    }
                }
            }
            else
            {
                canRotate = true;
            }
        }

        if (Swing)
        {
            if (!isZeroPointOne)
            {
                PlayerSprite.SetActive(false);
                SwingSprite.SetActive(true);
                SwingTrail.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (!ChangeGravity)
                {
                    Physics.gravity = new Vector3(0, 50.0F, 0);
                    ChangeGravity = true;
                }
                else
                {
                    Physics.gravity = new Vector3(0, -50.0F, 0);
                    ChangeGravity = false;
                }
            }

            if (ChangeGravity)
            {
                SwingSprite.transform.Rotate(0, 0, 5);
            }
            else
            {
                SwingSprite.transform.Rotate(0, 0, -5);
            }

            SwingTrail.transform.position = transform.position;
            SwingTrail.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // ChangeIcon();
    }

    private void FixedUpdate()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.back * 5f);
        }
    }

    void ChangeIcon()
    {
        if(GameObject.Find("PIcon1") != null)
        {
            ps1.SetActive(true);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon1"));
        }
        else if(GameObject.Find("PIcon2") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(true);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon2"));
        }
        else if(GameObject.Find("PIcon3") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(true);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon3"));
        }
        else if(GameObject.Find("PIcon4") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(true);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon4"));
        }
        else if(GameObject.Find("PIcon5") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(true);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon5"));
        }
        else if(GameObject.Find("PIcon6") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(true);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon6"));
        }
        else if(GameObject.Find("PIcon7") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(true);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon7"));
        }
        else if(GameObject.Find("PIcon8") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(true);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon8"));
        }
        else if(GameObject.Find("PIcon9") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(true);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon9"));
        }
        else if(GameObject.Find("PIcon10") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(true);
            ps11.SetActive(false);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon10"));
        }
        else if(GameObject.Find("PIcon11") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(true);
            ps12.SetActive(false);
            Destroy(GameObject.Find("PIcon11"));
        }
        else if(GameObject.Find("PIcon12") != null)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
            ps3.SetActive(false);
            ps4.SetActive(false);
            ps5.SetActive(false);
            ps6.SetActive(false);
            ps7.SetActive(false);
            ps8.SetActive(false);
            ps9.SetActive(false);
            ps10.SetActive(false);
            ps11.SetActive(false);
            ps12.SetActive(true);
            Destroy(GameObject.Find("PIcon12"));
        }
    }
}


