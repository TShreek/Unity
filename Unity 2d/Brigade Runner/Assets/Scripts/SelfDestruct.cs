using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float delay = 5f;  // Delay before hiding the text

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to hide the text after a delay
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Hide the text
        Destroy(gameObject);
    }
}