using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    public float sensitivity = 200f;
    // Ograniczenia obracania kamery góra-dół
    public float minimumX = -90f; 
    public float maximumX = 90f; 
    private float rotationX = 0f;
    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        // aby w UnityEditor ponownie pojawił się kursor (właściwie deaktywowac kursor w trybie play)
        // wciskamy klawisz ESC
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Ograniczenie obrotu kamery w osi Y do określonego zakresu
        rotationX -= mouseYMove;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        player.Rotate(Vector3.up * mouseXMove);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);


    }
}