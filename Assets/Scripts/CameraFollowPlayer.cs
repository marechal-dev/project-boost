using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
  private Transform cameraTransformComponent;
  [SerializeField]
  private GameObject player;

  // Start is called before the first frame update
  void Start()
  {
    cameraTransformComponent = GetComponent<Transform>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  // Update is called once per frame
  void Update()
  {
    cameraTransformComponent.LookAt(player.transform);
  }
}
