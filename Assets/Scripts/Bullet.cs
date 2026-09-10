using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TravelSpeed = 3.0f;

    public float TravelTime = 3.0f;

    private Coroutine DestroyCoroutine;

    private Animator Anim;

    private bool Exploding = false;

    public void SetDirection(bool right)
    {
        if(right)
        {
            Vector3 angles = transform.localRotation.eulerAngles;
            angles.y = 0.0f;
            
            transform.localEulerAngles = angles;
        }
        else
        {
            Vector3 angles = transform.localRotation.eulerAngles;
            angles.y = 180.0f;
            
            transform.localEulerAngles = angles;
        }
    }

    void Start()
    {
        DestroyCoroutine = StartCoroutine(DestroyAfter());

        Anim = GetComponent<Animator>();

        Anim.enabled = false;

        GetComponentInChildren<Hitbox>().OnHit.AddListener(() =>
        {
            StopCoroutine(DestroyCoroutine);
            Explode();
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

    void Update()
    {
        if(Exploding)
        {
            return;
        }

        transform.position += transform.right * TravelSpeed * Time.deltaTime;
    }
}
