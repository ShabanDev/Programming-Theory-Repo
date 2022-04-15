using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector2 dir = Vector2.zero;
        [SerializeField]
        private float speed = 20;
        [SerializeField]
        private float timeToLive = 10;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = dir * speed;
            StartCoroutine(DestroyAfterSeconds(timeToLive));
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Enemy")) {
                Destroy(other.gameObject);
            }
            
            StartCoroutine(DestroyAtEndOfFrame());
        }

        private IEnumerator DestroyAfterSeconds(float seconds){
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }

        private IEnumerator DestroyAtEndOfFrame(){
            yield return new WaitForFixedUpdate();
            Destroy(gameObject);
        }

        public void SetDirection(Vector2 direction){
            dir = direction;
        }

    }
}
