using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image hp;
    public float bossHealth;
    [SerializeField]
    private GameObject bossBoom;
    [SerializeField]
    SceneManage sceneManage;
    [SerializeField]
    private GameObject patternManager;

    private void Update()
    {
        if(hp.fillAmount < 0.01f)
        {
            Debug.Log("Dead");
        }
    }

    public void Attack(float playerDamage)
    {
        hp.fillAmount -= playerDamage/bossHealth;
        Debug.Log(playerDamage);
        Debug.Log(bossHealth);
        Debug.Log(playerDamage / bossHealth);

        if(hp.fillAmount < 0.001f)
        {
            StartCoroutine(OnDie());
        }
    }

    private IEnumerator OnDie()
    {
        patternManager.SetActive(false);
        bossBoom.SetActive(true);

        yield return new WaitForSeconds(5f);

        sceneManage.NextScene("GameClear");
    }
}
