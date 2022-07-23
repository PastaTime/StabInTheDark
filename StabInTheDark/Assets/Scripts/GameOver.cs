using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject[] finishObjects;
    // Start is called before the first frame update
    void Start()
    {
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinished");
        hideFinished();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
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
    }
}
