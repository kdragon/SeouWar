using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float xRange = 5f; // 좌우 이동 제한 범위

    [Header("Combat")]
    public float hp = 100f;
    public GameObject bulletPrefab;
    public Transform firePoint; // 총알이 나가는 위치
    public float fireRate = 0.15f;
    private float nextFireTime;

    void Update()
    {
        HandleMovement();
        HandleAutoFire();
    }

    void HandleMovement()
    {
        float moveInput = 0;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) moveInput = -1;
            else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) moveInput = 1;
        }

        Vector3 pos = transform.position;
        pos.x += moveInput * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xRange, xRange);
        transform.position = pos;
    }

    void HandleAutoFire()
    {
        if (Time.time >= nextFireTime)
        {
            if (bulletPrefab != null && firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }
            nextFireTime = Time.time + fireRate;
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Debug.Log("Game Over!");
            gameObject.SetActive(false); // 사망 처리
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 25), $"HP: {hp}");
    }
}