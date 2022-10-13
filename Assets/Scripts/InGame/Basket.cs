using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _winTrigger;

    private void OnTriggerExit2D(Collider2D other) {
        _winTrigger.enabled = true;
    }
}
