using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float speedVertical = 1;
    [SerializeField] private float speedHorizontal = 1;
    [SerializeField] private float modifier = 2;
    private float currentSpeedVertical;
    private float currentSpeedHorizontal;
    private Vector3 originPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeedHorizontal = 0;
        currentSpeedVertical = -1;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WallSide")
        {
            Debug.Log("Hit Side Wall");
            currentSpeedHorizontal = -currentSpeedHorizontal;
        }
        if(other.tag == "WallTop")
        {
            Debug.Log("Hit Top Wall");
            currentSpeedVertical = -currentSpeedVertical;
        }
        if(other.tag == "DeadZone")
        {
            Debug.Log("Hit DeadZone");
            Reset();
        }
        if(other.tag == "Player")
        {
            var collisionPoint = transform.position.x - other.gameObject.transform.position.x;
            Debug.Log("Hit Player at: " + collisionPoint);
            //currentSpeedHorizontal = -currentSpeedHorizontal;
            currentSpeedVertical = -currentSpeedVertical;
            float newSpeed = collisionPoint / 1.25f * modifier;
            //currentSpeedHorizontal = (currentSpeedHorizontal >= 0 ? speedHorizontal : -speedHorizontal) * newSpeed;
            currentSpeedHorizontal = speedHorizontal * newSpeed;
        }
    }

    private void Reset()
    {
        transform.position = originPoint;
        currentSpeedHorizontal = 0;
        currentSpeedVertical = -1;
    }
}
