using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value = 1;


   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            
            player.AddMoney(Value);

            Destroy(gameObject);
        }
    }   

}
