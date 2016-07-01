using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;
    private int waypointIndex;
    private NavMeshAgent nav;
    private float speed = 5f;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        move();
    }
    void move()
    {
        nav.speed = speed;
            if (nav.remainingDistance < 0.5)
            {
                waypointIndex = Random.Range(0, wayPoints.Length);
            }
            nav.SetDestination(wayPoints[waypointIndex].position);
    }
}
