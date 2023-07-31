using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMeter : MonoBehaviour
{

    public Transform player;
    public WindManager windManager;
    public Slider slider;

    private void UpdateSlider()
    {
        Vector2 playerVector = new Vector2(player.right.x, player.right.z);
        float windProjection = Vector2.Dot(playerVector, windManager.GetWind());
        slider.value = windProjection / (windManager.windMaxMagnitude * 2) + 0.5f;
    }

    private void Update()
    {
        UpdateSlider();
    }
}
