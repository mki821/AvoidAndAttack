using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern6 : MonoBehaviour
{
    public float patternCool = 1.5f;

    public void Atk()
    {
        StartCoroutine(Atkcool());
    }

    IEnumerator Atkcool()
    {
        transform.Find("SafeZone").gameObject.transform.position = 
            new Vector2(Random.Range(-7.9f, 7.9f), Random.Range(-2.85f-1.35f, 1.5f-1.35f));
        transform.Find("SafeZone").gameObject.SetActive(true);
        transform.Find("Warn").gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(patternCool);

        transform.Find("Warn").gameObject.SetActive(false);
        transform.Find("Attack").gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        transform.Find("Attack").gameObject.SetActive(false);
        transform.Find("SafeZone").gameObject.SetActive(false);
    }

    public void Set()
    {
        StartCoroutine(Setting());
    }

    public IEnumerator Setting()
    {
        transform.Find("SafeZone").gameObject.SetActive(false);
        transform.Find("Warn").gameObject.SetActive(false);
        StopCoroutine(Atkcool());
        transform.Find("Attack").gameObject.SetActive(false);

        yield return new WaitForSeconds(0.03f);
    }
}
