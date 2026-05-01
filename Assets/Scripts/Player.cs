using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        var current2 = Keyboard.current;

        Move();

        if (current2.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Move()
    {
        var current = Keyboard.current;

        if (current == null)
        {
            return;
        }

        if (current.upArrowKey.isPressed)
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }

        if (current.downArrowKey.isPressed)
        {
            transform.position += Vector3.back * Time.deltaTime;
        }

        if (current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * Time.deltaTime;
        }

        if (current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
