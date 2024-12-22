using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McQueen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = -Input.GetAxis("Horizontal") * Time.deltaTime ;
        float moveSpeed = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(0,0,rotateSpeed*150);
        transform.Translate(0, moveSpeed*15, 0);
    }
}
