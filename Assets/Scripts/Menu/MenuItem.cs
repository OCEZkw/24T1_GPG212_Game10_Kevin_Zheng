using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem
{
    public string itemName;
    public float price;

    public MenuItem(string name, float cost)
    {
        itemName = name;
        price = cost;
    }
}
