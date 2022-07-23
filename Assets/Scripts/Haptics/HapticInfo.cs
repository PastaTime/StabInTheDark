using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HapticInfo
{
    public float[] hapticArray;
    public float hapticMaxDistance;
    public float tickInterval;
    public bool isHapticLooping;
}