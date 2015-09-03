using UnityEngine;
using UnityEngine.UI;

public class ChangeColorBySize : MonoBehaviour
{


    Image img;
    Slider slider;
    public Color minColor, maxColor;
    // Use this for initialization
    void Start()
    {
        img = GetComponentInChildren<Image>();
        slider = GetComponentInParent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Jogador.Vida/100;
        img.color = Color.Lerp(maxColor, minColor, slider.value / slider.maxValue);
    }
}