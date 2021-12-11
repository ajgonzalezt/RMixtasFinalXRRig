using UnityEngine;

namespace PathCreation.Examples {
    // Example of creating a path at runtime from a set of points.

    [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour {

        public bool closedLoop = true;
        public Transform[] waypoints;

        void Start () {

        }

        private void Update()
        {
            if (waypoints.Length > 0 && GameManager.Instance.isInSwap)
            {

                waypoints[1] = GameManager.Instance.point1;
                waypoints[2] = GameManager.Instance.point2;

                // waypoints[0].transform.position = new Vector3(waypoints[0].transform.position.x, waypoints[waypoints.Length - 1].transform.position.y, waypoints[0].transform.position.z);
                // Create a new bezier path from the waypoints.
                BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
                GetComponent<PathCreator>().bezierPath = bezierPath;
            }
        }
    }
}