using UnityEngine;
using TMPro;
using System.Collections;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hitMessage;
    [SerializeField] private float _fadeSpeed;
    private int count = -1;

    private void Start()
    {
        _hitMessage.alpha = 0.0f;
    }

    public void UpdateText(int count)
    {
        _hitMessage.text = $"You've bumped into a thing this many times: {count}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Hit"))
        {
            count++;
            UpdateText(count);
            StartCoroutine(FadeRoutine());
        }
    }

    private IEnumerator FadeRoutine()
    {
        _hitMessage.alpha = 1.0f;

        while ( _hitMessage.alpha >= 0.0f )
        {
            Color a = _hitMessage.color;
            a.a -= _fadeSpeed * Time.deltaTime;
            _hitMessage.alpha = a.a;
            yield return null;
        }
    }
}