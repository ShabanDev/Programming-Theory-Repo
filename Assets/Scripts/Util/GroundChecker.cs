using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GroundChecker : MonoBehaviour
    {
        // ENCAPSULATION
        public bool IsGrounded {get; set;}

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other) {
            IsGrounded = true;
        }

        private void OnTriggerExit2D(Collider2D other) {
            IsGrounded = false;
        }
    }
}
