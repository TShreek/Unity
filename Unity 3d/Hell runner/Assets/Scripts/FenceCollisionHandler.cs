using UnityEngine;

public class FenceCollisionHandler : MonoBehaviour
{
    private Player player;
    private AnimatorTrigger animatorTrigger;
    private bool canTakeDamage = true;

    [SerializeField] private int damage = 10;

    void Start()
    {
        animatorTrigger = FindFirstObjectByType<AnimatorTrigger>();
        if (animatorTrigger == null)
        {
            Debug.LogError("Animator trigger not found by collision module");
        }
        player = FindFirstObjectByType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found by fence collision handler");
        }
    }

    private void Update()
    {
        // Now, damage can only be taken when NOT jumping
        canTakeDamage = !animatorTrigger.isJumping;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision with " + other.transform.name);

        if (other.transform.CompareTag("Player") && canTakeDamage)
        {
            Debug.Log("Player took damage: " + damage);
            player.DealDamage(damage);
        }
        else
        {
            Debug.Log("No damage, CanTakeDamage value = " + canTakeDamage);
        }
    }
}