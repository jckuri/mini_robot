using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Udacity.GameDevelopment.PlatformerGame.Game_Begin {

    public class FireMovement : MonoBehaviour {

        [SerializeField] public Rigidbody2D rb;

        void Awake() {
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        void Start() {     
        }

        // Update is called once per frame
        void Update() {
        }

        void OnTriggerEnter2D(Collider2D other) { 
            string tag = other.gameObject.tag;
            if(tag == "Player") {
                Game.instance.GameOver();
            }
        }

    }

}