using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedHorizontal = 1;
    [SerializeField] private TextMeshProUGUI abilityText;
    private float currentSpeedHorizontal;
    private bool canMagnify = true;
    private Coroutine playerMagnifyCoroutine;
    private Vector3 originSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeedHorizontal = 0;
        originSize = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)  && canMagnify)
        {
            playerMagnifyCoroutine = StartCoroutine(PlayerMaginify());
        }
        
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

        if(transform.position.x >= 6.25f)
        {
            transform.position = new Vector3(6.25f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -6.25f)
        {
            transform.position = new Vector3(-6.25f, transform.position.y, transform.position.z);
        }
    }

    private IEnumerator PlayerMaginify()
    {
        canMagnify = false;
        abilityText.color = new Color(abilityText.color.r, abilityText.color.g, abilityText.color.b, 0.2f);
        for(int i = 0; i < 100; i++)
        {
            gameObject.transform.localScale += new Vector3(0.25f / 5, 0.03f / 5,0);
            yield return new WaitForSeconds(0.01f);
        }
        //cooldown
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < 100; i++)
        {
            gameObject.transform.localScale -= new Vector3(0.25f / 5, 0.03f / 5,0);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.transform.localScale = originSize;
        yield return new WaitForSeconds(3f);
        abilityText.color = new Color(abilityText.color.r, abilityText.color.g, abilityText.color.b, 1f);
        canMagnify = true;
        yield return null;
    }
}
