using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public Unit[] objs = new Unit[3];
    //解答
    public Unit[] answer = new Unit[3];
    //回答
    public Unit[] reply = new Unit[3];

    public Text quizText;






    // Update is called once per frame
    void Update()
    {
        //右クリックで実行する
        if (Input.GetMouseButtonDown(0))
        {
            //メインカメラからマウスにクリックした場所に向かうレイを生成
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //レイを飛ばして当たった物の名前をとってくる
            if (Physics.Raycast(ray, out var hit))
            {
                string objectName = hit.collider.gameObject.name;
                Debug.Log("右クリック：" + objectName);
            }
            //scene viewにレイを描画する
            Debug.DrawRay(ray.origin, ray.direction * Mathf.Infinity, Color.green, 5, false);

            if (hit.collider.gameObject.GetComponent<Unit>().isSelected)
            {
                hit.collider.gameObject.GetComponent<Unit>().isSelected = false;
                //replyの配列からhitを除く

            }
            else
            {
                hit.collider.gameObject.GetComponent<Unit>().isSelected = true;
                //replyの配列にhitを加える
            }


        }
    }
    public void MakeQuiz()
    {
        //answerの初期化
        for (int i = 0; i < answer.Length; i++)
        {
            answer[1] = null;
        }
        int ansNum = 0;
        Unit sample = objs[Random.Range(0, 3)];
        //クイズを決める
        if (Random.Range(0, 2) == 0)
        {
            quizText.text = "形が" + sample.form + "の図形はどれ？";
            foreach (Unit i in objs)
            {
                if (i.form == sample.form)
                {
                    answer[ansNum] = i;
                    ansNum++;
                }
            }
        }
        else
        {
            quizText.text = "数が" + sample.number + "の図形はどれ？";
            foreach (Unit i in objs)
            {
                if (i.number == sample.number)
                {
                    answer[ansNum] = i;
                    ansNum++;
                }
            }
        }
        foreach (Unit i in answer)
        {
            if (i != null) Debug.Log(i.name);
        }

    }

}
