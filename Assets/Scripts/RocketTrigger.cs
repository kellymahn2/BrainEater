using UnityEngine;

public class RocketTrigger : MonoBehaviour
{
    private Rigidbody2D Rb;

    public float MoveSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void StartMoving()
    {
        Rb.linearVelocity = Vector2.left * MoveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger");
            StartMoving();
        }
    }
}
