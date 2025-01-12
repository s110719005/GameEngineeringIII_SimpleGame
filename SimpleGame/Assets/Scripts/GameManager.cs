using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float currentScore;
    private int currentHealth = 5;
    public static GameManager instance;

    [SerializeField] GameObject[] playerHealth;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameoverScene;

    public float CurrentScore => currentScore;
    void Awake()
    {
        SubscribeDelegate();
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubscribeDelegate()
    {
        Brick.OnBrickHit += OnBrickHit;
        PlayerAttack.OnDeadzoneHit += OnDeadzoneHit;
    }

    void OnDisable()
    {
        Brick.OnBrickHit -= OnBrickHit;
        PlayerAttack.OnDeadzoneHit -= OnDeadzoneHit;
    }


    private void OnBrickHit(int score)
    {
        currentScore += score;
        scoreText.text = "SCORE: " + currentScore.ToString("00#");
        Debug.Log("Score: " + currentScore);
        if(currentScore >= 452)
        {
            gameoverScene.SetActive(true);
        }
    }

    private void OnDeadzoneHit()
    {
        currentHealth --;
        if(currentHealth <= 0)
        {
            Debug.Log("Game Over");
            gameoverScene.SetActive(true);
            //Change Scene
            return;
        }
        playerHealth[currentHealth].SetActive(false);
    }
}
