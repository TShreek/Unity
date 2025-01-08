using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip damageClip;
    float Damagevolume=0.4f;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    public void playShootingAudio(){
        if(shootClip != null){
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void playDamageAudio(){
       if(damageClip != null){
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, Damagevolume);
        } 
    }
}
