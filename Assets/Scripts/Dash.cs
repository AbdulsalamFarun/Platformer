using UnityEngine;
using System.Collections;


public class Dash : MonoBehaviour
{
    private bool canDash;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D body;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameManager.Instance.canDash)
        {
            
            StartCoroutine(DashAb());
        }
    }
    private IEnumerator DashAb()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;


    }
}
