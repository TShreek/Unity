using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    float xSpeed=0f;
    //float ySpeed = 0.01f;
    float zSpeed = 0f;
    [SerializeField] float mvSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        xSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * mvSpeed;
        zSpeed = Input.GetAxis("Vertical") * Time.deltaTime * mvSpeed;
        transform.Translate(xSpeed, 0, zSpeed);
    }
}
