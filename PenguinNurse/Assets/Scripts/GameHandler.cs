using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour{

        public static int playerStat;
        public GameObject scoreText;
        private int playerScore = 0;
        public GameObject timeText;
        public GameObject gameOverText;
        public int gameTime = 60;
        public float gameTimer = 0f;
        //public GameObject textGameObject;

        //void Start () { UpdateScore (); }

        [SerializeField] GameObject pauseMenu;

        public void Pause() {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
        }

        public void Resume() {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
        }

        public void MainMenu() {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
        }

        void Start() {
                pauseMenu.SetActive(false);
                UpdateScore();
                gameOverText.SetActive(false);
                UpdateTime();
        }

        void Update(){         //delete this quit functionality when a Pause Menu is added
                if (Input.GetKey("escape")){
                        // Application.Quit();
                        // QuitGame();
                        Pause();
                }
        }

        public void AddScore(int points){
                playerScore += points;
                UpdateScore();
        }

        void UpdateScore(){
                Text scoreTextB = scoreText.GetComponent<Text>();
                scoreTextB.text = "" + playerScore;
        }

        public void UpdateTime(){
                Text timeTextB = timeText.GetComponent<Text>();
                timeTextB.text = "" + gameTime;
        }

        void FixedUpdate() {
                gameTimer += 0.01f;
                if (gameTimer >= 1f){
                        gameTime -= 1;
                        gameTimer = 0;
                        UpdateTime();
                }
                if (gameTime <= 0){
                        gameTime = 0;
                        gameOverText.SetActive(true);
                }
        }

        // public void UpdatePlayerStat(int amount){
        //         playerStat += amount;
        //         Debug.Log("Current Player Stat = " + playerStat);
        // //      UpdateScore ();
        // }

        // public int CheckPlayerStat(){
        //         return playerStat;
        // }

        //void UpdateScore () {
        //        Text scoreTemp = textGameObject.GetComponent<Text>();
        //        scoreTemp.text = "Score: " + score; }

        // public void StartGame(){
        //         SceneManager.LoadScene("Scene1");
        // }

        // public void OpenCredits(){
        //         SceneManager.LoadScene("Credits");
        // }

        // public void RestartGame(){
        //         SceneManager.LoadScene("MainMenu");
        // }

        // public void QuitGame(){
        //         #if UNITY_EDITOR
        //         UnityEditor.EditorApplication.isPlaying = false;
        //         #else
        //         Application.Quit();
        //         #endif
        // }
}