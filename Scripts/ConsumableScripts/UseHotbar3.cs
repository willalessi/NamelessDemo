using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Use Hotbar 3
/// Uses damage potion
/// </summary>
public class UseHotbar3 : MonoBehaviour
{
    public Animator animator;
    public Text damageCounter;
    public BoxCollider2D explodeCollider;
    public static float explosionDamage = 5;
    private bool dmgPotionActive = false;

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && HotbarHandling.damagePotions != 0)
        {
            dmgPotionActive = true;
            HotbarHandling.damagePotions -= 1;
            damageCounter.text = "x" + HotbarHandling.damagePotions;
            explodeCollider.enabled = true;
        }
        Animations();
    }

    /// <summary>
    /// OnTriggerEnter2D
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyHP>();
        if (other.gameObject.tag == "Enemy")
        {
            enemy.takeHit(explosionDamage);
        }
    }

    /// <summary>
    /// Animations
    /// </summary>
    private void Animations()
    {
        animator.SetBool("dmgPotionActive", dmgPotionActive);
    }

    /// <summary>
    /// Explosion Cancel
    /// </summary>
    private void explosionCancel()
    {
        explodeCollider.enabled = false;
        dmgPotionActive = false;
    }
}