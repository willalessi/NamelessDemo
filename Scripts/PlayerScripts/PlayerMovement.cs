using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public static float moveSpeed = 4;
    public static float jumpSpeed = 500;
    public static bool isShielding = false;
    public Vector3 grid;

    //Attack Hitboxes
    public GameObject atkHb;

    public GameObject HeavyAtkHb;

    private Rigidbody2D rb;
    private float move;
    private bool isJumping = false;
    private bool isAttacking = false;
    private bool isHeavyAttacking = false;
    private bool isRolling = false;
    private bool isDead;
    private bool finishedDeathAnimate = false;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Application.targetFrameRate = 60;
    }

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        grid = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        isDead = gameObject.GetComponent<PlayerHP>().isDead;

        if (!isDead)
        {
            Movement();
            Jumping();
            Attacking();
            Rolling();
            Shielding();
            DisableSwordHb();
        }
        else
        {
            rb.gravityScale = 0;
            rb.simulated = false;
        }

        if (finishedDeathAnimate)
        {
            if (rb.transform.position.y < 30)
            {
                rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2 * Time.deltaTime, transform.position.z);
            }
        }
        Animations();
    }

    /// <summary>
    /// Movement
    /// Player movement
    /// </summary>
    private void Movement()
    {
        // 2 way movement inputs
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Flips the player horizontally depending on movement direction
        if (move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    /// <summary>
    /// Jumping
    /// </summary>
    private void Jumping()
    {
        // Applies a jump force to the player
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
        }
    }

    /// <summary>
    /// Attacking
    /// </summary>
    private void Attacking()
    {
        // Attacking
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking && !isHeavyAttacking && !isJumping && !isRolling && !isShielding)
        {
            moveSpeed = moveSpeed * 0.8f;
            isAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !isHeavyAttacking && !isAttacking && !isJumping && !isRolling && !isShielding)
        {
            moveSpeed = moveSpeed * 0.6f;
            isHeavyAttacking = true;
        }
    }

    /// <summary>
    /// Rolling
    /// </summary>
    private void Rolling()
    {
        // Rolling
        if (Input.GetKeyDown(KeyCode.S) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && !isRolling && !isHeavyAttacking && !isAttacking && !isJumping)
        {
            Vector3 left = new Vector3(0, 180, 0);
            Vector3 right = new Vector3(0, 0, 0);

            isRolling = true;
            if (transform.eulerAngles == left)
            {
                rb.AddForce(Vector2.left * 1500);
            }
            else if (transform.eulerAngles == right)
            {
                rb.AddForce(Vector2.right * 1500);
            }
        }
    }

    /// <summary>
    /// Shielding
    /// </summary>
    private void Shielding()
    {
        // Shielding
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRolling && !isHeavyAttacking && !isAttacking && !isJumping)
        {
            isShielding = true;
        }
    }

    /// <summary>
    /// Disable Sword Hb
    /// Disables the hitboxes for attacking
    /// when the player is not attacking
    /// </summary>
    private void DisableSwordHb()
    {
        if (isAttacking)
        {
            atkHb.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (!isAttacking)
        {
            atkHb.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    /// <summary>
    /// OnCollisionEnter2D
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Checks if the player is grounded
        if (other.gameObject.CompareTag("Ground") && other.contacts[0].point.y < transform.position.y)
        {
            isJumping = false;
        }
    }

    /// <summary>
    /// Animations
    /// </summary>
    private void Animations()
    {
        // sets animations
        animator.SetFloat("Horizontal", Mathf.Abs(move));
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isHeavyAttacking", isHeavyAttacking);
        animator.SetBool("isRolling", isRolling);
        animator.SetBool("isShielding", isShielding);
    }

    // Animation events

    /// <summary>
    /// Attacking
    /// </summary>
    private void attacking()
    {
        isAttacking = false;
        moveSpeed = moveSpeed * 1.25f;
    }

    /// <summary>
    /// Heavy Attacking
    /// </summary>
    private void heavyAttacking()
    {
        isHeavyAttacking = false;
        moveSpeed = moveSpeed / 0.6f;
    }

    /// <summary>
    /// Rolling
    /// </summary>
    private void rolling()
    {
        isRolling = false;
    }

    /// <summary>
    /// Shielding
    /// </summary>
    private void shielding()
    {
        isShielding = false;
    }

    /// <summary>
    /// Death Animation Finished
    /// </summary>
    private void DeathAnimationFinished()
    {
        finishedDeathAnimate = true;
        AddTempSoulCrystal.tmpSoulCrystalCnt = 0;
        SceneManager.LoadScene("Player Hub");
    }
}