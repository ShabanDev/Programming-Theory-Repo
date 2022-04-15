using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    // INHERITANCE
    public class PathFollowingEnemy : Enemy
    {
        public MovementPath path;

        // POLYMORPHISM
        public override void Move()
        {
            if(path != null){
                Vector3 newPosition = path.GetPostion(transform.position);

                float direction = newPosition.x - transform.position.x;

                if(direction >= 0.02f) {
                    flipper.Unflip();
                }
                else if(direction <= -0.02f){
                    flipper.Flip();
                }

                rb.MovePosition(newPosition);
            }
        }
    }
}
