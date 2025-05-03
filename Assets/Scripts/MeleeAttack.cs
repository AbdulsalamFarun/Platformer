using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    

    Animator anim;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            
        }
        
    }
  
}
