using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;

    private float chunkAmmount=3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        for (int i = 0; i < chunkAmmount; i++)
        {
            var chunk = Instantiate(chunkPrefab, transform.position + new Vector3(0,0,i*50), Quaternion.identity);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
