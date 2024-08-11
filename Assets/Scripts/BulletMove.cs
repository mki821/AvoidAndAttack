using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed = 5f;
    BossHealth boss;

    private void Awake()
    {
        boss = FindObjectOfType<BossHealth>();
    }

    void Update()
    {
        if(transform.position.y > 5)
        {
            boss.Attack(10f);
            Destroy(gameObject);
        }

        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name.Contains("BossDrawback"))
        {
            boss.Attack(20f);
            Destroy(gameObject);
        }
    }
}
