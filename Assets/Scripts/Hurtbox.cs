using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    public UnityEvent<Hitbox> OnHurt;

    public void OnHit(Hitbox hitbox)
    {
        OnHurt.Invoke(hitbox);
    }

}