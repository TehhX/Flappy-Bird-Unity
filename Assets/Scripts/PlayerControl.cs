using System;
using UnityEngine;

public enum Playstate {
    playing,
    slowing,
    over
}

public class PlayerControl : MonoBehaviour {
    private TextMesh pointText;
    private PipeLogic pipeLogic;
    private CircleCollider2D cc2d;
    public static Playstate playState;
    
    private int points;
    private Rigidbody2D rb;
    private float force = 13f;

    private void Start() {
        cc2d = GetComponent<CircleCollider2D>();
        pipeLogic = GameObject.Find("PipeLogic").GetComponent<PipeLogic>();
        pointText = GameObject.Find("PointText").GetComponent<TextMesh>();
        playState = Playstate.playing;
        points = -1;
        rb = GetComponent<Rigidbody2D>();
        incrementPoints();
    }

    private void Update() {
        if (playState == Playstate.playing && Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocityY = force;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        const float bounceForce = 7f;

        string parentName;
        try {
            parentName = collision.gameObject.transform.parent.name;
        } catch (NullReferenceException) {
            parentName = "NoParent";
        }
        
        string childName = collision.collider.name;

        if (childName == "Ceiling")
            return;

        else if (childName == "LeftCollider")
            rb.linearVelocity = new Vector2(-bounceForce * 3f, bounceForce);

        else if (parentName == "Higher") {
            if (childName == "VertCollider")
                rb.linearVelocity = new Vector2(0, -bounceForce / 2f);

            else if (childName == "CornerCollider")
                rb.linearVelocity = new Vector2(-bounceForce * 2f, -bounceForce / 2f);
        }

        else if (parentName == "Lower") {
            if (childName == "VertCollider")
                rb.linearVelocity = new Vector2(0, bounceForce);

            else if (childName == "CornerCollider")
                rb.linearVelocity = new Vector2(-bounceForce * 2f, bounceForce / 2f);
        }

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
        cc2d.enabled = false;
    }

    public void incrementPoints() {
        ++points;
        pointText.text = points + "";
    }
}