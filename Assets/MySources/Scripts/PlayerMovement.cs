using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _stopPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] StartGame _startGame;

    private NavMeshAgent _navMeshAgent;
    private Animator _playerAnimator;
    private bool _isRun;
    private bool _isAiming;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
        _playerAnimator = GetComponent<Animator>();
        _isAiming = false;
        _isRun = false;
    }

    private void OnEnable() =>
        _startGame.StartingGame += EnableRunningState;


    private void OnDisable() =>
        _startGame.StartingGame -= EnableRunningState;
    

    private void Update()
    {
        if (_isRun)
        {
            _navMeshAgent.SetDestination(_stopPoint.position);
            _playerAnimator.SetBool("Run", true);
            _playerAnimator.SetBool("Shot", _isAiming);

            _navMeshAgent.speed = _isAiming ? 0f : _moveSpeed;
        }
    }

    private void LateUpdate()
    {
        if (_isAiming)
        {
            if (Input.GetMouseButtonDown(0)) 
            { 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    transform.LookAt(raycastHit.point);
            }
        }
    }

    public void SwitchPoseAiming(bool isAiming) =>
        _isAiming = isAiming;

    private void EnableRunningState() =>
        _isRun = true;

}
