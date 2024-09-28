using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1000.0f;
    [SerializeField] float cameraSpeed = 300.0f;

    Rigidbody body;
    Transform mainCamera;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        mainCamera = transform.Find("Main Camera");

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        body.velocity = GetPlayerVelocity();
        mainCamera.localRotation = GetCameraRotation();
    }

    Vector3 GetPlayerVelocity()
    {
        float angle = mainCamera.localEulerAngles.y * Mathf.PI / 180.0f;
        float movementX = Input.GetAxis("Vertical") * Mathf.Sin(angle) + Input.GetAxis("Horizontal") * Mathf.Cos(angle);
        float movementZ = Input.GetAxis("Vertical") * Mathf.Cos(angle) - Input.GetAxis("Horizontal") * Mathf.Sin(angle);

        Vector3 playerMovements = new(movementX, 0.0f, movementZ);
        playerMovements.Normalize();
        playerMovements = playerSpeed * Time.deltaTime * playerMovements;

        if (!Physics.Raycast(transform.position, -Vector3.up, 1.1f)) // if nothing under player
        {
            float movementY = playerSpeed * Time.deltaTime * Mathf.Max(-5.0f, body.velocity.y == 0.0f ? -0.000001f : body.velocity.y * 1.01f);
            playerMovements = new Vector3(playerMovements.x, playerMovements.y + movementY, playerMovements.z);
        }

        return playerMovements;
    }

    Quaternion GetCameraRotation()
    {
        Vector3 cameraRotation = new(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        cameraRotation.Normalize();
        cameraRotation = cameraSpeed * Time.deltaTime * cameraRotation;

        float angleX = mainCamera.localEulerAngles.x - cameraRotation.x;
        float angleY = mainCamera.localEulerAngles.y + cameraRotation.y;

        if (180.0f < angleX && angleX < 270.0f) // if looking up
        {
            angleX = 270.0f;
        }
        else if (90.0f < angleX && angleX < 180.0f) // if looking bottom
        {
            angleX = 90.0f;
        }

        return Quaternion.Euler(angleX, angleY, 0.0f);
    }
}