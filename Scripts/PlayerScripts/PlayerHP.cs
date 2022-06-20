using UnityEngine;

/// <summary>
/// Player HP
/// </summary>
public class PlayerHP : MonoBehaviour
{
    public static float maxPlayerHealthPoints;
    public static float playerHealthPoints = 100;
    public Animator animator;
    public bool isDead = false;
    public PlayerHealthBar healthBar;
    private static bool isShielding;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        maxPlayerHealthPoints = playerHealthPoints;
        healthBar.SetMaxHealth(playerHealthPoints);
    }

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        isShielding = PlayerMovement.isShielding;
        Animations();
    }

    /// <summary>
    /// Take Hit
    /// </summary>
    /// <param name="damage"></param>
    public void takeHit(float damage)
    {
        // If the player is shielding
        // Then damage is negated
        // Otherwise damage is taken on hit
        if (!isShielding)
        {
            playerHealthPoints -= damage;
            healthBar.SetHealth(playerHealthPoints);
            if (playerHealthPoints <= 0)
            {
                isDead = true;
            }
        }
        else
        {
            playerHealthPoints -= 0;
            healthBar.SetHealth(playerHealthPoints);
            if (playerHealthPoints <= 0)
            {
                isDead = true;
            }
        }
    }

    /// <summary>
    /// Animations
    /// </summary>
    private void Animations()
    {
        animator.SetBool("isDead", isDead);
    }
}