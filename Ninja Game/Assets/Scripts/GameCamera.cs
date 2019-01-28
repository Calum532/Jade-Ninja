using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform FollowTarget;
    public Vector3 TargetOffset;
    public float MoveSpeed = 2f;

    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    public void SetTarget(Transform aTransform)
    {
        FollowTarget = aTransform;
    }

    private void LateUpdate()
    {
        if (FollowTarget != null)
            _myTransform.position = Vector3.Lerp(_myTransform.position, FollowTarget.position + TargetOffset, MoveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
