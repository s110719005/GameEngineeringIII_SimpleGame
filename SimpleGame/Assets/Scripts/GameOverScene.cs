using TMPro;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + GameManager.instance.CurrentScore.ToString("00#");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
