using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public event UnityAction StartingGame;

    [SerializeField] private Text _initialTextOnDisplay;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialTextOnDisplay.enabled = false;
            StartingGame?.Invoke();
        }
    }
}
