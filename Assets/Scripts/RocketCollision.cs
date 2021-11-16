using UnityEngine;
using TMPro;

public class RocketCollision : MonoBehaviour
{
    private GameObject textGameObject;
    private GameObject rocketGameObject;
    private TextMeshProUGUI text;
    private RocketBaseClass rocket;

    private void Awake()
    {
        textGameObject = GameObject.FindGameObjectWithTag("Game Over Text");
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        rocketGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        rocket = rocketGameObject.GetComponent<RocketBaseClass>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!text.enabled)
        {
            text.enabled = true;
        }

        switch (collision.collider.tag)
        {
            case "Powerup":
                rocket.thrustForce += 50f;
                text.text = "Powerup picked up! +50 thrust force!";
                break;
            case "Obstacle":
                rocket.enabled = false;
                text.text = "You died!";
                break;
        }

        if (Time.time > 2.5f)
        {
            text.enabled = false;
        }
    }
}
