using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bridgeInfo : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI yourText;
    // Insert your text object inside unity inspector

    void Start()
    {
        yourText.enabled = false; // You may need to use .SetActive(false);
    }


    // Assuming you're using a 2D platform
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // This is where you make your text object appear on screen
           // StartCoroutine(FadeTextToFullAlpha(1f, yourText));
            yourText.enabled = true; // May need to use .SetActive(true);
        }
    }

   /* void OnTriggerExit2D(Collider2D collision)
    {
        // Here is where you make the text disappear off screen
        if (collision.tag == "Player")
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, yourText));

            yourText.enabled = false; // May need to use .SetActive(false);
        }
    }
    */

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

   /* public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }*/
}

