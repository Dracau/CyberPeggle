using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Fields

    private bool m_isShaking = false;
    private float m_currentTime = 0;
    private float m_currentIntensity = 0;
    private float m_decreaseFactor = 0;
    #endregion Fields

    #region Functions
    public void ScreenShake() => ScreenShake(new ScreenShakeParameters());
    public void ScreenShake(ScreenShakeParameters a_pamrameters)
    {
        m_isShaking = true;
        m_currentTime = a_pamrameters.duration;
        m_currentIntensity = a_pamrameters.intensity;
        m_decreaseFactor = a_pamrameters.decreaseFactor;
    }

    private void Update()
    {
        if (m_isShaking == true)
        {
            if (m_currentTime > 0)
            {
                m_currentTime -= Time.deltaTime;
                Vector3 pos = Vector3.zero;
                pos.x += UnityEngine.Random.Range(-m_currentIntensity, m_currentIntensity);
                pos.y += UnityEngine.Random.Range(-m_currentIntensity, m_currentIntensity);

                transform.localPosition = pos;
                m_currentIntensity -= m_decreaseFactor * Mathf.Sign(m_currentIntensity);
            }
            else
            {
                transform.localPosition = Vector3.zero;
                m_isShaking = false;
            }
        }
    }
    #endregion Functions
}
[Serializable]
public class ScreenShakeParameters
{
    public float intensity = 1.6f;
    public float duration = 0.65f;
    // intensity to lose after 1 sec
    [Range(0, 5)] public float decreaseFactor = 0.09f;
}
