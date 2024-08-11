using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5Atk : MonoBehaviour
{
    PlayerHealth PH;

    private void Awake()
    {
        PH = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PH.playerHealth -= 1f;
        PH.Damaged(PH.playerHealth / PH.playerMaxHealth);
    }
}
