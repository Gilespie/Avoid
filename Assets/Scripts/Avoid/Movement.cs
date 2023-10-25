using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _hitCount = 0;

    private void Update()
    {
        MovementInput();   
    }

    private void MovementInput()
    {
        float inputX = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        float inputY = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

        Vector3 direction = new Vector3(inputX, 0, inputY);

        transform.Translate(direction);
    }
}