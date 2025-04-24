using Codice.Client.BaseCommands;
using UnityEngine;

public class charatercontrler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
           // 水平輸入(左右)
        var horizontal = Input.GetAxis("Horizontal");
          // 垂直輸入(上下)
        var vertical = Input.GetAxis("Vertical");
         // 移動方向
        var direction = new Vector3(horizontal , vertical , 0); 
        // 修正斜著走比較快的問題
        direction = direction.normalized;
        // 移動向量 deltaTime = 1/fps , 1/60 = 0.16667f
        var movement  = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
