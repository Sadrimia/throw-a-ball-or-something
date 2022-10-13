using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDeleter : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D _binCollider;

    private void OnTriggerEnter2D(Collider2D other) {
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<CircleCollider2D>(), _binCollider, true);
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<CircleCollider2D>(), _binCollider, false);

    }

}
