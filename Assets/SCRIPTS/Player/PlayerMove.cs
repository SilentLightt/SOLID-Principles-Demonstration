using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal speed")]
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Rate of change for move speed")]
    [SerializeField] private float acceleration = 10f;
    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float deceleration = 5f;

    [Header("Controls")]
    [Tooltip("Use WASD keys to move")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    [Header("Collision")]
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Audio")]
    [SerializeField] private AudioClip[] bounceClips;
    [SerializeField] private float audioCooldownTime = 2f;
    private float lastAudioPlayedTime;

    [Header("Effects")]
    [SerializeField] private ParticleSystem m_ParticleSystem;
    private const float effectCooldown = 1f;
    private float timeToNextEffect = -1f;

    private Vector3 inputVector;
    private float currentSpeed = 0f;
    private CharacterController charController;
    private float initialYPosition;
    private AudioSource audioSource;
    private PlayerInventory inventory;

    [Header("Camera Reference")]
    [SerializeField] private Transform cameraTransform; // Reference to the camera

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        initialYPosition = transform.position.y;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        lastAudioPlayedTime = -audioCooldownTime;
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        HandleInput();
        Move(inputVector);
        RotatePlayer();
    }

    private void HandleInput()
    {
        // Reset input vector
        float xInput = 0;
        float zInput = 0;

        if (Input.GetKey(resetKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(forwardKey))
            zInput++;
        if (Input.GetKey(backwardKey))
            zInput--;
        if (Input.GetKey(leftKey))
            xInput--;
        if (Input.GetKey(rightKey))
            xInput++;

        // Get the forward and right directions of the camera, ignoring y-axis
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // Keep the movement on the X-Z plane
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0; // Keep the movement on the X-Z plane
        right.Normalize();

        // Calculate movement direction relative to the camera
        inputVector = (forward * zInput + right * xInput).normalized;
    }

    private void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * acceleration);
        }

        Vector3 movement = inputVector * currentSpeed * Time.deltaTime;
        charController.Move(movement);
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }

    private void RotatePlayer()
    {
        // Get the camera's Y-axis rotation (yaw)
        float targetRotationY = cameraTransform.eulerAngles.y;

        // Smoothly rotate the player to match the camera's Y rotation
        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    public void PlayRandomAudioClip()
    {
        // If the time to play the next clip has passed and there are clips available we play a random clip.
        if (Time.time > (audioCooldownTime + lastAudioPlayedTime))
        {
            lastAudioPlayedTime = Time.time;
            audioSource.clip = bounceClips[Random.Range(0, bounceClips.Length)];
            audioSource.Play();
        }
    }

    public void PlayEffect()
    {
        if (Time.time < timeToNextEffect)
            return;

        if (m_ParticleSystem != null)
        {
            m_ParticleSystem.Stop();
            m_ParticleSystem.Play();
            timeToNextEffect = Time.time + effectCooldown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collided object's layer is in the obstacleLayer LayerMask.
        if ((obstacleLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            PlayRandomAudioClip();
            PlayEffect();
        }
    }
}
