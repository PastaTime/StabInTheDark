using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject[] finishObjects;
    GameObject[] timerUI;
    public AudioClip winingClip;
    public AudioClip losingClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinished");
        timerUI = GameObject.FindGameObjectsWithTag("Timer");
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
        hideFinished();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            Destroy(gameObject);
            showFinished(true);
        }
    }

    public void hideFinished()
    {
        foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
    }

    public void showFinished(bool Win)
    {
        
        foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
        foreach(GameObject g in timerUI){
            g.SetActive(false);
        }
        if (Win)
        {
            audioSource.PlayOneShot(winingClip);
        }
        else
        {
            audioSource.PlayOneShot(losingClip);
        }
    }
}
