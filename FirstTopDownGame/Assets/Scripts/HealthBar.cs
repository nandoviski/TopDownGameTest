using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Image heartImage;

    Slider slider;
    
    void Awake()
	{
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        if (slider.value <= 0)
        {
            heartImage.sprite = emptyHeart;
        }
    }
}
