using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float currentScore;
    void Awake()
    {
        Brick.OnBrickHit += OnBrickHit;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Brick.OnBrickHit -= OnBrickHit;
    }

    private void OnBrickHit(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
    }
}
