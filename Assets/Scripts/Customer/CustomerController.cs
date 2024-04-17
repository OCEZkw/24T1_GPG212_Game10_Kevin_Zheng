using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private Transform target;
    private float walkSpeed;
    [SerializeField] private MenuManager menuManager;

    public void SetTarget(Transform newTarget, float speed, MenuManager manager)
    {
        target = newTarget;
        walkSpeed = speed;
        menuManager = manager;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
            yield return null;
        }

        // Customer has reached the target (window)
        // Implement ordering behavior here
        OrderFood();
    }

    private void OrderFood()
    {
        if (menuManager == null)
        {
            Debug.LogError("MenuManager is not assigned!");
            return;
        }
        // Order a random item from the menu
        int randomIndex = Random.Range(0, menuManager.menuItems.Count);
        string orderedItem = menuManager.menuItems[randomIndex];
        Debug.Log("Customer ordered: " + orderedItem);

        // Add the item to the order list
        menuManager.orderList.Add(orderedItem);
        menuManager.UpdateOrderText();
    }
}
