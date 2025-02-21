using TMPro;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flap = 20;
    public theLogic logic;
    private bool alive=true;
    private bool jump=false, jumped=false, firstJump=true;
    public AudioSource sfxJump, music;
    public TextMeshProUGUI tutorial;
    public SpawnScript pipes;
    private float g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<theLogic>();
        g = this.GetComponent<Rigidbody2D>().gravityScale;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        //Fixes lag spike on first jump
        music.enabled = true;
        music.time = 36;
        music.Play();
        music.Pause();
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        jumped = false;
        if (jump && alive)
        {
            rb.linearVelocity = Vector2.up * flap;
            jump=false;
            jumped = true;
            sfxJump.Play();
            this.GetComponent<Rigidbody2D>().gravityScale = g;
            if (firstJump){
                tutorial.enabled = false;
                music.Play();
                firstJump = false;
                pipes.enabled = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!alive || jumped || rb.linearVelocityY == flap){
            return; //Don't retrigger this
        }
        alive = false;
        logic.fail();
        rb.linearVelocity = rb.linearVelocity + Vector2.right * 10;
    }
}
