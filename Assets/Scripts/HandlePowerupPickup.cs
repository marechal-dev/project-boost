using UnityEngine;

public class HandlePowerupPickup : MonoBehaviour
{
    MeshRenderer powerupMeshRenderer;
    BoxCollider powerupMeshBoxCollider;
    Rigidbody powerupRigidbody;

    private void Awake()
    {
        powerupMeshRenderer = GetComponent<MeshRenderer>();
        powerupMeshBoxCollider = GetComponent<BoxCollider>();
        powerupRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        powerupRigidbody.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool playerIsCollision = collision.gameObject.tag == "Player";
        

        if (playerIsCollision)
        {
            powerupMeshRenderer.enabled = false;
            powerupMeshBoxCollider.enabled = false;
        }
    }
}
