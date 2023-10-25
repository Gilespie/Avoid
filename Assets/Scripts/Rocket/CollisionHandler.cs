using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Header("Delays")]
    [SerializeField] private float _restartLevelDelay = 3f;
    [SerializeField] private float _nextLevelDelay = 1f;
    [Header("Explosive")]
    [SerializeField] private AudioClip _explosiveSFX;
    [SerializeField] private ParticleSystem _explosiveFX;
    [Header("Success")]
    [SerializeField] private AudioClip _successSFX;
    [SerializeField] private ParticleSystem _successFX;

    private AudioSource _audioSource;
    private bool isTransitioning = false;
    private bool isCollisionDisabled = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            isCollisionDisabled = !isCollisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || isCollisionDisabled) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":

                break;

            case "Finish":
                StartSuccessSequence();
                break;

            case "Fuel":

                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;
        _successFX.Play();
        _audioSource.Stop();
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(_successSFX);
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextLevel", _nextLevelDelay);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        _explosiveFX.Play();
        _audioSource.Stop();
        _audioSource.PlayOneShot(_explosiveSFX);
        GetComponent<RocketMovement>().enabled = false;
        GetComponent<RocketDeath>().Death();
        Invoke("ReloadLevel", _restartLevelDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;
        
        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextLevelIndex = 1;
        }

        SceneManager.LoadScene(nextLevelIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}