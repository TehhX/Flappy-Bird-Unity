using UnityEngine;
using UnityEngine.SceneManagement;

public enum Playstate {
    playing,
    slowing,
    over
}

public class PlayerControl : MonoBehaviour {
    public TextMesh gameOverText;
    public static Playstate playState = Playstate.playing;

    private Rigidbody2D rb;
    private float force = 9.25f;
    private float speedDecrement = PipeLogic.speed * 0.5f;
    private float speedTimer = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Debug.Log("PlayerUpdate");

        if (playState == Playstate.playing && Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocityY = force;
        
        else if (playState == Playstate.slowing)
            slowDown();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        const float bounceForce = 6f;

        string parentName = collision.gameObject.transform.parent.name;
        string childName = collision.collider.name;
        
        if (parentName == "Higher" && childName == "VertCollider") {
            rb.linearVelocity = new Vector2(bounceForce / 2, -bounceForce / 4);
            removeControl();
        }

        else if (parentName == "Lower" && childName == "VertCollider") {
            rb.linearVelocity = new Vector2(bounceForce / 2, bounceForce);
            removeControl();
        }

        else if (childName == "LeftCollider") {
            rb.linearVelocity = new Vector2(-bounceForce, bounceForce / 2);
            removeControl();
        }
    }

    private void removeControl() {
        playState = Playstate.slowing;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void slowDown() {
        if (speedTimer > 0.12f) {
            if (PipeLogic.speed > 0.01f)
                PipeLogic.speed -= speedDecrement * Time.deltaTime;

            else {
                PipeLogic.speed = 0;
                playState = Playstate.over;
                gameOver();
            }
        }

        else
            speedTimer += Time.deltaTime;
    }

    private void gameOver() {
        Instantiate(gameOverText);
        Destroy(gameObject);
    }
}