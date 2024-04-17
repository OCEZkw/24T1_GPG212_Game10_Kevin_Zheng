using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // Reference to the customer prefab
    public Transform windowTransform; // Reference to the window transform
    public float walkSpeed = 1.5f; // Speed at which the customer walks
    public MenuManager menuManager; // Reference to the MenuManager script

    private void Start()
    {
        // Spawn a customer when the script starts
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        // Instantiate a new customer prefab
        GameObject newCustomer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        // Get the CustomerController component
        CustomerController customerController = newCustomer.GetComponent<CustomerController>();
        // Start the customer moving towards the window
        customerController.SetTarget(windowTransform, walkSpeed, menuManager);
    }
}