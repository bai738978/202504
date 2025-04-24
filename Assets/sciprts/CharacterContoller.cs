using Codice.Client.BaseCommands;
using UnityEngine;
using UnityEngine.InputSystem;

public class charatercontrler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private PlayerInput playerInput;
    
    private InputAction moveAction;

    private void Start()
    {
        moveAction = playerInput.actions.FindAction["Move"];
    }

    // Update is called once per frame
    void Update()
    {
           
        var moveVector2 = moveAction.ReadValue<Vector2>() 
        
        // 修正斜著走比較快的問題
        var direction = new Vector3(moveVector2.x,  moveVector2.y , 0);
        transform.position += movement;
    }
}
