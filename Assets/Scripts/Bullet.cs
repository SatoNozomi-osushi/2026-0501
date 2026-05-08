using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 30f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // ŠÔ‚ÅÁ‚¦‚é
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // ’e‚ğÁ‚·
    }
}