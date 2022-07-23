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
        if (Input.anyKeyDown)
        {
            audioSource.Stop();
            if (Input.GetKey(KeyCode.Alpha1))
            {
                print("load game");
                SceneManager.LoadScene(gameSceneName);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                audioSource.PlayOneShot(adjustVolumeClip, 1.0f);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                audioSource.PlayOneShot(turnOnScreenClip, 1.0f);
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                audioSource.PlayOneShot(leavingClip, 1.0f);

                Delay(leavingClip.length);
                Application.Quit();
                print("quit");
            }
            else if (Input.GetKey(KeyCode.Alpha0))
            {
                audioSource.PlayOneShot(welcomeClip, 1.0f);
            }
            else
            {
                audioSource.PlayOneShot(invalidInputClip, 1.0f);
            }
        }
    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}