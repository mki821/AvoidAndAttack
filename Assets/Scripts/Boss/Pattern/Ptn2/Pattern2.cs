using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public float patternCool = 0.4f;

    public void Atk()
    {
        StartCoroutine(Atkcool());
    }

    IEnumerator Atkcool()
    {
        transform.Find("Symbol").gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        transform.Find("Symbol").gameObject.SetActive(false);
        transform.Find("Warn").gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(patternCool);

        transform.Find("Warn").gameObject.SetActive(false);
        transform.Find("Attack").gameObject.SetActive(true);

        yield return new WaitForSeconds(0.03f);

        transform.Find("Attack").gameObject.SetActive(false);
    }

    public void Set()
    {
        StartCoroutine(Setting());
    }

    public IEnumerator Setting()
    {
        transform.Find("Symbol").gameObject.SetActive(false);
        transform.Find("Warn").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.03f);
    }
}
