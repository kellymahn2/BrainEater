using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public GameObject Player;

    public static RespawnManager Instance {get; private set;} = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        Instance = this;

        transform.position = Player.transform.position;
        transform.rotation = Player.transform.rotation;
        transform.localScale = Player.transform.localScale;
    }

    private void _Respawn()
    {
        Player.transform.position = transform.position;
        Player.transform.rotation = transform.rotation;
        Player.transform.localScale = transform.localScale;
    }

    private async void _RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        string currentName = scene.name;

        var v = SceneManager.LoadSceneAsync(currentName, LoadSceneMode.Additive);
        await v;
        await SceneManager.UnloadSceneAsync(scene);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentName));
    }

    public static void RestartLevel()
    {
        Instance?._RestartLevel();
    }

    public static void Respawn()
    {
        Instance?._Respawn();
    }

    private void _SetPosition(Vector3 respawnPos)
    {
        transform.position = respawnPos;
    }

    public static void SetPosition(Vector3 respawnPos)
    {
        Instance?._SetPosition(respawnPos);
    }
}
