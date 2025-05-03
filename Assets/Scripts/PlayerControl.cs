using UnityEngine;
using System;
using System.Collections;



public class PlayerControl : MonoBehaviour
{
    Vector2 checkPointPos;
    SpriteRenderer spriteRenderer;
    private bool _isDead;
    private bool hasKey = false;

    Animator anim;
    private void Start()
    {
        checkPointPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkPointPos = pos;
    }

    public void Die()
    {
        _isDead = true;
        anim.SetBool("Dead", _isDead);
        Debug.Log(_isDead);
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        spriteRenderer.enabled = false;
        _isDead = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        spriteRenderer.enabled = true;
        anim.SetBool("Dead", _isDead);
        Debug.Log(_isDead);

    }

}
