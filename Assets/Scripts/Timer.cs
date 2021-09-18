using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeRemaining;
    public GameObject gameobj;
    public Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
        timeRemaining = 30;
        txt.text = "Time Left: " + timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            txt.text = "Time Left: " + timeRemaining;
        }

        else
            EndGame();
    }
    
    public void EndGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game Ended");
        
    }
}
