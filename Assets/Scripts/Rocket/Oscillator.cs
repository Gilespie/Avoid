using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    [SerializeField, Range(0,1)] private float _movementFactor;
    [SerializeField] private float _period = 2f;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    
    private void Update()
    {
        if (_period <= Mathf.Epsilon) return;

        float cycles = Time.time / _period; //continually growing over time
        const float tau = Mathf.PI * 2; //constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); //goint from -1 to 1

        _movementFactor = (rawSinWave + 1f) / 2f; //recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startPosition + offset;
    }
}