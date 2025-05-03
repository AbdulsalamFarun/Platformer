using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private MeleeAttack _meleeAttack;
    [SerializeField] private float _damagAmount;
    private float Push = 4;

    private float _maxHealth = 100;
    private float _currentHealth;

    [SerializeField] private MeleeAttack meleeAttack;


    private Rigidbody2D rb;
    Animator anim;
    public GameObject[] LootItems;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            
            TakeDamage(_damagAmount);
        }
    }

    public void TakeDamage(float amount)
    {

        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        rb.AddForce(Vector2.up * Push, ForceMode2D.Impulse);

        if (_currentHealth == 0)
        {
           Die();
        }

    }
    public void Die()
    {
        
        Destroy(gameObject);
        Itemdrop();
    }

    private void Itemdrop()
    {
        for (int i = 0; i < LootItems.Length; i++)
        {
            Instantiate(LootItems[i], transform.position, Quaternion.identity);
        }
    }

    
        
}
