using UnityEngine;

public class PipeMover : MonoBehaviour {
    private void Update() {
        transform.position += Vector3.left * PipeLogic.speed * Time.deltaTime;

        if (transform.position.x < PipeLogic.leftBound)
            Destroy(gameObject);
    }
}
