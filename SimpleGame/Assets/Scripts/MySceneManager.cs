using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;
    public float score;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LoadGameOverScene(float score)
    {
        SceneManager.LoadScene("GameOverScene");
        this.score = score;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
