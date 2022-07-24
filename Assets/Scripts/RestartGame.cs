using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    public string startSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("SUIHorizontal") != 0 || Input.GetAxis("SUIVertical") != 0 || Input.anyKeyDown)
        {
            SceneManager.LoadScene(startSceneName);
        }
    }
}
