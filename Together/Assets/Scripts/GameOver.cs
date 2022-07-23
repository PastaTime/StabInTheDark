using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver;
    GameObject[] finishObjects;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
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
            Debug.Log("Game Over!");
            Destroy(gameObject);
            gameOver = true;
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
