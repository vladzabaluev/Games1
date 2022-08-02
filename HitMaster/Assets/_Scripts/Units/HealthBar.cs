using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider HealthSlider;
    [SerializeField] private Color FillColor;

    // Start is called before the first frame update
    private void Awake()
    {
        HealthSlider = GetComponent<Slider>();
        HealthSlider.interactable = false;
        HealthSlider.fillRect.GetComponent<Image>().color = FillColor;
    }

    // Update is called once per frame
    public void SetValue(int hp, int maxHP)
    {
        HealthSlider.value = (float)hp / maxHP;
    }
}