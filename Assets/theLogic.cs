using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class theLogic : MonoBehaviour
{
    public int score;
    public Text Text;
    public Text failText;
    public TextMeshProUGUI highscoreTxt;
    public GameObject youSuck;
    public SpawnScript spawner;
    public moveGrass grass;
    public AudioSource scoreSound, music, youStink;
    public ParticleSystem clouds;
    private List<PipeScript> pipes = new();
    public static theLogic Instance { get; private set; }
    private bool dead = false;

    private void Awake() {
        // Singleton pattern to ensure a single instance
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        if (!PlayerPrefs.HasKey("highscore"))
            PlayerPrefs.SetInt("highscore", 0);
        int hs = PlayerPrefs.GetInt("highscore");
        highscoreTxt.SetText("High Score: " + hs.ToString());
    }

    [ContextMenu("Cheat")]
    public void pipeBorn(PipeScript pipe) { 
        pipes.Add(pipe);
    }
    public void pipeDied(PipeScript pipe) {
        pipes.Remove(pipe);
    }
    public void addScore() {
        if (dead) return;
        score++;
        Text.text = "Score: " + score.ToString();
        scoreSound.Play();
    }
    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = false;
    }
    public void fail() {
        int hs = PlayerPrefs.GetInt("highscore");
        if (score >= hs) {
            failText.text = "New Record!";
            PlayerPrefs.SetInt("highscore", score);
        }
        //Check if high score (hooray for you)
        youSuck.SetActive(true);
        music.Stop();
        youStink.Play();
        foreach (PipeScript pipe in pipes) {
            pipe.stop();
        }
        clouds.Pause();
        grass.stop();
        spawner.stop();
        dead = true;
    }
    public void mainMenu() {
        SceneManager.LoadScene(0);
    }
}
