using UnityEngine;

public class PipeBirth : MonoBehaviour {
    public float maxOffset;
    public float pipeDelay;
    public GameObject pipes;

    private float timer = 0;

    private void Start() {
        newPipes();
    }

    private void Update() {
        if (timer >= pipeDelay) {
            timer = 0f;
            if (PlayerControl.playState == Playstate.playing)
                newPipes();
        }

        else
            timer += Time.deltaTime;
    }
    
    private void newPipes() {
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.position += new Vector3(0, Random.Range(-maxOffset, maxOffset), 0);
    }
}
