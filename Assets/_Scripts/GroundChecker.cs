using UnityEngine;

namespace _Scripts
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float offsetX;

        [SerializeField] private float raycastDistance = 0.6f;
        
        private readonly Vector2 _raycastDirection = -Vector2.up;

        public bool CheckGround()
        {
            return CheckRayHitGround(transform.position) ||
                   CheckRayHitGround(transform.position + new Vector3(offsetX, 0)) ||
                   CheckRayHitGround(transform.position - new Vector3(offsetX, 0));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, raycastDistance, 0));
            Gizmos.DrawLine(transform.position + new Vector3(offsetX, 0), transform.position + new Vector3(offsetX, 0) - new Vector3(0, raycastDistance, 0));
            Gizmos.DrawLine(transform.position - new Vector3(offsetX, 0), transform.position - new Vector3(offsetX, 0) - new Vector3(0, raycastDistance, 0));
        }

        private bool CheckRayHitGround(Vector2 startPoint)
        {
            var raycast = Physics2D.Raycast(startPoint, _raycastDirection, raycastDistance, groundLayer);

            return raycast.collider != null;
        }
    }
}