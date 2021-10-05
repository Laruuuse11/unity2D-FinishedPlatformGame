using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;
    BoxCollider2D arrowCollider;
    
    // Update is called once per frame
    void Update()
    {
        DirectionArrowsRight();
        DirectionArrowsLeft();
    }
    

    private void OnTriggerEnter2D(Collider2D  collider2D)
    {
        
        var health = collider2D.GetComponent<Health>();
        
            health.DealDamage(damage);
            Destroy(gameObject);
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void DirectionArrowsRight()
    {
        if (FindObjectOfType<Player>().transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(0.4f, 0.4f);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            Destroy(gameObject, 0.3f);
        }
    }
    private void DirectionArrowsLeft()
    {
        if (FindObjectOfType<Player>().transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-0.4f, 0.4f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            Destroy(gameObject, 0.3f);
            
        }
    }

}
