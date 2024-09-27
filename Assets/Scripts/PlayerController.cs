using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    CharacterController controller;
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float cameraSpeed = 300.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float angle = mainCamera.localEulerAngles.y * Mathf.PI / 180.0f;
        float movementX = Input.GetAxis("Vertical") * Mathf.Sin(angle) + Input.GetAxis("Horizontal") * Mathf.Cos(angle);
        float movementZ = Input.GetAxis("Vertical") * Mathf.Cos(angle) - Input.GetAxis("Horizontal") * Mathf.Sin(angle);
        Vector3 playerMovements = new(movementX, 0.0f, movementZ);
        playerMovements.Normalize();
        playerMovements = playerSpeed * Time.deltaTime * playerMovements;

        if (!Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            float movementY = playerSpeed * Time.deltaTime * Mathf.Max(-5.0f, controller.velocity.y == 0.0f ? -0.000001f : controller.velocity.y * 1.01f);
            playerMovements = new Vector3(playerMovements.x, playerMovements.y + movementY, playerMovements.z);
        }

        Vector3 cameraRotation = new(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        cameraRotation.Normalize();
        cameraRotation = cameraSpeed * Time.deltaTime * cameraRotation;
        Quaternion cameraFinalRotation = Quaternion.Euler(mainCamera.localEulerAngles.x - cameraRotation.x, mainCamera.localEulerAngles.y + cameraRotation.y, 0.0f);

        controller.Move(playerMovements);
        transform.rotation = Quaternion.identity;
        mainCamera.localRotation = cameraFinalRotation;
    }
}