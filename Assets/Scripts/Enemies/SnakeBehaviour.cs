using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class SnakeBehaviour : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] bool canMove = true;


        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update() {
            if (pathCreator != null) {
                distanceTravelled += speed * Time.deltaTime;
                // transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                // rb.velocity = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                rb.MovePosition(pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction)); 
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                print(rb.velocity);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject != this.gameObject)
            {
                speed*= -1;
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            print($"caminho mudou");
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}