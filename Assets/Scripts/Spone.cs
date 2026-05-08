using UnityEngine;

public class SpawnInPlane : MonoBehaviour
{
    public GameObject characterPrefab;
    public Transform plane;
    public Transform player;

    public int spawnCount = 10;
    public int spawned = 0;
    public float minDistanceFromPlayer = 5f; // 最低距離

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        
    }
    public void Spawn()
    {
        Vector3 center = plane.position;
        float width = plane.localScale.x * 10f;
        float height = plane.localScale.z * 10f;

 
        int maxAttempts = 100; // 無限ループ防止

        while (spawned < spawnCount)
        {
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                float randomX = Random.Range(-width / 2, width / 2);
                float randomZ = Random.Range(-height / 2, height / 2);

                Vector3 spawnPos = new Vector3(
                    center.x + randomX,
                    center.y + 1f,
                    center.z + randomZ
                );

                // プレイヤーとの距離チェック
                float distance = Vector3.Distance(player.position, spawnPos);

                if (distance >= minDistanceFromPlayer)
                {
                    Instantiate(characterPrefab, spawnPos, Quaternion.identity);
                    spawned++;
                    break;
                }

                attempts++;
            }

            // 無限ループ防止用
            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("スポーン位置が見つかりませんでした");
                break;
            }
        }
    }
}