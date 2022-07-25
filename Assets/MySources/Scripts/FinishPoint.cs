using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Animation _whiteDisplay;
    [SerializeField] private float _delayRestartScene;

    private AudioSource _finishAudioSource;

    private void Start() =>
        _finishAudioSource = GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _whiteDisplay.Play();
            _finishAudioSource.Play();
            StartCoroutine(RestartScene());
        }
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(_delayRestartScene);
        SceneManager.LoadScene(0);
    }
}
