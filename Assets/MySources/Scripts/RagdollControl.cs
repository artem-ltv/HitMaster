using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _bones;

    private Animator _enemyAnimator;
    private Enemy _enemy;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        SetKinematic(true);
    }

    private void OnEnable() =>
        _enemy.Dying += MakePhysical;

    private void OnDisable() =>
        _enemy.Dying -= MakePhysical;


    private void MakePhysical()
    {
        _enemyAnimator.enabled = false;
        SetKinematic(false);
    }

    private void SetKinematic(bool isKinematic)
    {
        foreach (var bone in _bones)
            bone.isKinematic = isKinematic;
    } 
}
