using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groggy : MonoBehaviour
{
    public float GroggyTime = 5f;

    public void GroggyStart()
    {
        StartCoroutine(GroggyC(GroggyTime));
    }

    IEnumerator GroggyC(float GT)
    {
        int rnd = Random.Range(1, 3);

        transform.Find($"BossDrawback{rnd}").gameObject.SetActive(true);

        yield return new WaitForSeconds(GT);

        transform.Find($"BossDrawback{rnd}").gameObject.SetActive(false);
    }
}
