using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float speedVertical = 1;
    [SerializeField] private float speedHorizontal = 1;
    [SerializeField] private float modifier = 2;
    [SerializeField] private bool isMainAttack = false;
    private float currentSpeedVertical;
    private float currentSpeedHorizontal;
    private Vector3 originPoint;
    private bool canHitNext = true;
    public delegate void AttackDelegate();
    public static AttackDelegate OnDeadzoneHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeedHorizontal = 0;
        currentSpeedVertical = -speedVertical;
        originPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * currentSpeedVertical);
        transform.Translate(Vector3.right * Time.deltaTime * currentSpeedHorizontal);
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void SetSpeed(float speedHorizontal, float speedVertical)
    {
        currentSpeedHorizontal = speedHorizontal;
        currentSpeedVertical = speedVertical;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WallSide")
        {
            //Debug.Log("Hit Side Wall");
            currentSpeedHorizontal = -currentSpeedHorizontal;
        }
        if(other.tag == "WallTop")
        {
            //Debug.Log("Hit Top Wall");
            currentSpeedVertical = -currentSpeedVertical;
        }
        if(other.tag == "Deadzone")
        {
            //Debug.Log("Hit DeadZone");
            if(isMainAttack)
            {
                OnDeadzoneHit?.Invoke();
                Reset();
            }
            else
            {
                //recycle
                AttackManager.instance.RecycleAttack(this);
            }
        }
        if(other.tag == "Player")
        {
            var collisionPoint = transform.position.x - other.gameObject.transform.position.x;
            //Debug.Log("Hit Player at: " + collisionPoint);
            currentSpeedVertical = -currentSpeedVertical;
            float newSpeed = collisionPoint / 1.25f * modifier;
            currentSpeedHorizontal = speedHorizontal * newSpeed;
            canHitNext = true;
        }
        if(!canHitNext) { return; }
        if(other.tag == "Brick")
        {
            if(other.gameObject.TryGetComponent<Brick>(out Brick brick))
            {
                canHitNext = false;
                //Debug.Log("Hit Brick");
                brick.GetHit();
                currentSpeedVertical = -currentSpeedVertical;
            }
        }
    }

    private void Reset()
    {
        transform.position = originPoint;
        currentSpeedHorizontal = 0;
        currentSpeedVertical = -speedVertical;
    }
}
