using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceMaker : MonoBehaviour
{
    // Public
    public GameObject player;
    public float paceIntensity = 1.0f;

    // Private
    float playerDistance = 0.0f;
    float distanceScalar = 1.0f;
    HapticSource heartHaptic;

    void Start()
    {
        heartHaptic = gameObject.GetComponent<HapticSource>();
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        distanceScalar = playerDistance/heartHaptic.hapticInfo.hapticMaxDistance;
        heartHaptic.SetIntervalScalar((distanceScalar)*paceIntensity);
    }
}
