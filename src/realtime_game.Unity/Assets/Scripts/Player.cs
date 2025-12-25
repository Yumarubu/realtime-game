using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.1f; // スピード係数（大きいと瞬間移動するので注意！）
    FixedJoystick joystick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ジョイスティックの情報を取得
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();

    }

    // Update is called once per frame
    void Update()
    {
        // ジョイスティックの入力から移動量を計算
        Vector2 move = new Vector2(
          transform.position.x + joystick.Horizontal * speed,
          transform.position.y + joystick.Vertical * speed
        );

        // 移動量を反映
        transform.position = move;
    }
}
