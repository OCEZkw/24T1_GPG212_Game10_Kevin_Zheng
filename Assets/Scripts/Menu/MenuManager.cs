using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public MenuItem[] menuItems;
    public TextMeshProUGUI orderText;

    private void Start()
    {
        orderText.text = "Order: ";
    }

    public void OrderItem(int itemIndex)
    {
        orderText.text += menuItems[itemIndex].itemName + " ";
        Debug.Log("Order successful: " + menuItems[itemIndex].itemName);
    }
}
