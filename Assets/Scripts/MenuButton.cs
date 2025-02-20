using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
    private void Start() {
        enabled = false;
    }

    public void toGameplay() {
        SceneManager.LoadScene("MainMenu");
    }
}
