using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEff;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            snowEff.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            snowEff.Stop();
        }
    }
}
