using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float questionTime = 20.2f;
    [SerializeField] float answerTime = 10.5f;
    float timervalue = 0;
    bool answered=false;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    void updatetimer()
    {
        timervalue -= Time.deltaTime;
        if (timervalue <= 0)
        {
            timervalue = questionTime;
            bool answered = true;    
        }
        if (answered)
        {
            timervalue = answerTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
