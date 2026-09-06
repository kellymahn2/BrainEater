using UnityEngine;

public class Box : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    MoveUp();                    
                    break;
                }
            }
        }
    }    


    private void MoveUp()
    {
        GetComponentInChildren<Mushroom>().MoveUp();        
    }
}
