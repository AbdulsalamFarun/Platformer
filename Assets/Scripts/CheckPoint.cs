using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    PlayerControl gameController;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameController.UpdateCheckpoint(transform.position);
        }
    }


}
