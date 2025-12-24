using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayButton : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
