using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKArmSolver : MonoBehaviour



{
    // Start is called before the first frame update


    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Rigidbody _body;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void PhysicsMove(Transform _followTarget)
    {
        // Position
        var positionWithOffset = _followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        // Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        //_body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        transform.rotation = _followTarget.rotation * Quaternion.Euler(rotationOffset); ;
    }
}
