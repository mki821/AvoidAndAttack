using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patten6Safe : MonoBehaviour
{
    public bool inSafe = false;

    private void OnEnable()
    {
        inSafe = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
            inSafe = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            inSafe = false;
    }
}
