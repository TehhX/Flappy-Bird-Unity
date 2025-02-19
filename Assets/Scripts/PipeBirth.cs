using UnityEngine;

public class PipeBirth : MonoBehaviour {
    public float pipeDelay = 0.3f;
    public GameObject pipes;

    private float maxOffset = 3.4f;
    private float timer = 0f;

    private void Update() {
        if (timer >= pipeDelay)
            newPipes();

        else
            timer += Time.deltaTime;
    }
    
    public void newPipes() {
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.position += new Vector3(0, Random.Range(-maxOffset, maxOffset), 0);
        timer = 0f;
    }
}
