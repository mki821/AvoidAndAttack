using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject Pattern;
    [SerializeField]
    PlayerAttack playerAttack;

    public void onSetting()
    {
        UI.SetActive(true);
        if(Pattern != null && playerAttack != null)
        {
            Pattern.SetActive(false);

            playerAttack.set = true;
        }
    }

    public void Setting()
    {
        UI.SetActive(false);
        if (Pattern != null && playerAttack != null)
        {
            Pattern.SetActive(true);

            playerAttack.set = false;
        }
    }
}
