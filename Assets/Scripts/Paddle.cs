using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected new Rigidbody2D rigidbody; 
    public float speed = 10.0f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition() {
        rigidbody.position = new Vector2(rigidbody.position.x, 0.0f);
        rigidbody.velocity = Vector2.zero;
    }
}
