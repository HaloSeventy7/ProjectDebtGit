using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;

    private Transform target;
    private int currentIndex = 0;

    void Start()
    {
        if (Waypoints.waypoints.Length > 0)
        {
            target = Waypoints.waypoints[0];
        }
    }

    void Update()
    {
        Vector2 directionOfTravel = target.position - transform.position;
        transform.Translate(directionOfTravel.normalized * moveSpeed * Time.deltaTime, Space.World); //normalizes the movement

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            if (currentIndex >= Waypoints.waypoints.Length - 1) //destroys the enemy when it reaches the end
            { //TODO: Take health from player before destroying
                Destroy(gameObject);
            }
            if (currentIndex < Waypoints.waypoints.Length - 1)
            {
                currentIndex++;
                target = Waypoints.waypoints[currentIndex];
            }
        }

    }
}
