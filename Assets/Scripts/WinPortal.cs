using UnityEngine;

public class WinPortal : MonoBehaviour
{
    public UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ShowWinScreen();
        }
    }
}