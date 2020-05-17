using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    public void TextUpdate(float value)
    {
        text.text = value.ToString();
    }
}
