using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemButton : MonoBehaviour
{
    public string itemName;
    public int price;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Add code here to handle the ordering process
        Debug.Log("Ordered: " + itemName + " for " + price + " credits");
    }
}
