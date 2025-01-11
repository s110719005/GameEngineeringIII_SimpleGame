using UnityEngine;

public class Brick : MonoBehaviour
{
    private int score;

    public delegate void BrickDelegate(int score);
    public static BrickDelegate OnBrickHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public void GetHit()
    {
        gameObject.SetActive(false);
        OnBrickHit?.Invoke(score);
        //invoke gethit
    }

    
}
