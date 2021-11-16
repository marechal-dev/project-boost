using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths : MonoBehaviour
{
  private GameObject[] obstacles;
  // Start is called before the first frame update
  void Start()
  {
    obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
  }

  // Update is called once per frame
  void Update()
  {
    int i;

    for (i = 0; i < obstacles.Length; i++)
    {
      Debug.Log($"Obstacle {i}:");
      calculateDotProduct(transform.position, obstacles[i].transform.position);
    }
  }

  void calculateDotProduct(Vector3 playerVector3, Vector3 obstacleVector3)
  {
    Debug.Log(Vector3.Dot(playerVector3, obstacleVector3));
  }
}
