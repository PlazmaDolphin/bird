using UnityEngine;
using UnityEngine.SceneManagement;
public class theMenu : MonoBehaviour
{
    public void startgame() {
        SceneManager.LoadScene(1);
    }
    public void endgame() {
        Application.Quit();
    }
    public void resetScore() {
        PlayerPrefs.SetInt("highscore", 0);
    }
}
