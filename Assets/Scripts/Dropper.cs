using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float _secondsWait;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Time.time > _secondsWait)
        {
            _meshRenderer.enabled = true;
            _rigidbody.isKinematic = false;
        }
    }
}