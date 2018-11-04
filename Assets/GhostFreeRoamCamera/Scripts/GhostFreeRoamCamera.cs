using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    public float initialSpeed = 7f;
    public float increaseSpeed = 1.25f;

    public bool allowMovement = true;
    public bool allowRotation = true;

    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backwardButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;

    public float cursorSensitivity = 0.025f;

    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;

    private void Update()
    {
        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
                currentSpeed += increaseSpeed * Time.deltaTime;

            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
            CheckMove(leftButton, ref deltaPosition, -transform.right);
            CheckMove(KeyCode.Q, ref deltaPosition, transform.up);
            CheckMove(KeyCode.E, ref deltaPosition, -transform.up);

            if (moving)
            {
                if (moving != lastMoving)
                    currentSpeed = initialSpeed;

                transform.position += deltaPosition * currentSpeed * Time.deltaTime;
            }
            else currentSpeed = 0f;
        }

        if (allowRotation)
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 eulerAngles = transform.eulerAngles;
                eulerAngles.x += -Input.GetAxis("Mouse Y") * 350f * cursorSensitivity;
                eulerAngles.y += Input.GetAxis("Mouse X") * 350f * cursorSensitivity;
                transform.eulerAngles = eulerAngles;
            }
        }
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
}
