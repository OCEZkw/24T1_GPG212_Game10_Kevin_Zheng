using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMachine : MonoBehaviour
{
    [SerializeField] public bool isPaymentMode = false;

    void Update()
    {
        if (isPaymentMode)
        {
            // Move the object to follow the mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the object stays on the same z-axis
            transform.position = mousePosition;
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPaymentMode)
            {
                // Disable payment mode and leave the object at the current mouse position
                isPaymentMode = false;
                Debug.Log("CardMachine Unhighlighted");
            }
            else
            {
                // Enable payment mode
                isPaymentMode = true;
                Debug.Log("CardMachine Highlighted");
            }
        }
    }
}
