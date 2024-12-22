using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    int bumpNo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        GetComponent<MeshRenderer>().material.color = Color.gray;
        if(collision.gameObject.tag == "Player")
        {
            bumpNo++;
            Debug.Log("IMPACT no: " + bumpNo);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
