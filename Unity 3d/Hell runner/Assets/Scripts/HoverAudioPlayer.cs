using UnityEngine;
using UnityEngine.EventSystems;

public class HoverAudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();
    }
}
