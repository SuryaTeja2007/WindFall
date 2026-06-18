using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winScreen.SetActive(true);

            // Optional: stop the game
            Time.timeScale = 0f;
        }
    }
}