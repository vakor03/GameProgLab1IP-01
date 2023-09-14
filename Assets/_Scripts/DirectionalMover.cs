#region

using UnityEngine;

#endregion

namespace _Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DirectionalMover : MonoBehaviour
    {
        [SerializeField] private InputReceiver inputReceiver;
        [SerializeField] private GroundChecker groundChecker;

        [Header("Movement")]
        [SerializeField] private float speed;

        [SerializeField] private float jumpForce;

        private const float TOLERANCE = 0.001f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            inputReceiver.OnJump += OnJumpInputReceived;
        }

        private void Update()
        {
            float movementX = inputReceiver.GetMovementX();

            Move(movementX);
        }

        private void OnJumpInputReceived()
        {
            if (CanJump())
            {
                Jump();
            }

            bool CanJump()
            {
                return groundChecker.CheckGround()
                    && Mathf.Abs(_rigidbody2D.velocity.y) <= TOLERANCE;
            }
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        private void Move(float movementX)
        {
            _rigidbody2D.velocity = new Vector2(movementX * speed, _rigidbody2D.velocity.y);
        }
    }
}