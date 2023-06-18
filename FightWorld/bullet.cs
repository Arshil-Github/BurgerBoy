using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damageDealt;
    public float speed;

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<enemy>().TakeDamage(damageDealt);
            Debug.Log(damageDealt);
        }
        Destroy(gameObject);
    }

}
