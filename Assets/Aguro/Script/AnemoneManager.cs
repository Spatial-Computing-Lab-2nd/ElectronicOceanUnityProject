using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnemoneManager : MonoBehaviour
{
    public GameObject anemoneGameObject;

    //public Text text;
    Vector3 cursorPosition;
    Vector3 cursorPosition3d;
    RaycastHit hit;

    public int anemoneCount;

    private int pastTouchCount;

    // [SerializeField] private GameObject duckObject;
    // [SerializeField] private GameObject duckDestinationObject;

    // Start is called before the first frame update
    void Start()
    {
        pastTouchCount = 0;
        //text.text = "";
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = new Vector2(0.0f, 0.0f);
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            // var mousePosition = Input.mousePosition;
            // touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            ShotAnemone();
        }
        else
        {
            return;
        }
#else
        if (Input.touchCount > 0 && pastTouchCount < Input.touchCount)
        {
            // touchPosition = Input.GetTouch(0).position;
            ShotAnemone();
        }
        pastTouchCount = Input.touchCount;

        // else
        // {
        //     return;
        // }
#endif
        // //cursorPosition = Input.mousePosition; // 画面上のカーソルの位置
        // cursorPosition.x = touchPosition.x;
        // cursorPosition.y = touchPosition.y;
        // cursorPosition.z = 10.0f; // z座標に適当な値を入れる
        // cursorPosition3d = Camera.main.ScreenToWorldPoint(cursorPosition); // 3Dの座標になおす
        //
        // // カメラから cursorPosition3d の方向へレイを飛ばす
        // if (Physics.Raycast(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position), out hit, Mathf.Infinity))
        // {
        //     if (hit.collider.CompareTag("WaterRayTarget"))
        //     {
        //         duckDestinationObject.transform.position = hit.point;
        //             
        //         Debug.DrawRay(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position) * hit.distance, Color.red);
        //
        //         text.text = hit.point.ToString();
        //     }
        // }
    }
    void ShotAnemone()
    {
        GameObject anemone = GameObject.Instantiate(anemoneGameObject) as GameObject; //runcherbulletにbulletのインスタンスを格納
        anemone.GetComponent<Rigidbody>().velocity = transform.forward;// * 3; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
        anemone.transform.position = transform.position;
        anemone.transform.rotation = transform.rotation;
    }

}
