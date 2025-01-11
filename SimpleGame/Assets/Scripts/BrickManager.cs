using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private float startPointX = -7.25f;
    [SerializeField] private float startPointY = 0.3f;
    [SerializeField] private int column = 15;
    [SerializeField] private int row = 6;
    [SerializeField] private Color[] brickColors;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0 ; i < row ; i++)
        {
            for(int j = 0 ; j < column ; j++)
            {
                GameObject brickGameObject = Instantiate(brickPrefab, new Vector3(startPointX + 1 * j, startPointY + 0.3f * i, transform.position.z), Quaternion.identity, transform);
                Brick brick = brickGameObject.AddComponent<Brick>();
                MeshRenderer meshRenderer = brickGameObject.GetComponent<MeshRenderer>();
                brick.SetScore(i + 1);
                if(meshRenderer != null)
                {
                    meshRenderer.material.color = brickColors[i];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
