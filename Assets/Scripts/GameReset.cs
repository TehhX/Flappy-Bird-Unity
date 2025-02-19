using UnityEngine;

public class GameReset : MonoBehaviour {
    private PipeBirth pipeBirth;
    public GameObject playerAsset;
    private GameObject playerObject;

    private void Start() {
        pipeBirth = GameObject.Find("PipeBirth").GetComponent<PipeBirth>();
        enabled = false;
        gameReset();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
            gameReset();
    }

    public void gameOver() {
        PlayerControl.playState = Playstate.over;
        Destroy(playerObject);
        PipeLogic.speed = 0;
        enabled = true;
        pipeBirth.enabled = false;
    }

    public void gameReset() {
        enabled = false;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
            Destroy(pipe);

        PipeLogic.speed = PipeLogic.startingSpeed;

        pipeBirth.newPipes();
        pipeBirth.enabled = true;

        playerObject = Instantiate(playerAsset);
    }
}
