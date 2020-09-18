
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    int currentScene;
    // Start is called before the first frame update
    private void Awake()
    {
        int numMusPlayers  = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }

    }
    
    void Start()
    {
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadNextLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadNextLevel()
    {
        int nextSceneIndex = currentScene + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
