using Unity.VisualScripting;
using UnityEngine;

public class OnEnterTrigger : MonoBehaviour
{
    public GameObject[] Objects;

    private int DestroyedCount = 0;

    public float Time = 0.0f;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        foreach(GameObject obj in Objects)
        {
            if(collider.gameObject.Equals(obj) && !obj.gameObject.IsDestroyed())
            {
                Destroy(obj, Time);
                
                if(++DestroyedCount == Objects.Length)
                {
                    Destroy(gameObject);
                }

                return;
            }
        }
    }
}
