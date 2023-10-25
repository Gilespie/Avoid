using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [Header("Speed Movement")]
    [SerializeField] private float _thrusterSpeed = 1000f;
    [SerializeField] private float _rotationSpeed = 100f;

    [Header("FX Engine")]
    [SerializeField] private ParticleSystem _mainEngineFX;
    [SerializeField] private ParticleSystem _rightEngineFX;
    [SerializeField] private ParticleSystem _leftEngineFX;

    [Header("SFX")]
    [SerializeField] private AudioClip _engineSFX;
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop();
        _mainEngineFX.Stop();
    }

    private void StartThrusting()
    {
        _rigidBody.AddRelativeForce(Vector3.up * _thrusterSpeed * Time.deltaTime);

        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_engineSFX, 0.1f);
        }

        if (!_mainEngineFX.isPlaying)
        {
            _mainEngineFX.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-_rotationSpeed);

        if (!_leftEngineFX.isPlaying)
        {
            _leftEngineFX.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(_rotationSpeed);

        if (!_rightEngineFX.isPlaying)
        {
            _rightEngineFX.Play();
        }
    }

    private void StopRotating()
    {
        _rightEngineFX.Stop();
        _leftEngineFX.Stop();
    }

    private void ApplyRotation(float rotationPerFrame)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationPerFrame * Time.deltaTime);
        _rigidBody.freezeRotation = false;
    }
}