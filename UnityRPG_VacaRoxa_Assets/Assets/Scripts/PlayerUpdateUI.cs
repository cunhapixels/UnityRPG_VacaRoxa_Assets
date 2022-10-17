using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpdateUI : MonoBehaviour, IComunicable<float>
{
    public void UpdateUIHealthText(float newHealth)
    {
        var slider = gameObject.GetComponent<Slider>();
        slider.value = newHealth / 100;
    }
}