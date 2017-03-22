using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float _runSpeed = 0.5f;
    public float _strafeSpeed = 0.5f;
    private const float CAMERA_TURN_FACTOR = 10.0f;
    public GameObject _cameraPivot;

    void Start ()
    {
	}


    // Update is called once per frame
    void Update ()
    {
        // Get mouse input
        float horizontalMouseInput = Input.GetAxis("Mouse X");
        float verticalMouseInput = Input.GetAxis("Mouse Y");

        // Turn player and pivot
        transform.RotateAround(transform.position,
            transform.up, CAMERA_TURN_FACTOR * horizontalMouseInput);
        _cameraPivot.transform.RotateAround(_cameraPivot.transform.position,
            _cameraPivot.transform.right, 
            - CAMERA_TURN_FACTOR * verticalMouseInput);

        // Get the input from up/down keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Advance...       in nose direction  by run speed * frame duration * input (-1/0/1)
        transform.position += transform.forward * _runSpeed * Time.deltaTime * verticalInput
                           + transform.right * _strafeSpeed * Time.deltaTime * horizontalInput;

     
    }
}
