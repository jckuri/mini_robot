using Udacity.GameDevelopment.Shared; //KEEP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Udacity.GameDevelopment.PlatformerGame.Game_Begin {
    /// <summary>
    /// This is the main entry point to the game.
    /// </summary>

    public class Game : MonoBehaviour {

        //  Properties ------------------------------------

        //  Fields ----------------------------------------
        
        public static Game instance;
        public CoinManager coinManager;
        public SpriteRenderer woodsBackground;
        public SpriteRenderer cloudsBackground;
        public AudioSource coinAudioSource, deathAudioSource, jumpAudioSource, landingAudioSource, winningAudioSource;
        public AudioClip coinSound, deathSound, jumpSound, landingSound, winningSound;
        [SerializeField] public PlayerMovement player;
        public Text messages;
        private System.DateTime? deathTime = null;

        //  Unity Methods ---------------------------------

        public void Awake() {
            if(instance == null) instance = this;
            Time.timeScale = 2;

            coinAudioSource = gameObject.AddComponent<AudioSource>();
            deathAudioSource = gameObject.AddComponent<AudioSource>();
            jumpAudioSource = gameObject.AddComponent<AudioSource>();
            landingAudioSource = gameObject.AddComponent<AudioSource>();
            winningAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            if(deathTime != null) {
                if((getTime() - deathTime.Value).TotalMilliseconds > 2000) {
                    deathTime = null;
                    RestartGame();
                }
            }
        }

        //  Event Handlers --------------------------------

        //  Methods ---------------------------------------

        System.DateTime getTime() {
            return System.DateTime.UtcNow;
        }

        public void changeMessage(string message) {
            messages.text = message;
        }

        public void playCoin() {
            changeMessage("");
            coinAudioSource.clip = coinSound;
            coinAudioSource.Play();        
        }

        public void playDeath() {
            deathAudioSource.clip = deathSound;
            deathAudioSource.Play();
        }

        public void playJump() {
            jumpAudioSource.clip = jumpSound;
            jumpAudioSource.Play();
        }

        public void playLanding() {
            landingAudioSource.clip = landingSound;
            landingAudioSource.Play();
        }

        public void playWinning() {
            winningAudioSource.clip = winningSound;
            winningAudioSource.Play();
        }

        public void GameOver() {
            deathTime = getTime();
            player.setDeath(true);
            Game.instance.playDeath();
            changeMessage("GAME OVER");
            Time.timeScale = 0f;
        }

        public void Win() {
            player.setHasWon(true);
            Game.instance.playWinning();
            changeMessage("YOU WIN!");
            Time.timeScale = 0f;
        }

        public void RestartGame() {
            SceneManager.LoadScene("Game_Begin");        
            Time.timeScale = 2;
        }

    }

}