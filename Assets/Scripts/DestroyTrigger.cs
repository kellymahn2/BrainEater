using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
