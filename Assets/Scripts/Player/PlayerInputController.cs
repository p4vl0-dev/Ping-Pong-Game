using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private IControllable _controllerInterface;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();

        try{ _controllerInterface = GetComponent<IControllable>(); } catch{ Debug.Log("Controllable interface has not found.\nCheck his position on a Player object"); }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        var readedVector = _playerInput.PlayerMovement.Movement.ReadValue<Vector2>();
        var writtenVector = new Vector2(0, readedVector.y);
        _controllerInterface.ReadDirection(writtenVector);
    }
}
