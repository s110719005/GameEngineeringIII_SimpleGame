using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private int maxAttack = 50;
    public static AttackManager instance;
    private List<PlayerAttack> attacks = new List<PlayerAttack>();
    
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < maxAttack; i++)
        {
            InstantiateAttack();
        }
        Brick.OnBrickHitAt += OnBrickHitAt;
    }

    private void OnBrickHitAt(Vector3 position)
    {
        GenerateAttack(position);
    }

    public void GenerateAttack(Vector3 position)
    {
        if(attacks.Count > 0)
        {
            Debug.Log("Generate attack");
            attacks[0].gameObject.SetActive(true);
            attacks[0].transform.position = new Vector3(position.x, position.y, attacks[0].transform.position.z);
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            attacks[0].SetSpeed(randomX, randomY);
            attacks.Remove(attacks[0]);
        }
        else
        {
            InstantiateAttack();
            attacks[0].gameObject.SetActive(true);
            attacks[0].transform.position = new Vector3(position.x, position.y, attacks[0].transform.position.z);
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            attacks[0].SetSpeed(randomX, randomY);
        }

    }

    public void RecycleAttack(PlayerAttack attack)
    {
        attack.gameObject.SetActive(false);
        attack.SetSpeed(0, 0);
        attacks.Add(attack);
    }

    private void InstantiateAttack()
    {
        GameObject newAttackObject = Instantiate(attackPrefab, transform);
        PlayerAttack attack = newAttackObject.GetComponent<PlayerAttack>();
        if(attack != null)
        {
            attacks.Add(attack);
            newAttackObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
