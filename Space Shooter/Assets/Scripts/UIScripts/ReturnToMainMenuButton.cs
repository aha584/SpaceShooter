using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButton : MonoBehaviour
{
    public void OnReturnButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
