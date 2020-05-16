using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void TextUpdate(float value)
    {
        text.text = value.ToString();
    }
}
