using UnityEngine;

public class GroundCheck : MonoBehaviour
{   
    public Transform GroundCheckTransform;
    public Vector2 BoxSize;
    public float CastDistance;

    public RaycastHit2D Hit{get; private set;}
    Collider2D Collider;

    public Color GroundedColor = Color.green, Color = Color.red;
    private bool IsGrounded = false;

    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    public bool CheckGrounded(LayerMask groundLayer)
    {
        MovingPlatform isOnPlatform = gameObject.GetComponentInParent<MovingPlatform>();
        if(isOnPlatform != null)
        {
            return IsGrounded = true;
        }
        
        Hit = Physics2D.BoxCast(GroundCheckTransform.position, BoxSize, 0.0f, -GroundCheckTransform.up, CastDistance, groundLayer);

        if(Hit.collider != null)
        {
            if(Hit.collider.IsTouching(Collider))
            {
                return IsGrounded = true;
            }
        }

        return IsGrounded = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = IsGrounded ? GroundedColor : Color;

        Gizmos.DrawWireCube(GroundCheckTransform.position + CastDistance * -GroundCheckTransform.up, BoxSize);
    }
}