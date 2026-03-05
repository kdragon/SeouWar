using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;

    void Update()
    {
        // 전방(Z축)으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        // 일정 거리 이상 나가면 삭제
        if (transform.position.z > 50f) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Collider가 자식에 있을 수 있으므로 InParent로 찾습니다.
            Enemy enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null) enemy.TakeDamage(damage);
            Destroy(gameObject); // 총알 삭제
        }
    }
}