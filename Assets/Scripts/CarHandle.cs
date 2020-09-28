using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CarHandle : MonoBehaviour {

    public Transform myGameObjectTransform;

    //動くスピード
    [SerializeField]
    private float speed = 1;

    //角速度
    [SerializeField]
    private float angleSpeed = 1;

    // Update is called once per frame
    void Update () {
        //左右キー
        float horizontal = Input.GetAxis ("Horizontal");

        //上下キー
        float vertical = Input.GetAxis ("Vertical");

        //y軸を中心とした角度(0-360)
        float eulerAngY = transform.rotation.eulerAngles.y;

        //0-2πに変換
        double angle    = Math.PI * eulerAngY / 180.0;
        double sinAngle = Math.Sin(angle);
        double cosAngle = Math.Cos(angle);

        //水平方向の移動
        Vector3 movement = new Vector3 (vertical*(float)sinAngle,0, vertical*(float)cosAngle);


        //角速度
        // Quaternion target = Quaternion.Euler(10, 0, 10);
        

        //コマ送りごとに位置を動かす
        transform.position += movement * Time.deltaTime * speed;

        //y軸を起点とした回転（時計回りが正）
        transform.Rotate(0, horizontal*vertical*angleSpeed, 0, Space.World);
    }

    private void OnCollisionEnter (Collision collision) {
        SceneManager.LoadScene (0);
    }

}