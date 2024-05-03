using System.Collections;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public AudioSource breathing;
    public static bool tired_out = false;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public AudioSource walkSound;
    public AudioSource runSound;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float gyroRotationY = 0; // Rotation in Y-axis from gyroscope

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Check if gyro is available
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true; // Enable the gyroscope
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        bool isMoving = curSpeedX != 0 || curSpeedY != 0;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (isRunning)
        {
            if (!runSound.isPlaying)
            {
                tired_out = true;
                runSound.Play();
                walkSound.Pause(); // Pausa o som de andar
            }
        }
        else if (isMoving)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
                runSound.Pause(); // Pausa o som de correr
            }
        }
        else
        {
            // Se o jogador não está se movendo, pause ambos os sons
            walkSound.Pause();
            runSound.Pause();
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            // Rotate using gyroscope
            if (SystemInfo.supportsGyroscope)
            {
                Quaternion attitude = Input.gyro.attitude;
                attitude.x *= -1; // Invert X axis
                attitude.y *= -1; // Invert Y axis
                playerCamera.transform.localRotation = Quaternion.Euler(90, 0, 0) * attitude;

                // Apply rotation from gyroscope to player's Y-axis
                gyroRotationY = attitude.eulerAngles.y;
            }

            // Rotate the player to face the same direction as the camera
            transform.rotation = Quaternion.Euler(0, gyroRotationY, 0);
        }

        if (tired_out)
        {
            StartCoroutine(RepeatBreathing());
        }
    }

    IEnumerator RepeatBreathing()
    {
        yield return new WaitForSeconds(3.0f);
        breathing.Play();
        tired_out = false;
    }
}