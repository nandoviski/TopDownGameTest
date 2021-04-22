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

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        if (slider.value <= 0)
        {
            heartImage.sprite = emptyHeart;
        }
    }
}
