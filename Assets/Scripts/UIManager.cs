using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject startScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (winScreen != null)
        //    winScreen.SetActive(false);

        //if (loseScreen != null)
        //    loseScreen.SetActive(false);

        if (startScreen != null)
            startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        if(startScreen != null)
        {
            startScreen.SetActive(false);
        }
    }

    //public void WinScreen()
    //{
    //    if (winScreen != null)
    //    {
    //        winScreen.SetActive(true);
    //    }
    //}

    //public void LoseScreen()
    //{
    //    if (loseScreen != null)
    //    {
    //        loseScreen.SetActive(true);
    //    }
    //}
}
