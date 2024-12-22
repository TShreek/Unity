using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] float waitTime = 3f;
    Rigidbody rigidBody;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody.useGravity = false;
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            if (!meshRenderer.enabled)
            {
                rigidBody.useGravity = true;
                meshRenderer.enabled = true;
            }
        }
    }
}
