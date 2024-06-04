using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconEffect : MonoBehaviour
{
    [SerializeField]
    private Image blinkImage;
    private Color orgColor;
    private Color targetColor;
    private Color black = Color.black;


    public void Awake()
    {
        orgColor = new Color(0f, 0f, 0f, 1f);
        targetColor = new Color(0f, 0f, 0f, 0f);
        blinkImage = GetComponent<Image>();
    }

    public void SetBlink(float duration)
    {
        StartCoroutine("Blink", duration);
        blinkImage.color = orgColor;
    }

    private IEnumerator Blink(float duration)
    {
        float a;
        float newduration = duration / 4;
        for (int i = 0; i < 4f; i++)
        {
            float elapsedTime = 0f;
            while (elapsedTime < (newduration))
            {
                elapsedTime += Time.deltaTime;
                if(i % 2 == 0)
                {
                    a = Mathf.Lerp(1f, 0f, elapsedTime / newduration);
                }
                else
                {
                    a = Mathf.Lerp(0f, 1f, elapsedTime / newduration);
                }
                orgColor.a = a;
                blinkImage.color = orgColor;
                yield return null;
            }
        }
    }
}
