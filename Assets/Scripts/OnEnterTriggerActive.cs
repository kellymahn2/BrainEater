using UnityEngine;

public class OnEnterTriggerActive : MonoBehaviour
{
    public GameObject[] Objects;

    public string RequiredTag = "Player";

    public bool InitialState = false;

    public bool TriggerActivatedState = true;

    public void Start()
    {
        SetStatus(InitialState);
    }

    private void SetStatus(bool active)
    {
        foreach(GameObject obj in Objects)
        {
            obj.SetActive(active);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(RequiredTag))
        {
            SetStatus(TriggerActivatedState);
        }
    }
}
