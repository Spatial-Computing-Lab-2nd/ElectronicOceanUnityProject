using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAnemone : MonoBehaviour
{
    public GameObject planet;       // 引力の発生する星
    public GameObject MainCamera;
    public float accelerationScale; // 加速度の大きさ
    public AnemoneManager anemoneManager;
    private Vector3 Player_pos; //プレイヤーのポジション
    public long AirtapCountPast = 0;

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
        planet = GameObject.Find("GravityPoint");
        MainCamera = GameObject.Find("AnemoneManagerGameObject");
        anemoneManager = MainCamera.GetComponent<AnemoneManager>();
        AirtapCountPast = anemoneManager.anemoneCount;
    }

    void Update()
    {
        // 星に向かう向きの取得
        var direction = planet.transform.position - transform.position;
        direction.Normalize();
        // 加速度与える
        GetComponent<Rigidbody>().AddForce(accelerationScale * direction, ForceMode.Acceleration);
        Vector3 diff = transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        if (diff.magnitude > 0.001f) //ベクトルの長さが0.001fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }
        Player_pos = transform.position; //プレイヤーの位置を更新
        if (anemoneManager.anemoneCount - AirtapCountPast >= 20)
        {
            Destroy(this.gameObject);
        }
    }
}