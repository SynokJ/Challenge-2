using UnityEngine;

public class RPGMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _renderer;

    private bool up, right, down, left;

    void Update()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        Inputs();

        if (left)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            _renderer.sprite = _sprites[0];
            Move(Vector2.left);
        }
        else if (right)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            _renderer.sprite = _sprites[0];
            Move(Vector2.right);
        }

        if (up)
        {
            _renderer.sprite = _sprites[1];
            Move(Vector2.up);
        }
        else if (down)
        {
            _renderer.sprite = _sprites[2];
            Move(Vector2.down);
        }

        //if (!left && !right && !up && !down) _rb.velocity = _rb.velocity.normalized * 0;

        if (_rb.velocity.magnitude >= _maxSpeed)
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
    }

    private void Inputs()
    {
        up = Input.GetKeyDown(KeyCode.W);
        right = Input.GetKeyDown(KeyCode.D);
        down = Input.GetKeyDown(KeyCode.S);
        left = Input.GetKeyDown(KeyCode.A);
    }

    private void Move(Vector2 direction)
    {
        _rb.AddForce(direction * _speed * Time.deltaTime);
    }
}
