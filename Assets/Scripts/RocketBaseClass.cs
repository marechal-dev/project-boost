using UnityEngine;

public class RocketBaseClass : MonoBehaviour
{
    [SerializeField] public float thrustForce = 1000f;
    [SerializeField] private float rotationForce = 100f;

    Rigidbody rocketRigidBody;
    Transform rocketTransformComponent;
    AudioSource rocketAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Cache components
        rocketRigidBody = GetComponent<Rigidbody>();
        rocketTransformComponent = GetComponent<Transform>();
        rocketAudioSource = GetComponent<AudioSource>();

        // Set default values for AudioSource
        rocketAudioSource.playOnAwake = false;
        rocketAudioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustRotationSpeed();
        AdjustThrustForce();
        HandleThrust();
        HandleRotation();
    }

    private void HandleThrust()
    {
        bool playerIsPressingSpace = Input.GetKey(KeyCode.Space);

        if (playerIsPressingSpace)
        {
            rocketRigidBody.AddRelativeForce(thrustForce * Time.deltaTime * Vector3.up);
            if (!rocketAudioSource.isPlaying)
            {
                rocketAudioSource.Play();
            }
        }
        else
        {
            rocketAudioSource.Stop();
        }
    }

    private void HandleRotation()
    {
        bool playerIsPressingLeft = Input.GetKey(KeyCode.A);
        bool playerIsPressingRight = Input.GetKey(KeyCode.D);

        if (playerIsPressingLeft)
        {
            ApplyRotation(Vector3.forward);
        }
        else if (playerIsPressingRight)
        {
            ApplyRotation(-Vector3.forward);
        }
    }

    private void ApplyRotation(Vector3 rotationDirection)
    {
        rocketRigidBody.freezeRotation = true;
        rocketTransformComponent.Rotate(rotationForce * Time.deltaTime * rotationDirection);
        rocketRigidBody.freezeRotation = false;
    }

    private void AdjustThrustForce()
    {
        bool isPlayerPressingLeftArrow = Input.GetKey(KeyCode.LeftArrow);
        bool isPlayerPressingRightArrow = Input.GetKey(KeyCode.RightArrow);

        if (isPlayerPressingLeftArrow)
        {
            thrustForce -= 1f;
        }
        else if (isPlayerPressingRightArrow)
        {
            thrustForce += 1f;
        }
    }

    private void AdjustRotationSpeed()
    {
        bool isPlayerPressingUpArrow = Input.GetKey(KeyCode.UpArrow);
        bool isPlayerPressingDownArrow = Input.GetKey(KeyCode.DownArrow);

        if (isPlayerPressingUpArrow)
        {
            rotationForce += 1f;
        }
        else if (isPlayerPressingDownArrow)
        {
            rotationForce -= 1f;
        }
    }
}
