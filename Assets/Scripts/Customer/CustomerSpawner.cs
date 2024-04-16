using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform counter;
    public Transform[] seats;
    public float spawnRate = 10f;

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCustomer();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnCustomer()
    {
        GameObject customer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        CustomerController customerController = customer.GetComponent<CustomerController>();
        customerController.SetDestination(counter.position);
        customerController.seats = seats;
    }
}