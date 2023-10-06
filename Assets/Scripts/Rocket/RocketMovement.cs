using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _thrusterSpeed;
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _rigidBody.AddRelativeForce(Vector3.up);
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {

        }
        else if(Input.GetKey(KeyCode.D))
        {

        }
    }
}