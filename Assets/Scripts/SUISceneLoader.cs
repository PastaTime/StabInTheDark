using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SUISceneLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public string gameSceneName;
    public AudioClip welcomeClip;
    public AudioClip leavingClip;
    public AudioClip invalidInputClip;
    public AudioClip adjustVolumeClip;
    public AudioClip turnOnScreenClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(welcomeClip, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float SUIHorizontal = Input.GetAxis("SUIHorizontal");
        float SUIVertical = Input.GetAxis("SUIVertical");
        if (Input.GetAxis("SUIHorizontal") != 0 || Input.GetAxis("SUIVertical") != 0 || Input.anyKeyDown)
        {
            audioSource.Stop();
            if (SUIVertical == 1)
            {
                print("load game");
                SceneManager.LoadScene(gameSceneName);
            }
            else if (SUIHorizontal == 1)
            {
                audioSource.PlayOneShot(adjustVolumeClip, 1.0f);
            }
            else if (SUIVertical == -1)
            {
                audioSource.PlayOneShot(turnOnScreenClip, 1.0f);
            }
            else if (SUIHorizontal == -1)
            {
                audioSource.PlayOneShot(leavingClip, 1.0f);

                Delay(leavingClip.length);
                Application.Quit();
                print("quit");
            }
            else
            {
                audioSource.PlayOneShot(welcomeClip, 1.0f);
            }
        }
    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}