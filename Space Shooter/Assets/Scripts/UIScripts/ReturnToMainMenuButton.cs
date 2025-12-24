using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButton : MonoBehaviour
{
    public void onReturnButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
