using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab; //　弾のプレハブ
    public Transform firePoint ;//　弾を撃つ位置
    int moveSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        var current2 = Keyboard.current; //　キーボードの入力を取得（射撃用）

        Move();

        if (current2.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Move()//  プレイヤーの移動
    {
        var current = Keyboard.current; //  キーボードの入力を取得（移動用）

        if (current == null)
        {
            return;
        }

        // 上下左右の移動操作
        if (current.upArrowKey.isPressed)
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (current.downArrowKey.isPressed)
        {
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }

        if (current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * Time.deltaTime* moveSpeed;
        }

        if (current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }

    void Shoot() //  弾を撃つ
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
