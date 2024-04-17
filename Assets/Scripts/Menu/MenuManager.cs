using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public List<string> menuItems = new List<string>(); // List of menu items
    public List<string> orderList = new List<string>(); // List to store the order

    public TMP_Text orderText; // Reference to the TMP text for displaying the order

    // Add items to the menu and set up button click listeners
    void Start()
    {
        // Add your menu items to the list
        menuItems.Add("Burger");
        menuItems.Add("Chips");
        menuItems.Add("Item 3");
        menuItems.Add("Item 4");
        menuItems.Add("Item 5");
        menuItems.Add("Item 6");

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
        orderList.Add(menuItems[index]);
        UpdateOrderText();
    }

    // Update the order text display
    public void UpdateOrderText()
    {
        string text = "Order:\n";
        foreach (string item in orderList)
        {
            text += item + "\n";
        }
        orderText.text = text;
    }
}
