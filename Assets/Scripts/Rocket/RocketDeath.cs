using UnityEngine;

public class RocketDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] _parties;

    private BoxCollider _collider;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rb;

    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Death()
    {
        _collider.enabled = false;
        _meshRenderer.enabled = false;
        _rb.isKinematic = true;

        for (int i = 0; i < _parties.Length; i++)
        {
            _parties[i].SetActive(true);
        }
    }
}