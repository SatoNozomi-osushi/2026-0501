using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject spone;
    SpawnInPlane spawner;
    GameObject Player;
    Transform playerPos;   // プレイヤー
    float speed = 0f;   // 移動速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spone = GameObject.Find("spone");
        spawner = spone.GetComponent<SpawnInPlane>();
        Player = GameObject.Find("player");
        playerPos = Player.transform;
        speed = Random.Range(0.5f,1.5f );
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤー方向を計算
        Vector3 direction = (playerPos.position - transform.position).normalized;

        // プレイヤーへ移動
        transform.position += direction * speed * Time.deltaTime;
    }  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            spawner.spawned--;
            spawner.Spawn();
            Destroy(gameObject);
        }
             
    }
}
