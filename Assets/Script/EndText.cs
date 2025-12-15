using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{

    public TMP_Text endText;
    public TMP_Text bottomText;

    // Start is called before the first frame update
    void Start()
    {
        endText.gameObject.SetActive(false);
        bottomText.gameObject.SetActive(false);
    }

    public void ShowEndText(string message)
    {
        if (message == "Loves me!" || message == "Really loves me!!")
        {
            endText.color = new Color32(237, 72, 72, 255);
        } else if (message == "Loves me not..." || message == "Really does not love me!!") {
            endText.color = new Color32(72, 237, 135, 255);
        }

        endText.text = message;
        bottomText.text = message;
        endText.gameObject.SetActive(true);
        bottomText.gameObject.SetActive(true);
    }

    public void Hide()
    {
        endText.gameObject.SetActive(false);
        bottomText.gameObject.SetActive(false);
    }
}
