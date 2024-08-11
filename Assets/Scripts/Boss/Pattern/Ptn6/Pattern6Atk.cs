using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern6Atk : MonoBehaviour
{
    PlayerHealth PH;
    Patten6Safe P6S;

    private void Awake()
    {
        PH = FindObjectOfType<PlayerHealth>();
        P6S = FindObjectOfType<Patten6Safe>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player") && P6S.inSafe == false)
        {
            PH.playerHealth -= 9f;
            PH.Damaged(PH.playerHealth / PH.playerMaxHealth);
        }
    }
}
