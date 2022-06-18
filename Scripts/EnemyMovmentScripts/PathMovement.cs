using UnityEngine;

/// <summary>
/// Path Movement
/// Movement handling for standard path type
/// enemies
/// </summary>
public class PathMovement : MonoBehaviour
{
    public float speed;
    public Transform groundDetection;
    public Transform playerDetection;
    public Animator animator;
    public Transform target;
    public bool collidingOnPlayer = false;
    public bool collidingOnWall = false;
    public Rigidbody2D rb;
    public GameObject healthBar;
    public bool collidingOnEnemy = false;
    private bool movingLeft = true;
    private Vector3 origin;
    private bool isDeadLocal = false;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // The coordinates of the enemy when the game loads
        origin = transform.position;
    }

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        // Movement
        IsDeadCheck();
        StopMoving();
        Moving();

        // Animations
        Animations();
    }

    /// <summary>
    /// Is Dead Check
    /// </summary>
    private void IsDeadCheck()
    {
        if (rb.simulated == false)
        {
            isDeadLocal = true;
        }
    }

    /// <summary>
    /// Stop Moving
    /// </summary>
    private void StopMoving()
    {
        // If the enemy is dead or colliding on player, it stops moving
        if (collidingOnPlayer || isDeadLocal)
        {
            transform.Translate(Vector2.left * 0);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Moving
    /// </summary>
    private void Moving()
    {
        // Raycasting used to detect if an asset tagged "Ground" ends
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);

        // Checks the distance the enemy has traveled, if greater than a certain distance from the origin, it turns around
        if (movingLeft && transform.position.x < origin.x - 3)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingLeft = false;
        }
        else if (movingLeft == false && transform.position.x > origin.x + 3)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
        }

        // Checks if enemy is colliding on another enemys
        else if (movingLeft && collidingOnEnemy)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingLeft = false;
        }
        else if (!movingLeft && collidingOnEnemy)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
        }

        // Checks if the enemy is at the edge of the ground, turns around if so
        else if (groundInfo.collider == false)
        {
            if (movingLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }

        // Checks for wall collisions and turns the enemy around if collision occurs
        else if (collidingOnWall)
        {
            if (movingLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = true;
            }
        }
    }

    /// <summary>
    /// Animations
    /// </summary>
    private void Animations()
    {
        animator.SetBool("collidingOnPlayer", collidingOnPlayer);
    }
}