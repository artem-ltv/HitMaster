using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shooting : ObjectPool
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _delayShot;
    [SerializeField] private AudioClip _shotSound;

    private AudioSource _shotAudioSource;

    private void Start()
    {
        Initialize(_bullet.gameObject);
        _shotAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        yield return new WaitForSeconds(_delayShot);

        if (TryGetObject(out GameObject bulletObject))
            if (bulletObject.TryGetComponent(out Bullet bullet))
            {
                SetBullet(bullet);
                _shotAudioSource.PlayOneShot(_shotSound);
            }
    }

    private void SetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _shotPoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetDirection(transform.forward);
    }
}
