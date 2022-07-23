using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class HapticListener : MonoBehaviour
{
    // Public
    public PlayerIndex playerIndex = 0;
    public float tickInterval = 0.2f;

    // Private
    HapticSource[] allHapticSources;
    float hapticLeft;
    float hapticRight;
    float timer;

    void Update()
    {
        if (timer <= 0.0f)
        {
            GamePad.SetVibration(playerIndex, Mathf.Clamp(hapticLeft,0.0f,1.0f), Mathf.Clamp(hapticRight,0.0f,1.0f));
            hapticLeft = 0;
            hapticRight = 0;
            timer = tickInterval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void HearHaptics(float left, float right, Vector3 sourcePosition, float sourceMaxDistance)
    {
        float distance = Mathf.Clamp(Vector3.Distance(transform.position, sourcePosition), 0.0f, sourceMaxDistance);
        float intensity = 1.0f - (distance / sourceMaxDistance);
        hapticLeft += left * intensity;
        hapticRight += right * intensity;
    }
}
