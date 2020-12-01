using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnemone : MonoBehaviour
{
    public GameObject anemone;
    private long airtapCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        airtapCount++;
        GameObject runcherAnemone = GameObject.Instantiate(anemone) as GameObject; //runcherbulletにbulletのインスタンスを格納
        //GameObject runcherAnemone = GameObject.Instantiate(anemone,this.transform) as GameObject; //runcherbulletにbulletのインスタンスを格納
        runcherAnemone.GetComponent<Rigidbody>().velocity = transform.forward;// * 3; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
        runcherAnemone.transform.position = transform.position;
        this.GetComponent<ShotAnemone>().enabled = false;
    }
    //プロパティー
    public long AirtapCount
    {
        get { return this.airtapCount; }  //取得用
        set { this.airtapCount = value; } //値入力用
    }
}
