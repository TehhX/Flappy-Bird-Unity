using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private float force = 9.25f;
    public static bool active = true;
    private float initialSpeed = PipeLogic.speed;
    private float speedTimer = 0;
    void Update() {
        if (active) {
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<Rigidbody2D>().linearVelocityY = force;
        }
        
        else if (PipeLogic.speed > 0) {
            if (speedTimer > 0.05f) {
                PipeLogic.speed -= initialSpeed * 0.05f;
                speedTimer = 0.0f;
            }
            
            else {
                speedTimer += Time.deltaTime;
            }
        }
        
        else
            gameOver();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!active)
            return;

        if (collision.gameObject.tag == "Pipe")
            active = false;
    }

    private void gameOver() {

    }
}
