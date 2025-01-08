using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
{
    // Get the current position
    Vector3 newPosition = transform.position;

    // Modify the y component
    newPosition.y += 1f * Time.deltaTime;

    // Apply the new position back to the transform
    transform.position = newPosition;
}
    }
    IEnumerator selfDestruct(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
