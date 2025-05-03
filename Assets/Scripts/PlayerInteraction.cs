using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    private bool hasKey = false;
    private bool isOpened = false;
    Animator anim;
    


    void Start()
    {
        Chest ChestObject = FindObjectOfType<Chest>();
        anim = GetComponent<Animator>();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
     {
         string tag = collision.gameObject.tag;

         if (tag == "Key")
         {
             PickupKey(collision.gameObject);
         }
         
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

       if (tag == "DoubleJump")
        {
            TryJump(collision.gameObject);
            collision.GetComponent<Animator>().SetBool("isOpened", isOpened);
            StartCoroutine(closeChest(5f));
            
        }

        if (tag == "Dash")
        {
            TryJump(collision.gameObject);
            collision.GetComponent<Animator>().SetBool("isOpened", isOpened);
            StartCoroutine(closeChest(5f));
            
        }
    }

    private void PickupKey(GameObject key)
    {
        hasKey = true;
        key.SetActive(false);
    }

    private void TryJump(GameObject tag)
    {
        if (!hasKey)
        {
            return;
        }

        isOpened = true;
        
        hasKey = false;
        GameManager.Instance.canDoubleJump = true; 
    }

    private void TryDash(GameObject tag)
    {
        if (!hasKey)
        {
            return;
        }

        isOpened = true;

        hasKey = false;
        GameManager.Instance.canDash = true;
    }



    IEnumerator closeChest(float duration)
    {
        yield return new WaitForSeconds(duration);
        isOpened = false;

    }
}
