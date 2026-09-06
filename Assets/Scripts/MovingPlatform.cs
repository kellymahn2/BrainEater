using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Vector2> Bounds;

    public int NextBound = 0;
    public float Speed = 10.0f;

    private Rigidbody2D Rb;

    public Vector2 MovementDelta { get; private set; }

    void Start()
    {
        Bounds.Insert(0, transform.position);

        for(int i = 1; i < Bounds.Count; ++i)
        {
            Bounds[i] += (Vector2)transform.position;
        }

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 currentPos = transform.position;

        if (Bounds[NextBound] == currentPos)
        {
            NextBound = (NextBound + 1) % Bounds.Count;
        }

        Vector2 nextPos = Vector2.MoveTowards(
            currentPos,
            Bounds[NextBound],
            Speed * Time.deltaTime
        );

        MovementDelta = nextPos - currentPos;

        transform.position = nextPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < -0.5f)
                {
                    //collision.gameObject.GetComponent<Player>().CurrentPlatform = this;
                    collision.transform.SetParent(transform);
                    break;
                }
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Player>().CurrentPlatform = null;
            collision.transform.SetParent(null);
        }
    }
}
