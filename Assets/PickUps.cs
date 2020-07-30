using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    private float collectibles = 0;

    public TextMeshProUGUI textCollectibles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Collect")
        {
            collectibles ++;
            textCollectibles.text = collectibles.ToString();

            Destroy(collision.gameObject);
        }
    }
}
