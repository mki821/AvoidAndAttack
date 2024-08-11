using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth = 10f;

    public float playerHealth;
    private GameObject health;
    private float originXPos;
    private float originXSize;
    [SerializeField]
    PlayerMove player;

    private void Awake()
    {
        health = transform.Find("PlayerHealth").gameObject;
    }

    private void Start()
    {
        originXPos = health.transform.localPosition.x;
        originXSize = health.transform.localScale.x;
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        if(playerHealth < 0.001f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Damaged(float enemyDamage)
    {
        player.Hit();
        float changeHealth = originXSize * enemyDamage;

        health.transform.localScale = new Vector2(changeHealth, health.transform.localScale.y);
        health.transform.localPosition = new Vector2(originXPos - ((originXSize - changeHealth) / 2), health.transform.localPosition.y);
    }
}
