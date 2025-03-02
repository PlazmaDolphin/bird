using UnityEngine;

public class speed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //On Shift key held, slow down time
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.5f;
            speedChangeAudio();
        }
        else if (Input.GetKey(KeyCode.LeftControl)){
            Time.timeScale = 2f;
            speedChangeAudio();
        }
        else
        {
            Time.timeScale = 1f;
            speedChangeAudio();
        }

    }

    void speedChangeAudio(){
        var aSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None); 
        foreach (AudioSource aSource in aSources)
            aSource.pitch = Time.timeScale;
    }
}
