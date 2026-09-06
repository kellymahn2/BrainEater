using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Rigidbody2D Rb;

    public float MoveSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponentInParent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Target");
            collider.GetComponent<Player>().Damage();
        }
    }

    public void StartMoving()
    {
        Rb.linearVelocity = Vector2.left * MoveSpeed;
    }
}
