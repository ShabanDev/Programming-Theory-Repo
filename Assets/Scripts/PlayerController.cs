using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Flipper))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D playerRB;
        private SpriteRenderer spriteRenderer;
        private Animator playerAnim;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float jumpForce;
        [SerializeField]
        private GroundChecker groundChecker;
        [SerializeField]
        private Transform bulletHolder;
        [SerializeField]
        private Transform bulletEmittor;
        [SerializeField]
        private GameObject bulletPrefab;

        private float horizontal = 0;

        private int walkingAnimHash;
        private int firingAnimHash;

        private bool isFiring = false;
        private bool isMoving = false;
        private Flipper flipper;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerAnim = GetComponent<Animator>();
            flipper = GetComponent<Flipper>();

            walkingAnimHash = Animator.StringToHash("isWalking");
            firingAnimHash = Animator.StringToHash("isFiring");
        }

        private void Update()
        {
            // flip sprite in direction of movement
            bool playWalkingAnimation = false;
            if(!isFiring) {
                if(playerRB.velocity.x < 0){
                    flipper.Flip();
                    playWalkingAnimation = true;
                }
                else if(playerRB.velocity.x > 0){
                    flipper.Unflip();
                    playWalkingAnimation = true;
                }
            }

            if(playerRB.velocity.y == 0){
                groundChecker.IsGrounded = true;
            }
            
            playerAnim.SetBool(walkingAnimHash, playWalkingAnimation && isMoving);
        }

        private void FixedUpdate() {
            playerRB.velocity = new Vector2(horizontal * speed, playerRB.velocity.y);
        }

        public void HandleJumpInput(InputAction.CallbackContext callbackContext){
            if(callbackContext.started){
                if(groundChecker.IsGrounded){
                    playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        public void HandleMoveInput(InputAction.CallbackContext callbackContext){
            if(!isFiring) {
                horizontal = callbackContext.ReadValue<Vector2>().x;
            }

            if(callbackContext.started){
                isMoving = true;
            }
            else if(callbackContext.canceled){
                isMoving = false;
            }
        }

        public void HandleFireInput(InputAction.CallbackContext callbackContext){
            if(callbackContext.started){
                isFiring = true;
                horizontal = 0;
            }
            else if(callbackContext.canceled) {
                isFiring = false;
            }

            playerAnim.SetBool(firingAnimHash, isFiring);
        }

        public void Fire(){
            Bullet bullet = GameObject.Instantiate(bulletPrefab, bulletEmittor.position, bulletPrefab.transform.rotation, bulletHolder).GetComponent<Bullet>();
            if(transform.localScale.x > 0){
                bullet.SetDirection(Vector2.right);
            }
            else {
                bullet.SetDirection(Vector2.left);
            }
        }
    }

}