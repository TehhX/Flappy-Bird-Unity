using UnityEngine;

public enum Playstate {
    playing,
    slowing,
    startOver,
    endOver
}

public class PlayerControl : MonoBehaviour {
    public static Playstate playState = Playstate.playing;

    private Rigidbody2D rb;
    private float force = 9.25f;
    private float speedDecrement = PipeLogic.speed * 0.005f;
    private float speedTimer = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (playState == Playstate.playing && Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocityY = force;
        
        else if (playState == Playstate.slowing)
            slowDown();
        
        else if (playState == Playstate.startOver)
            gameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        const float bounceForce = 10f;

        string parentName = collision.gameObject.transform.parent.name;
        string childName = collision.collider.name;
        
        if (parentName == "Upper" && childName == "VertCollider")
            rb.linearVelocity = new Vector2(bounceForce, -bounceForce);

        else if (parentName == "Lower" && childName == "VertCollider")
            rb.linearVelocity = new Vector2(bounceForce, bounceForce);

        else if (childName == "LeftCollider")
            rb.linearVelocity = new Vector2(-bounceForce, bounceForce);

        else
            return;

        playState = Playstate.slowing;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void slowDown() {
        if (speedTimer > 0.12f) {
            if (PipeLogic.speed > 0.01f)
                PipeLogic.speed -= speedDecrement;

            else {
                PipeLogic.speed = 0.0f;
                playState = Playstate.endOver;
            }
        }

        else
            speedTimer += Time.deltaTime;
    }

    private void gameOver() {
        
    }
}