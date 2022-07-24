using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject[] finishObjects;
    GameObject[] timerUI;
    // Start is called before the first frame update
    void Start()
    {
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinished");
        timerUI = GameObject.FindGameObjectsWithTag("Timer");
        hideFinished();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            showFinished();
        }
    }

    public void hideFinished()
    {
        foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
    }

    public void showFinished()
    {
        foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
        foreach(GameObject g in timerUI){
            g.SetActive(false);
        }
    }
}
