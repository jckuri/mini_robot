using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udacity.GameDevelopment.PlatformerGame.Game_Begin {

    public class ParallaxLayer : MonoBehaviour
    {
        public Transform cameraTransform; // Assign the Virtual Camera here
        public float parallaxMultiplier = 0.5f; // 0.5 for clouds, 0.2 for deep background

        private Vector3 lastCameraPosition;

        void Start()
        {
            lastCameraPosition = cameraTransform.position;
        }

        void Update()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, deltaMovement.y * parallaxMultiplier, 0);
            lastCameraPosition = cameraTransform.position;
        }
    }

}