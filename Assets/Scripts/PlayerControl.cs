using UnityEngine;

public enum Playstate {
    playing,
    slowing,
    over
}

public class PlayerControl : MonoBehaviour {
    public TextMesh pointText;
    public static Playstate playState ;
    public PipeLogic pipeLogic;

    private int points;
    private Rigidbody2D rb;
    private float force = 9.25f;

    private void Start() {
        pipeLogic = GameObject.Find("PipeLogic").GetComponent<PipeLogic>();
        playState = Playstate.playing;
        points = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (playState == Playstate.playing && Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocityY = force;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        const float bounceForce = 6f;

        string parentName = collision.gameObject.transform.parent.name;
        string childName = collision.collider.name;

        if (childName == "VertCollider") {
            if (parentName == "Higher")
                rb.linearVelocity = new Vector2(bounceForce / 2, -bounceForce / 4);

            else if (parentName == "Lower")
                rb.linearVelocity = new Vector2(bounceForce / 2, bounceForce);

            else
                throw new UnityException("Unknown collider hit.");
        }
        
        else if (childName == "LeftCollider")
            rb.linearVelocity = new Vector2(-bounceForce, bounceForce / 2);

        else
            throw new UnityException("Unknown collider hit.");

        removeControl();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "PointTrigger")
            incrementPoints();

        else if (collision.name == "Floor")
            removeControl();
    }

    private void removeControl() {
        playState = Playstate.slowing;
        pipeLogic.enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    public void incrementPoints() {
        ++points;
        pointText.text = points + "";
    }
}