using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Vector3 rotation = new Vector3(0, _rotationSpeed * Time.deltaTime, 0);

        transform.Rotate(rotation);
    }
}