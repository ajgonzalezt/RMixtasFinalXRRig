using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Animation
    // [SerializeField] private float animationSpeed;
    // private Animator _animator;
    // private SkinnedMeshRenderer _mesh;
    // private float _gripTarget;
    // private float _triggerTarget;
    // private float _gripCurrent;
    // private float _triggerCurrent;
    // private const string AnimatorGripParam = "Grip";
    // private const string AnimatorTriggerParam = "Trigger";
    // private static readonly int Grip = Animator.StringToHash(AnimatorGripParam);
    // private static readonly int Trigger = Animator.StringToHash(AnimatorTriggerParam);
    
    // Physics Movement
    [SerializeField] private GameObject followObject;
 
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    public Transform initialPosition;
    private Rigidbody _body;
    public bool isActive;
    private void Start()
    {


        isActive = transform.root.tag == "active";

        // Animation
        // _animator = GetComponent<Animator>();
        // _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        
        // Physics Movement
      
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 0f;
        
        // Teleport hands
      //  _body.position = _followTarget.position;
      //  _body.rotation = _followTarget.rotation;
    }

    private void Update()
    {

        isActive = transform.root.tag == "active";
        // AnimateHand();
        if (isActive)
        {
            PhysicsMove(followObject.transform);
        }
        else {

            transform.position = initialPosition.position;
            transform.rotation = initialPosition.rotation;
        }
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

    // internal void SetGrip(float v)
    // {
    //     _gripTarget = v;
    // }
    //
    // internal void SetTrigger(float v)
    // {
    //     _triggerTarget = v;
    // }

    // private void AnimateHand()
    // {
    //     if (Math.Abs(_gripCurrent - _gripTarget) > 0)
    //     {
    //         _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
    //         _animator.SetFloat(Grip, _gripCurrent);
    //     }
    //
    //     if (!(Math.Abs(_triggerCurrent - _triggerTarget) > 0)) return;
    //     
    //     _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
    //     _animator.SetFloat(Trigger, _triggerCurrent);
    // }
    //
    // public void ToggleVisibility()
    // {
    //     _mesh.enabled = !_mesh.enabled;
    // }

















}