using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4Atk : MonoBehaviour
{
    PlayerHealth PH;
    PatternManager PM;

    private void Awake()
    {
        PH = FindObjectOfType<PlayerHealth>();
        PM = FindObjectOfType<PatternManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PH.playerHealth -= 1f;
        PM.playerAvoid = false;
        PH.Damaged(PH.playerHealth / PH.playerMaxHealth);
    }
}
