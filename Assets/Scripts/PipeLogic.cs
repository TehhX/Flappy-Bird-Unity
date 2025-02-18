using UnityEngine;

public class PipeLogic : MonoBehaviour {
    public const float leftBound = -7.0f;
    public static float speed = 5;
    
    void Update() {
        if (speed == 0)
            return;
            
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftBound)
            Destroy(gameObject);
    }
}