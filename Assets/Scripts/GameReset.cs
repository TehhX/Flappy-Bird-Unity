using UnityEngine;

public class GameReset : MonoBehaviour {
    private PipeBirth pipeBirth;
    public GameObject player;

    private void Start() {
        pipeBirth = GameObject.Find("PipeBirth").GetComponent<PipeBirth>();
        enabled = false;
    }

    private void Update() {
        Debug.Log("GameResetUpdate");

        if (Input.GetKeyDown(KeyCode.Tab))
            gameReset();
    }

    public void gameOver() {
        Debug.Log("GameReset/GameOver");

        PlayerControl.playState = Playstate.over;
        Destroy(player);
        PipeLogic.speed = 0;
        enabled = true;
        pipeBirth.enabled = false;
    }

    public void gameReset() {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
            Destroy(pipe);

        PipeLogic.speed = PipeLogic.startingSpeed;
        
        Instantiate(player);
        player.GetComponent<PlayerControl>().incrementPoints();
    }
}
