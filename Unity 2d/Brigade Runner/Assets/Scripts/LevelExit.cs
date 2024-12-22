using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    
    int currentIndex;
    [SerializeField] private string nextScene; 

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevel());
            Debug.Log("NEXT LEVEL!!");
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
   
}
