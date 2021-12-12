using UnityEngine;

namespace PathCreation.Examples {
    // Example of creating a path at runtime from a set of points.

    [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour {

        public bool closedLoop = false;
        public Transform[] waypoints;
        public Transform camera;

        void Start () {
            BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
            GetComponent<PathCreator>().bezierPath = bezierPath;

        }

        private void Update()
        {
            if (GameManager.Instance != null && GameManager.Instance.changePathTransition1)
            {
                waypoints[0] = camera;
                waypoints[1] = GameManager.Instance.point1_T1;
                waypoints[2] = GameManager.Instance.point2_T1;
                Debug.LogWarning(waypoints.Length);
                Debug.LogWarning(waypoints[1].transform.position);
                Debug.LogWarning(waypoints[2].transform.position);
                Debug.LogWarning(waypoints);
                Debug.LogWarning("------------------------------------------------------------");

                // waypoints[0].transform.position = new Vector3(waypoints[0].transform.position.x, waypoints[waypoints.Length - 1].transform.position.y, waypoints[0].transform.position.z);
                // Create a new bezier path from the waypoints.
                BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
                GetComponent<PathCreator>().bezierPath = bezierPath;


                GameManager.Instance.changePathTransition1 = false;
            }
            else if (GameManager.Instance != null && GameManager.Instance.changePathTransition2) {

                waypoints[0] = GameManager.Instance.point1_T2;
                waypoints[1] = GameManager.Instance.point2_T2;
                waypoints[2] = GameManager.Instance.point3_T2;
                Debug.LogWarning(waypoints.Length);
                Debug.LogWarning(waypoints[1].transform.position);
                Debug.LogWarning(waypoints[2].transform.position);
                Debug.LogWarning(waypoints);
                Debug.LogWarning("------------------------------------------------------------");

                // waypoints[0].transform.position = new Vector3(waypoints[0].transform.position.x, waypoints[waypoints.Length - 1].transform.position.y, waypoints[0].transform.position.z);
                // Create a new bezier path from the waypoints.
                BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
                GetComponent<PathCreator>().bezierPath = bezierPath;


                GameManager.Instance.changePathTransition2 = false;


            }

           
        }
    }
}