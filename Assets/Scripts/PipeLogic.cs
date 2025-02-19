using UnityEngine;

public class PipeLogic : MonoBehaviour {
    public GameObject gameReset;

    public const float startingSpeed = 8.5f;

    public const float leftBound = -7.0f;
    public static float speed = startingSpeed;
    private float speedDecrement = speed * 0.5f;
    private float speedTimer = 0;

    private void Start() {
        enabled = false;
    }

    private void Update() {
        slowDown();
    }

    private void slowDown() {
        if (speedTimer > 0.12f) {
            if (speed > 0.01f)
                speed -= speedDecrement * Time.deltaTime;

            else {
                enabled = false;
                gameReset.GetComponent<GameReset>().gameOver();
            }
        }

        else
            speedTimer += Time.deltaTime;
    }
}