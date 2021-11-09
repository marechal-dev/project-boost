using UnityEngine;

public class RocketBaseClass : MonoBehaviour
{
  [SerializeField] private float thrustForce = 1000f;
  [SerializeField] private float rotationForce = 100f;

  Rigidbody rocketRigidBody;
  Transform rocketTransformComponent;

  // Start is called before the first frame update
  void Start()
  {
    rocketRigidBody = GetComponent<Rigidbody>();
    rocketTransformComponent = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {
    HandleThrust();
    HandleRotation();
  }

  private void HandleThrust()
  {
    bool playerIsPressingSpace = Input.GetKey(KeyCode.Space);

    if (playerIsPressingSpace)
    {
      rocketRigidBody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
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
    rocketTransformComponent.Rotate(rotationDirection * rotationForce * Time.deltaTime);
    rocketRigidBody.freezeRotation = false;
  }
}
