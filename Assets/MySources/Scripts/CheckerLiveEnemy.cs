using UnityEngine;
using UnityEngine.Events;

public class CheckerLiveEnemy : MonoBehaviour
{
    public event UnityAction EnemiesDead; 

    [SerializeField] private Enemy[] _enemyes;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnEnable()
    {
        foreach (var enemy in _enemyes)
            enemy.Dying += CheckLiveEnemy;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemyes)
            enemy.Dying -= CheckLiveEnemy;
    }

    private void CheckLiveEnemy()
    {
        if (!IsLiveEnemies())
        {
            _playerMovement.SwitchPoseAiming(false);
            EnemiesDead?.Invoke();
        }
    }

    private bool IsLiveEnemies()
    {
        foreach (var enemy in _enemyes)
            if (enemy.IsLive == true)
                return true;


        return false;
    }
}
