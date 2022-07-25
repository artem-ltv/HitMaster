using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public event UnityAction Dying;
    public bool IsLive { get => _isLive; } 

    [SerializeField] private int _health;
    [SerializeField] private float _destroyTime;
    [SerializeField] private TextMesh _textHealthPoints;

    private bool _isLive;
    private AudioSource _deathAudioSource;

    private void Start()
    {
        _deathAudioSource = GetComponent<AudioSource>();
        _textHealthPoints.text = _health.ToString();
        _isLive = true;
    }

    public void AddDamage(int damage)
    {
        _health -= damage;
        _textHealthPoints.text = _health.ToString();

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _isLive = false;
        _deathAudioSource.Play();
        Dying?.Invoke();
        _textHealthPoints.gameObject.SetActive(false);
        Destroy(gameObject, _destroyTime);
    }
}