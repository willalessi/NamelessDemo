using UnityEngine;

/// <summary>
/// Stationary Projectile
/// General movement handling of stationary projectile
/// type enemies
/// </summary>
public class StationaryProjectile : MonoBehaviour
{
    private GameObject target;
    private Transform targetTransform;
    public bool playerDetected;
    public Animator animator;
    public float distance = 5;
    public GameObject projectile;
    public GameObject projectileRight;
    private Vector2 projectilePos;

    /// <summary>
    /// Start
    /// References location of player
    /// </summary>
    private void Start()
    {
        target = GameObject.Find("Player");
    }

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        // Movement and Attack
        FollowPlayer();

        // Animations
        Animations();
    }

    /// <summary>
    /// Follow Player
    /// Changes direction of enemy based
    /// on player location
    /// </summary>
    private void FollowPlayer()
    {
        targetTransform = target.transform;
        if (Vector2.Distance(transform.position, targetTransform.position) <= distance)
        {
            if (targetTransform.position.x - transform.position.x >= 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    /// <summary>
    /// Fire Projectile
    /// Projectile attack handling
    /// </summary>
    private void FireProjectile()
    {
        if (playerDetected)
        {
            if (transform.eulerAngles == new Vector3(0, 180, 0))
            {
                projectilePos = transform.position;
                projectilePos += new Vector2(+0.3f, 0.2f);
                Instantiate(projectile, projectilePos, Quaternion.identity);
            }
            else if (transform.eulerAngles == new Vector3(0, 0, 0))
            {
                projectilePos = transform.position;
                projectilePos += new Vector2(-0.3f, 0.2f);
                Instantiate(projectileRight, projectilePos, Quaternion.identity);
            }
        }
    }

    /// <summary>
    /// Animations
    /// </summary>
    private void Animations()
    {
        animator.SetBool("playerDetected", playerDetected);
    }
}