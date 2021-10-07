using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public ParticleSystem fireworks;
    public ParticleSystem fireworks2;
    [SerializeField]
    public TextMeshProUGUI yourText;
    public Rigidbody2D rb;
    void Start()
    {
        fireworks.Pause();
        fireworks2.Pause();
        rb = GetComponent<Rigidbody2D>();
        yourText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("dupa");
        rb.transform.Translate(Vector2.right * Time.deltaTime);

        rb.bodyType = RigidbodyType2D.Static;
        StartPlay();
        StartCoroutine(FadeTextToFullAlpha(2f, yourText));
        yourText.enabled = true; // May need to use .SetActive(true);

    }

    void StartPlay()
    {
        fireworks.Play();
        fireworks2.Play();

    }
    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
