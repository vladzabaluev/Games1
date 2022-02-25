using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider slider;
    public Gradient gradient;
    Image fill;
    // Start is called before the first frame update
    private void Start()
    {
        slider = GetComponent<Slider>();
        fill = GetComponentInChildren<Image>();
    }
    public void SetMaxHealth(int maxHP)
    {

        slider.maxValue = maxHP;
        slider.value = maxHP;
        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
