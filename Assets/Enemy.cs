using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float hp = 20f;
    public float damageToPlayer = 20f;

    void Update()
    {
        // 적이 180도 회전되어 있으므로, 로컬 전방(forward)이 플레이어 방향입니다.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (transform.position.z < -5f) Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        Debug.Log($"Enemy Hit! Remaining HP: {hp}");
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()?.TakeDamage(damageToPlayer);
            Destroy(gameObject);
        }
    }
}