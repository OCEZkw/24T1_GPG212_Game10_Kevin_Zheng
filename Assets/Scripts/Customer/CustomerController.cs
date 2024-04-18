using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private Transform target;
    public float walkSpeed;
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
        yield return StartCoroutine(OrderFood());
    }

    private IEnumerator OrderFood()
    {
        if (menuManager == null)
        {
            Debug.LogError("MenuManager is not assigned!");
            yield break;
        }

        // Order multiple items from the menu
        int numItemsToOrder = Random.Range(1, 4); // Order 1 to 3 items
        for (int i = 0; i < numItemsToOrder; i++)
        {
            menuManager.customerText.gameObject.SetActive(true);
            int randomIndex = Random.Range(0, menuManager.menuItems.Count);
            if (randomIndex >= 0 && randomIndex < menuManager.menuItems.Count)
            {
                MenuItem orderedItem = menuManager.menuItems[randomIndex];
                Debug.Log("Customer selected: " + orderedItem.itemName);
                yield return new WaitForSeconds(3f); // Wait for 3 seconds before displaying the next item
                menuManager.DisplaySelectedItem(orderedItem);
            }
            else
            {
                Debug.LogWarning("Invalid index: " + randomIndex);
            }
        }
        yield return new WaitForSeconds(3f);
        menuManager.customerText.gameObject.SetActive(false);
    }
}
