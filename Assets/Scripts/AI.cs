using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target;
    public float FollowSpeed = 0.2f;
    private bool isTarget;
    private float speed = 2;

    private Rigidbody2D body;

    private float newPos;

    

    

    Vector2 targetPos;

    public Transform posA, posB;


    private void Start()
    {
        
        body = GetComponent<Rigidbody2D>();
        targetPos = posB.transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.transform.position;
            Flip(false);
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.transform.position;
            Flip(true);
        }
        
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void Flip(bool face)
    {


        GetComponent<SpriteRenderer>().flipX = face;
        
    }

    

}
