using UnityEngine;

public class PipeLogic : MonoBehaviour {
    public static float speed = 5;
    public const float leftBound = -7.0f;
    void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftBound)
            Destroy(gameObject);
    }
}