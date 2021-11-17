using UnityEngine;
using TMPro;

public class RocketCollision : Rocket
{
    private GameObject rocketGameObject;
    private TextMeshProUGUI text;
    private Rocket rocket;

    private void Start()
    {
        rocket = rocketGameObject.GetComponent<Rocket>();
        text = GameObject.FindGameObjectWithTag("Game Over Text").GetComponent<TextMeshProUGUI>();
        rocketGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!text.enabled)
        {
            text.enabled = true;
        }

        if (collision.collider.tag == "Powerup")
        {
            rocket.thrustForce += 50f;
            text.text = "Powerup picked up! +50 thrust force!";
        }
        else if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Here");
            rocket.isAlive = false;
            rocket.enabled = false;
            text.text = "You died!";
        }

        //if (Time.time > 2.5f)
        //{
        //    text.enabled = false;
        //}
    }
}
