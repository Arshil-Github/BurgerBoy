using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UFOAI : MonoBehaviour

{
    public int maxHealth = 100;
    int currentHealth;

    public Transform player;
    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;

    public int attackDamage;

    public Slider healthbar;

    public Animator anim;
    public bool isFlipped = false;

    public fightManager fm;

    public ParticleSystem impact;

    public SpriteRenderer weaponimage;
    public float speed;
    public float rangeDetect;

    public bool isBoss;
    public static bool canAttack;
    public float DelayInAttack;
    bool dead;

    public int GotoLevel;
    // Start is called before the first frame update
    void Start()
    {

        maxHealth = globalObject.Instance.enemyMaxHealth;
        if (maxHealth == 0)
        {
            maxHealth = 100;
        }

        isBoss = globalObject.Instance.eBoss;

        currentHealth = maxHealth;
        healthbar.maxValue = maxHealth;

        weaponimage.sprite = globalObject.Instance.Eweapon.weaponImage;
        attackDamage = globalObject.Instance.eAttack;
        DelayInAttack = globalObject.Instance.eDelay;
        rangeDetect = globalObject.Instance.eRange;

        canAttack = false;
        dead = false;

    }


    public void TakeDamage(int damage)
    {
        if (dead == false)
        {

            currentHealth -= damage;
            healthbar.value = currentHealth;

            anim.Play("EnemyHurt");
            fm.CreatePopUp(transform.position, damage);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void Disappear()
    {

        if (GameObject.Find("CutSceneManager") != null && globalObject.Instance.TransferToScene != 0)
        {
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(globalObject.Instance.TransferToScene);
            globalObject.Instance.TransferToScene = 0;
        }
        else
        {
            GameObject.Find("LevelLoader").GetComponent<levelloader>().LoadNextLevel(globalObject.Instance.TransferToScene);

        }

        Destroy(gameObject);
    }
    void Die()
    {
        anim.SetTrigger("Die");
        dead = true;
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerMovement>().takeDamage(attackDamage);
            impact.Play();
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    private void Update()
    {
        if (canAttack == false)
        {
            StartCoroutine(AttackDelay());
        }

        if (player.GetComponent<PlayerMovement>().currenthealth <= 0)
        {
            anim.ResetTrigger("Attack");
        }
        if (isBoss == true && currentHealth <= maxHealth / 2)
        {
            Enraged();
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(DelayInAttack);
        canAttack = true;
    }

    public void Enraged()
    {
        attackDamage += 20;
        speed += 25;
        globalObject.Instance.eBoss = false;
        isBoss = false;
    }
}
