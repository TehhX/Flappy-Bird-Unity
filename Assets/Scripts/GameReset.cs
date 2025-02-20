using UnityEngine;

public class GameReset : MonoBehaviour {
    private PipeBirth pipeBirth;

    public GameObject playerAsset;
    private GameObject playerObject;

    public GameObject gameOverTextPrefab;
    private GameObject gameOverTextObject;

    private void Start() {
        pipeBirth = GameObject.Find("PipeBirth").GetComponent<PipeBirth>();
        enabled = false;
        gameReset();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
            gameReset();
        
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(0);
            
    }

    public void gameOver() {
        PlayerControl.playState = Playstate.over;

        int currentPoints = playerObject.GetComponent<PlayerControl>().points;
        if (currentPoints > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", currentPoints);
            
        Destroy(playerObject);
        PipeLogic.speed = 0;
        enabled = true;
        pipeBirth.enabled = false;
        gameOverTextObject = Instantiate(gameOverTextPrefab);
        gameOverTextObject.GetComponent<TextMesh>().text = "Game Over.\nPress TAB to retry, ESC to quit.\nHighscore: " + PlayerPrefs.GetInt("highscore");
    }

    public void gameReset() {
        enabled = false;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
            Destroy(pipe);

        PipeLogic.speed = PipeLogic.startingSpeed;

        pipeBirth.newPipes();
        pipeBirth.enabled = true;

        Destroy(gameOverTextObject);
        playerObject = Instantiate(playerAsset);
    }
}
