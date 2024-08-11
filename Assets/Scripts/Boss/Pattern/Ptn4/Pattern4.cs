using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4 : MonoBehaviour
{
    public float patternCool = 0.4f;
    public float patternTerm = 1f;

    private int atkC = 0;

    public void Atk()
    {
        atkC = 0;

        StartCoroutine(Atkk());
    }

    IEnumerator Atkk()
    {
        transform.Find("Symbol").gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        transform.Find("Symbol").gameObject.SetActive(false);
        StartCoroutine(Atkcool(atkC));

        yield return new WaitForSeconds(patternTerm);

        atkC++;

        StartCoroutine(Atkcool(atkC));

        yield return new WaitForSeconds(patternTerm);

        atkC++;

        StartCoroutine(Atkcool(atkC));

        yield return new WaitForSeconds(patternTerm);

        atkC++;

        StartCoroutine(Atkcool(atkC));
    }

    IEnumerator Atkcool(int i)
    {
            transform.GetChild(i).gameObject.SetActive(true);

            yield return new WaitForSecondsRealtime(patternCool);

            transform.GetChild(i).gameObject.SetActive(false);
            transform.GetChild(i + 4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.03f);

            transform.GetChild(i + 4).gameObject.SetActive(false);
    }

    public void Set()
    {
        StartCoroutine(Setting());
    }

    public IEnumerator Setting()
    {
        transform.Find("Symbol").gameObject.SetActive(false);
        transform.Find("Warn1").gameObject.SetActive(false);
        transform.Find("Warn2").gameObject.SetActive(false);
        transform.Find("Warn3").gameObject.SetActive(false);
        transform.Find("Warn4").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.03f);
    }
}
