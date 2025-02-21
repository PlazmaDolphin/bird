using UnityEngine;

public class moveGrass : MonoBehaviour
{
    private bool stopped = false;
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped) return;
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;
        if (transform.position.x < 0) {
            transform.position = transform.position + (Vector3.right * 24);
        }
    }
    public void stop() {
        stopped = true;
    }
}
