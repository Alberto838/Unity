using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 openPosition = new Vector3(10, 0, 0); // Przykładowa pozycja otwarta
    public Vector3 closedPosition = new Vector3(0, 0, 0); // Przykładowa pozycja zamknięta
    public float slidingSpeed = 2.0f; // Szybkość przesuwania drzwi
    private bool isOpen = false; // Czy drzwi są otwarte

    void Update()
    {
        MoveDoor(); // Przesuń drzwi w odpowiednią pozycję
    }

    void ToggleDoor()
    {
        isOpen = !isOpen; // Zmiana stanu drzwi (otwarte/zamknięte)
    }

    void MoveDoor()
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, slidingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true; // Gdy gracz zbliży się do drzwi, otwórz je
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false; // Gdy gracz się oddali, zamknij drzwi
        }
    }
}

