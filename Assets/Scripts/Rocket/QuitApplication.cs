using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    private void Start()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}