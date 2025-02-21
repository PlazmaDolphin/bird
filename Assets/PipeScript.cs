using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed = 10;
    private float dieHere = -30;
    private bool moving = true;

    private void OnEnable() {
        if (theLogic.Instance  != null) {
            theLogic.Instance.pipeBorn(this);
        }
    }
    private void OnDisable() {
        if (theLogic.Instance != null) {
            theLogic.Instance.pipeBorn(this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            transform.position = transform.position + (Vector3.left* speed) * Time.deltaTime;
        if (transform.position.x < dieHere) {
            Destroy(gameObject);
        }
    }
    public void stop() {
        moving = false;
    }
}
