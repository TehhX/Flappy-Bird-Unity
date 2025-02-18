using UnityEngine;

public class PipeBirth : MonoBehaviour
{
    public float maxOffset;
    public float pipeDelay;
    private float timer = 0;
    public GameObject pipes;
    void Start() {
        newPipes();
    }
    void Update() {
        timer += Time.deltaTime;

        if (timer >= pipeDelay && PlayerControl.active) {
            newPipes();
            timer = 0;
        }
    }
    
    private void newPipes() {
        GameObject newPipes = Instantiate(pipes);
        newPipes.transform.position += new Vector3(0, Random.Range(-maxOffset, maxOffset), 0);
    }
}
