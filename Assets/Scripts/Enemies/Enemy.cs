using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    // [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Flipper))]
    public class Enemy : MonoBehaviour
    {
        protected Rigidbody2D rb;
        protected Flipper flipper;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            flipper = GetComponent<Flipper>();
        }

        // Update is called once per frame
        void Update()
        {
            // ABSTRACTION
            Move();
        }

        public virtual void Move(){
            return;
        }
    }
}
