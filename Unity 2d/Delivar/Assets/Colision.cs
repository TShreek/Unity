using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField] Color32 packCol = new Color32(0, 255, 162, 255);
    [SerializeField] Color32 noPackCol = new Color32(255, 16, 0, 255);
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    
    }
    bool pack = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION!!");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !pack)
        {
            Debug.Log("package picked up!");
            Destroy(other.gameObject,0.15f);
            pack = true;
            sprite.color = packCol;
        }
        else if(other.tag== "Delivery_pt" && pack)
        {
            Debug.Log("Package Delivered !");
            pack = false;
            sprite.color = noPackCol;
        }
       // Debug.Log("Interaction!");
    }
}
