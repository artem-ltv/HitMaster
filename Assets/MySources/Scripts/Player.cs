using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _pistol;
    [SerializeField] private CheckerLiveEnemy[] _checkerLiveEnemys;
    [SerializeField] private StopPoint[] _stopPoints;

    private void OnEnable()
    {
        foreach (var checker in _checkerLiveEnemys)
            checker.EnemiesDead += RemovePistol;

        foreach (var stopPoint in _stopPoints)
            stopPoint.Stopping += TakePistol;
    }

    private void OnDisable()
    {
        foreach (var checker in _checkerLiveEnemys)
            checker.EnemiesDead -= RemovePistol;

        foreach (var stopPoint in _stopPoints)
            stopPoint.Stopping -= TakePistol;
    }

    private void TakePistol() =>
        _pistol.SetActive(true);

    private void RemovePistol() =>
        _pistol.SetActive(false);

}
