using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class MovementPath : MonoBehaviour
    {
        public Vector3 start;
        public Vector3 end;
        public float speed = 1;
        private float distance;
        private float startTime;

        private void Start() {
            distance = (start - end).magnitude;
            startTime = Time.time;
        }

        public Vector3 GetPostion(Vector3 currentPosition){
            return Vector3.Lerp(start, end, Mathf.PingPong((Time.time - startTime) * speed, 1));
        }
    }
}
