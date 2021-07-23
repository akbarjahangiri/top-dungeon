using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    public List<FloatingText> floatingTexts = new List<FloatingText>();

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.text.text = msg;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;
        // Transfer world space to screen space so we can use it in the UI
        floatingText.gameObj.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.Show();
    }

    private void Update()
    {
        if (floatingTexts.Count > 0)
        {
            foreach (FloatingText floatingText in floatingTexts)
            {
                floatingText.UpdateFloatingText();
            }
        }
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if (txt == null)
        {
            txt = new FloatingText();
            txt.gameObj = Instantiate(textPrefab);
            txt.gameObj.transform.SetParent(textContainer.transform);
            txt.text = txt.gameObj.GetComponent<Text>();
            floatingTexts.Add(txt);
        }

        return txt;
    }
}