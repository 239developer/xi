using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageThing : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    public void SetText()
    {
        text.text = "Press E";
    }
}
