using UnityEngine;

public class LootItems : MonoBehaviour
{
    private Rigidbody2D itemRb;
    public float dropForce = 5;
    

    


    private void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
        
        

    }


}
