using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#


public class HapticSource : MonoBehaviour
{
    PlayerIndex playerIndex;

    // Public
    public HapticInfo hapticInfo;
    public float hapticStrength = 1.0f;
    public int hapticOffset = 0;
    public bool syncAudioToHaptic = false;
    public bool playHapticOnStart = false;
    public bool playHapticOnCollision = false;

    // Private
    float timer;
    float collisionScalar = 1.0f;
    float intervalScalar = 1.0f;
    int index;
    bool isColliding = false;
    HapticListener[] listeners;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (playHapticOnStart)
        {
            index = hapticOffset % hapticInfo.hapticArray.Length;
        }
        else
        {
            index = hapticInfo.hapticArray.Length;
        }

        listeners = GameObject.FindObjectsOfType<HapticListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update haptic playing
        if (hapticInfo.hapticArray.Length > 0)
        {
            if (timer <= 0.0f)
            {               
                if (index + 1  < hapticInfo.hapticArray.Length)
                {
                    float hapticValue = hapticInfo.hapticArray[index]*Mathf.Clamp(hapticStrength, 0.0f, 1.0f);
                    if (playHapticOnCollision && isColliding)
                    {
                        hapticValue *= collisionScalar;
                    }
                    float hapticLeft = Mathf.Abs(Mathf.Clamp(hapticValue,-1.0f, 0.0f));
                    float hapticRight = Mathf.Clamp(hapticValue, 0.0f, 1.0f);

                    foreach (HapticListener lis in listeners)
                    {
                        lis.HearHaptics(hapticLeft, hapticRight, transform.position, hapticInfo.hapticMaxDistance);
                    }

                    if (index == 0 && syncAudioToHaptic)
                    {
                        float dist = Vector3.Distance(listeners[0].transform.position, transform.position);
                        float distScale = 1.0f - (dist/hapticInfo.hapticMaxDistance);
                        audioSource.pitch = 1.0f + distScale;
                        audioSource.volume = distScale;
                        audioSource.Play(0);             
                    }

                    timer = hapticInfo.tickInterval * intervalScalar;
                    index++;
                }
                else if (hapticInfo.isHapticLooping || (playHapticOnCollision && isColliding))
                {
                    index = 0;

                    if (playHapticOnCollision && isColliding)
                    {
                        float inX = Mathf.Abs(Input.GetAxis("Horizontal"));
                        float inY = Mathf.Abs(Input.GetAxis("Vertical"));
                        collisionScalar = (inX + inY)*0.75f;
                        
                        if (inX == 0.0f && inY == 0.0f)
                        {
                            index = hapticInfo.hapticArray.Length;
                        }
                    }
                }              
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    void PlayHaptic(bool isLooping)
    {
        index = 0;
        hapticInfo.isHapticLooping = isLooping;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            index = 0;
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        index = hapticInfo.hapticArray.Length;
        isColliding = false;
    }

    public void SetIntervalScalar (float intervalScaleValue)
    {
        intervalScalar = intervalScaleValue;
    }
}
