using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Flipper : MonoBehaviour
    {
        public void Flip(){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        public void Unflip(){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
