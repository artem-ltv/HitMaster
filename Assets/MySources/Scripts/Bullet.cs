using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime;

    private IEnumerator _disableBullet;
    private Vector3 _direction;

    private void Update() =>
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);

    private void OnEnable()
    {
        _disableBullet = DisableBullet();
        StartCoroutine(_disableBullet);
    }

    private void OnDisable() =>
        StopCoroutine(_disableBullet);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            enemy.AddDamage(1);

        Die();
    }

    private void OnCollisionEnter(Collision collision) =>
        Die();

    public void SetDirection(Vector3 direction) =>
        _direction = direction;

    private void Die() =>
        gameObject.SetActive(false);

    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(_lifeTime);
        Die();
    }
}
