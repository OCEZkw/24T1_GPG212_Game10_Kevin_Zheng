using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Customer : MonoBehaviour
{
    private bool hasPaid = false;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CardMachine cardMachine = FindObjectOfType<CardMachine>();
            Transform canvas = GameObject.Find("Canvas").transform;
            MenuManager menuManager = canvas.Find("Menu").GetComponent<MenuManager>();

            Debug.Log("Conditions Not Met");
            if (cardMachine != null && cardMachine.isPaymentMode && menuManager.waitingForPayment)
            {
                // Proceed with payment
                Debug.Log("Payment completed");

                if (menuManager != null && menuManager.checkoutText != null)
                {
                    menuManager.checkoutText.text = "Payment completed";
                    hasPaid = true;
                    StartCoroutine(MoveAndDeleteCustomer());
                }
                else
                {
                    Debug.LogWarning("MenuManager or checkoutText is null");
                }
            }
        }
    }

    IEnumerator MoveAndDeleteCustomer()
    {
        CustomerController customerController = GetComponent<CustomerController>();
        if (customerController == null)
        {
            Debug.LogError("CustomerController component not found!");
            yield break;
        }

        float moveDistance = 10f; // Adjust as needed
        float moveDuration = moveDistance / customerController.walkSpeed;

        Vector3 targetPosition = transform.position + Vector3.left * moveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Delete the customer
        Destroy(gameObject);

        Transform canvas = GameObject.Find("Canvas").transform;
        MenuManager menuManager = canvas.Find("Menu").GetComponent<MenuManager>();
        if (menuManager != null && menuManager.checkoutPage != null)
        {
            menuManager.checkoutPage.SetActive(false);
        }

        // Spawn the next customer
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner != null)
        {
            customerSpawner.SpawnCustomer();
        }
    }
}
