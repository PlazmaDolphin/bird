using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    private float dHeight = 7F;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        makePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate){
            timer -= spawnRate;
            makePipe();
        }
        timer += Time.deltaTime;
    }
    void makePipe(){
        float ypos = transform.position.y + 1F;
        //Instantiate(pipe, new Vector3(transform.position.x+20, Random.Range(ypos-dHeight, ypos+dHeight)), transform.rotation);
        Instantiate(pipe, new Vector3(transform.position.x + 20, ypos+ Random.Range(-dHeight, dHeight)), transform.rotation);
    }
    public void stop() {
        Destroy(gameObject);
    }
}
