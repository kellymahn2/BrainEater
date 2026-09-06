using System.Collections;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private bool Active = false;

    public float MoveSpeed = 1.2f;
    private static Vector2 LocalTarget = 1.0f * Vector2.up;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(Active && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            player.Grow();

            Destroy(gameObject);
        }
    }

    private IEnumerator MoveUpCoroutine()
    {
        while(LocalTarget != (Vector2)transform.localPosition)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, LocalTarget, MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void MoveUp()
    {
        Active = true;
        StartCoroutine(MoveUpCoroutine());
    }
}
