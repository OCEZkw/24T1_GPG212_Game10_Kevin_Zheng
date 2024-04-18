using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField] public List<MenuItem> menuItems = new List<MenuItem>(); // List of menu items with prices
    [SerializeField] public List<MenuItem> orderList = new List<MenuItem>(); // List to store the order

    public TMP_Text orderText;      // Reference to the TMP text for displaying the order
    public TMP_Text customerText;   // Reference to the TMP text for displaying customer selections
    public TMP_Text totalPriceText; // Reference to the TMP text for displaying total price
    public TMP_Text checkoutText;

    private float totalPrice;       // Total price of items in the order

    public GameObject menuPage;
    public GameObject checkoutPage;
    [SerializeField] public bool waitingForPayment = false;

    // Add items to the menu and set up button click listeners
    void Start()
    {
        // Add your menu items to the list with prices
        menuItems.Add(new MenuItem("Burger", 5.99f));
        menuItems.Add(new MenuItem("Chips", 2.99f));
        menuItems.Add(new MenuItem("Cake", 3.99f));
        menuItems.Add(new MenuItem("Steak", 4.99f));
        menuItems.Add(new MenuItem("Onigiri", 5.99f));
        menuItems.Add(new MenuItem("Squid", 6.99f));

        // Get all buttons in the scene
        Button[] buttons = GetComponentsInChildren<Button>();

        // Add click listeners to each button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current value of i for the lambda function
            buttons[i].onClick.AddListener(() => AddToOrder(index));
        }
    }

    // Add the selected item to the order list
    void AddToOrder(int index)
    {
        if (index >= 0 && index < menuItems.Count)
        {
            orderList.Add(menuItems[index]);
            totalPrice += menuItems[index].price; // Add the item's price to the total price
            UpdateOrderText();
        }
        else
        {
            Debug.LogWarning("Invalid index: " + index);
        }
    }

    // Update the order text display and total price
    public void UpdateOrderText()
    {
        string text = "Order:\n";
        foreach (MenuItem item in orderList)
        {
            text += item.itemName + " - $" + item.price.ToString("F2") + "\n"; // Display item name and price
        }
        orderText.text = text;

        totalPriceText.text = "Total: $" + totalPrice.ToString("F2"); // Display total price
    }

    public void DisplaySelectedItem(MenuItem item)
    {
        // Display the selected item
        customerText.text = "Can I please have a " + item.itemName;
    }

    // Clear the order list and update the order text display
    public void ClearOrder()
    {
        orderList.Clear();
        totalPrice = 0f; // Reset total price
        UpdateOrderText();
    }

    public void Checkout()
    {
        ClearOrder();

        // Disable menu page
        menuPage.SetActive(false);

        // Enable checkout page
        checkoutPage.SetActive(true);

        // Optionally, display order summary on checkout page
        checkoutText.text = "Please make payment";

        Debug.Log("Waiting For Payment True");
        waitingForPayment = true;
    }


}

