using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _baseOffset;
    [SerializeField] private float _stepRate;

    private void Start()
    {
        _target = FindObjectOfType<Movement>().transform;
    }

    private void LateUpdate()
    { 
        FollowToTarget(_target.position);
        LookToTarget(_target);
    }

    private void FollowToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target + _baseOffset, _stepRate * Time.deltaTime);
    }

    private void LookToTarget(Transform target)
    {
        transform.LookAt(target);
    }
}