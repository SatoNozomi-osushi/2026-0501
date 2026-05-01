using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 30f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // éûä‘Ç≈è¡Ç¶ÇÈ
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // ìGÇè¡Ç∑
        }

        Destroy(gameObject); // íeÇ‡è¡Ç∑
    }
}