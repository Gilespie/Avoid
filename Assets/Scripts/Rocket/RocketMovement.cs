using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _thrusterSpeed = 1000f;
    [SerializeField] private float _rotationSpeed = 100f;
    private Rigidbody _rigidBody;
    private AudioSource _rocketBoostSFX;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rocketBoostSFX = GetComponent<AudioSource>();
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
            _rigidBody.AddRelativeForce(Vector3.up * _thrusterSpeed * Time.deltaTime);

            if(!_rocketBoostSFX.isPlaying)
            {
                _rocketBoostSFX.Play();
            }
        }
        else
        {
            _rocketBoostSFX.Stop();
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationPerFrame)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationPerFrame * Time.deltaTime);
        _rigidBody.freezeRotation = false;
    }
}