using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool cooldown = true;

    public float playerDamage = 1f;
    public float cooltime = 1f;
    public GameObject bulletPrefab;
    public bool set = false;
    BossHealth BH;

    void Update()
    {
        if (cooldown == true && Input.GetMouseButtonDown(0) && set == false)
        {
            Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            StartCoroutine(cool());
        }
    }

    IEnumerator cool()
    {
        cooldown = false;
                                                                                                                                                                                                                                                    
        yield return new WaitForSeconds(cooltime);

        cooldown = true;
    }


}
