using System;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        gameObject.transform.position = new Vector3(-5.8f, 0, player.transform.position.z + 40f);
    }
}
