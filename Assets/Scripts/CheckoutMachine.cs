using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckoutMachine : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject buttonHolderPanel;

    private bool isMenuActive = false;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMenuActive = !isMenuActive; // Toggle the menu active state
            menuPanel.SetActive(isMenuActive); // Set the menu panel active state
            buttonHolderPanel.SetActive(isMenuActive); // Set the button holder panel active state
        }
    }
}
