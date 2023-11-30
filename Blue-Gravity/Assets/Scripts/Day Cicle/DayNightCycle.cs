using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ClothGravity
{
    public enum DayNight
    {
        Day,
        Night,
    }

    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] float time = 0.0f; // 0.0 = meia-noite, 1.0 = meia-noite do dia seguinte
        [SerializeField] float dayLength = 120f;
        [SerializeField] Light2D globalLight;
        [SerializeField] Gradient lightColorGradient;
        [SerializeField] AnimationCurve lightIntensityCurve;
        private DayNight dayNight = DayNight.Day;

        void Update()
        {
            if (dayNight == DayNight.Day)
            {
                time += Time.deltaTime / dayLength;
            }
            else if (dayNight == DayNight.Night)
            {
                time -= Time.deltaTime / dayLength;
            }

            if (time > 1.0f)
            {
                time = 1;
                dayNight = DayNight.Night;
            }
            else if (time < 0)
            {
                time = 0;
                dayNight = DayNight.Day;
            }

            float intensityMultiplier = lightIntensityCurve.Evaluate(time);
            globalLight.intensity = intensityMultiplier;

            Color lightColor = lightColorGradient.Evaluate(time);
            globalLight.color = lightColor;
        }
    }

}
