using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    /*--Properties of the class--*/

    // The camera movement speed
    [SerializeField]
    protected float cameraMovementSpeed = 10.0f;

    // The speed increase on the camera in sprint mode
    [SerializeField]
    protected float cameraSpeedIncreaseAmount = 20.0f;

    // Reference to the attached rigidbody component
    private Rigidbody cameraRigidBody;

	// Use this for initialization
	protected void Start ()
    {
        // Get the camera rigidbody component
        cameraRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	protected void Update ()
    {
        // Control the camera movement
        cameraMovementControl();

        // Increase the camera movement speed
        //increaseCameraSpeed();
    }

    // Control the camera movement
    protected void cameraMovementControl()
    {
        // Move the camera forward
        moveCameraForward();

        // Move the camera backwards
        moveCameraBackwards();

        // Move the camera to the left
        moveCameraLeft();

        // Move the camera to the right
        moveCameraRight();
    }

    // Move the camera forward
    private void moveCameraForward()
    {
        // If the pan forward key is pressed move the camera forward
        if (Input.GetButton("PanForward"))
        {
            transform.position += new Vector3(0.0f, 0.0f, cameraMovementSpeed * Time.deltaTime);
        }
    }

    // Move the camera backwards
    private void moveCameraBackwards()
    {
        // If the pan backwards key is pressed move the camera backwards
        if (Input.GetButton("PanBackwards"))
        {
            transform.position -= new Vector3(0.0f, 0.0f, cameraMovementSpeed * Time.deltaTime);
        }
    }

    // Move the camera to the left
    private void moveCameraLeft()
    {
        // If the pan left key is pressed move the camera to the left
        if (Input.GetButton("PanLeft"))
        {
            transform.position -= new Vector3(cameraMovementSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    // Move the camera to the right
    private void moveCameraRight()
    {
        // If the pan right key is pressed move the camera to the right
        if (Input.GetButton("PanRight"))
        {
            transform.position += new Vector3(cameraMovementSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    /*
    // Increase the camera movement speed
    private void increaseCameraSpeed()
    {
        // If the sprint camera button is pressed increase the camera movement speed
        if (Input.GetButtonDown("SprintCamera"))
        {
            cameraMovementSpeed += cameraSpeedIncreaseAmount;
        }

        // If the sprint camera button is released decrease the camera movement speed
        if (Input.GetButtonUp("SprintCamera"))
        {
            cameraMovementSpeed -= cameraSpeedIncreaseAmount;
        }

    }
    */
}
