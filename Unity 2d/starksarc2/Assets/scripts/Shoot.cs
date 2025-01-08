using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate = 0.4f;   // Default fire rate
    float minimumFireRate = 0.2f;
    float projectileSpeed = 20f;
    float projectileLifeTime = 2f;
    public bool isFiring = false;

    [Header("AI")]
    float fireVariance = 0.4f;
    Coroutine firingCoroutine;
    [SerializeField] bool useAI;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
            if (!useAI) 
            {
                audioPlayer.playShootingAudio();
            }
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D rgbd = instance.GetComponent<Rigidbody2D>();
            if (rgbd != null)
            {
                rgbd.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);

            if (useAI)
            {
                yield return new WaitForSeconds(GetRandomFireTime());
            }
            else
            {
                isFiring=false;
                yield return new WaitForSeconds(fireRate); // Wait according to fire rate
            }
        }
    }

    public float GetRandomFireTime()
    {
        float fireT = UnityEngine.Random.Range(fireRate - fireVariance, fireRate + fireVariance);
        return Mathf.Clamp(fireT, minimumFireRate, float.MaxValue);
    }

    // Method to get the current fire rate
    public float GetFireRate()
    {
        return fireRate;
    }

    // Method to set a new fire rate
    public void SetFireRate(float newRate)
    {
        fireRate = newRate;
    }
}
