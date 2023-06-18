using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    public Transform AttackPoint;
    public float attackRadius;
    public LayerMask enemyLayers;
    public healthbar heathSlider;

    public int attackDamage;
    public int attackSubtracted;

    public int maxhealth;
    public int currenthealth;

    float HorizontalMove = 0f;
    bool isJumping = false;

    public static int heavyDamage = 0;
    public static float heavyRange = 0;

    public float runSpeed = 40f;


    public float runSpeedNormal = 40f;
    public float runSpeedHeavy = 40f;

    public fightManager fm;
    public ParticleSystem impact;

    public bool lost = false;
    private void Start()
    {
        currenthealth = maxhealth;
        heathSlider.SetMaxHealth(maxhealth);

        int a = globalObject.Instance.playerHunger;

        if (a < 20 || a > 80)
        {
            runSpeed = runSpeedHeavy;
        }
        else
        {
            runSpeed = runSpeedNormal;
        }
        if(a < 40 || a > 60)
        {
            attackDamage -= attackSubtracted;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        HorizontalMove = touchControls.HorizontalButton * runSpeed;

        if(HorizontalMove == 0)
        {
            HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        anim.SetFloat("Speed", HorizontalMove);

        if(Input.GetButton("Jump") || touchControls.Jump && isJumping == false)
        {
            isJumping = true;
            anim.SetBool("Jump", true);
        }
        else if (!touchControls.Jump)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
        
    }


    public void Landing()
    {
        anim.SetBool("Jump", false);
    }
    void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
    public void Attack()
    {
        //This function can be edited in animation window

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius + heavyRange, enemyLayers);

        foreach(Collider2D e in hitEnemies)
        {
            e.GetComponent<enemy>().TakeDamage(attackDamage + heavyDamage);
            e.GetComponent<enemy>().DontMove();
            impact.Play();
            if(e != null)
            {
                combatSystem.hitAnEnemy = true;
            }
        }

        heavyDamage = 0;
        heavyRange = 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
    }
    public void takeDamage(int damage)
    {
        currenthealth -= damage;
        heathSlider.SetHealth(currenthealth);

        AndroidManager.HapticFeedback();

        fm.CreatePopUp(transform.position, damage);
        anim.SetTrigger("damage");

        if(currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        lost = true;
    }

    //COMBO
}
