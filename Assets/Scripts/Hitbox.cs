using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public UnityEvent OnHit;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hurtbox hurtbox = collision.gameObject.GetComponent<Hurtbox>();

        if(hurtbox != null)
        {
            OnHit.Invoke();
            hurtbox.OnHit(this);
        }
    }
}
