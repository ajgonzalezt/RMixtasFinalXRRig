using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        private Vector3 target1;
        private Vector3 target2;
        private Vector3 target3;
        

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null && GameManager.Instance.isInSwap)
            {

               
                distanceTravelled += speed * Time.deltaTime;
                Vector3 newPos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                Vector3 oldPos =  transform.position;
                Vector3 camDirTemp =  Camera.main.transform.forward.normalized;
                Vector3 newPosDirTemp = (-oldPos + newPos).normalized;

                transform.position = newPos;


                //   transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos - transform.position), 2f);


                //Quaternion rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                //  transform.rotation = Quaternion.Euler(rot.x, rot.y, 0f);


                
                Vector3 camDir = new Vector3(camDirTemp.x, 0, camDirTemp.z).normalized;
                Vector3 newPosDir = new Vector3(newPosDirTemp.x, 0, newPosDirTemp.z).normalized;


                float yAngle = Vector3.Angle(newPosDir, camDir);
                float yAngle2 = Mathf.Acos(Vector3.Dot(newPosDir, camDir)/ (newPosDir.magnitude * camDir.magnitude));



                target1 = oldPos;
                target2 = camDirTemp;
                target3 = newPosDirTemp;


              
                 


                float dirNum = AngleDir(camDir, newPosDir, transform.up);

                  Debug.Log(dirNum * yAngle);

                //transform.Rotate(0, dirNum * yAngle, 0);
               // Camera.main.transform.LookAt(newPos);





            }
        }


        float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
        {
            Vector3 perp = Vector3.Cross(fwd, targetDir);
            float dir = Vector3.Dot(perp, up);

            if (dir > 0f)
            {
                return 1f;
            }
            else if (dir < 0f)
            {
                return -1f;
            }
            else
            {
                return 0f;
            }
        }



        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}