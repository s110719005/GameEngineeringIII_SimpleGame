using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedHorizontal = 1;
    private float currentSpeedHorizontal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeedHorizontal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            currentSpeedHorizontal = -speedHorizontal;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            currentSpeedHorizontal = speedHorizontal;
        }
        else
        {
            currentSpeedHorizontal = 0;
        }
        transform.Translate(Vector3.right * Time.deltaTime * currentSpeedHorizontal);

        if(transform.position.x >= 6.5f)
        {
            transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -6.5f)
        {
            transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
        }
    }
}
