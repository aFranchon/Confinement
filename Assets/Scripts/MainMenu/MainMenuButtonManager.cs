using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public void onPlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
