using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    Pattern1 P1;
    Pattern2 P2;
    Pattern3 P3;
    Pattern4 P4;
    Pattern5 P5;
    Pattern6 P6;
    Groggy Gry;
    CameraShake CS;

    public bool playerAvoid = true;

    private void Awake()
    {
        P1 = FindObjectOfType<Pattern1>();
        P2 = FindObjectOfType<Pattern2>();
        P3 = FindObjectOfType<Pattern3>();
        P4 = FindObjectOfType<Pattern4>();
        P5 = FindObjectOfType<Pattern5>();
        P6 = FindObjectOfType<Pattern6>();
        Gry = FindObjectOfType<Groggy>();
        CS = FindObjectOfType<CameraShake>();
    }

    private void OnEnable()
    {
        StartCoroutine(Ptn(1));
    }

    private void OnDisable()
    {
        P1.Set();
        P2.Set();
        P3.Set();
        P4.Set();
        P5.Set();
        P6.Set();
    }

    public void PatternDo()
    {
        int rnd = Random.Range(1, 7);

        switch (rnd)
        {
            case 1:
                P1.Atk();
                StartCoroutine(Ptn(1));
                CS.Shake();
                break;
            case 2:
                P2.Atk();
                StartCoroutine(Ptn(1));
                CS.Shake();
                break;
            case 3:
                P3.Atk();
                StartCoroutine(Ptn(1));
                CS.Shake();
                break;
            case 4:
                P4.Atk();
                StartCoroutine(Groggy(5f));
                CS.Shake();
                break;
            case 5:
                P5.Atk();
                StartCoroutine(Ptn(1));
                CS.Shake();
                break;
            case 6:
                P6.Atk();
                StartCoroutine(Ptn(5));
                CS.Shake();
                break;
        }
    }

    IEnumerator Ptn(float WFS)
    {
        yield return new WaitForSeconds(WFS);

        PatternDo();
    }

    IEnumerator Groggy(float WFS)
    {
        yield return new WaitForSeconds(2.2f);

        if(playerAvoid == true)
        {
            Gry.GroggyStart();

            yield return new WaitForSeconds(WFS);

            PatternDo();
        }
        else if(playerAvoid == false)
        {
            PatternDo();
        }

        playerAvoid = true;
    }
}
