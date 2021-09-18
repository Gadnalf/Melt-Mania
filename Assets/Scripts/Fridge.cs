using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public Timer TimerS;
    
    // Start is called before the first frame update
    void Start()
    {
        Timer S = GameObject.FindObjectOfType(typeof(Timer)) as Timer;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            TimerS.EndGame();
        }
    }
}
