using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TravelSpeed = 3.0f;

    public float TravelTime = 3.0f;

    private Coroutine DestroyCoroutine;

    private Animator Anim;

    private bool Exploding = false;

    public LayerMask Ground;

    public void SetDirection(bool right)
    {
        if(right)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * TravelSpeed;

            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * TravelSpeed;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    void Start()
    {
        DestroyCoroutine = StartCoroutine(DestroyAfter());

        Anim = GetComponent<Animator>();

        Anim.enabled = false;

        GetComponentInChildren<Hitbox>().OnHit.AddListener(() =>
        {
            ExplodeNow();
        });
    }

    public void OnExplosionFinished()
    {
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        Anim.enabled = true;
        Exploding = true;
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(TravelTime);
        Explode();
    }

    private void ExplodeNow()
    {
        StopCoroutine(DestroyCoroutine);
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Explode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(((1 << collision.collider.gameObject.layer) & Ground) != 0)
        {
            ExplodeNow();
        }
    }

    void Update()
    {
    }
}
