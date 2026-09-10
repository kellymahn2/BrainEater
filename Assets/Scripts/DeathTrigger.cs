using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().Damage(true);
        }
    }
}
