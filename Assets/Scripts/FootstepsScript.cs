using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    public float stepRate = 0.5f;
	public float stepCoolDown;
    [SerializeField] List<AudioClip> audioSamples;

    [SerializeField] AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
		if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f){
			int randomIndex = Random.Range(0, audioSamples.Count);
            audio.pitch = 1f + Random.Range (-0.2f, 0.2f);
            audio.volume = Random.Range (0.8f, 1.0f);
			audio.PlayOneShot (audioSamples[randomIndex], 0.9f);
			stepCoolDown = stepRate;
		}
    }
}
