using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] seats;

    private int currentSeatIndex = 0;
    private bool isOrdering = false;
    private bool isServed = false;

    private Vector3 destination;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isServed)
        {
            if (isOrdering)
            {
                // Wait for player to enable menu panel
                // Handle ordering logic
            }
            else
            {
                // Move towards the destination
                Vector2 direction = (destination - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Counter") && !isOrdering)
        {
            isOrdering = true;
        }
        else if (other.CompareTag("Seat") && isOrdering && !isServed)
        {
            isServed = true;
            transform.position = seats[currentSeatIndex].position;
            currentSeatIndex++;
            isOrdering = false;
        }
    }
}
