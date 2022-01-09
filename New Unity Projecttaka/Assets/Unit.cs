using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum 変数が取る値を決められる
//int, float ,stringと同じ”型”の1つ、Formを作った。
public enum Form
{
    circle,
    star
}
//Numberという”型”を作った
public enum Number
{
    four,
    five
}

public class Unit : MonoBehaviour
{
    //public は inspecterから見える
    public Form form;
    public Number number;

    public GameObject nowObj;

    public Database database;
    private bool m_isSelected = false;
    public GameObject frame;
    public quiz quizObj;

    //プロパティ
    public bool isSelected
    {
        get { return m_isSelected; }
        set
        {
            m_isSelected = value;
            if (value == true)
            {
                frame.SetActive(true);
            }
            else
            {
                frame.SetActive(false);
            }
        }
    }

    void Start()
    {
        DecideStatus();
        MakeObj();
        quizObj.MakeQuiz();
        frame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されたら一回だけ実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecideStatus();
            MakeObj();
            quizObj.MakeQuiz();

        }

    }

    public void DecideStatus()
    {
        //formとnumberの値をランダムに決定
        if (Random.value > 0.5f)
        {
            form = Form.circle;
        }
        else
        {
            form = Form.star;
        }
        if (Random.value > 0.5f)
        {
            number = Number.four;
        }
        else
        {
            number = Number.five;
        }
        //consoldeに出力
        //Debug.Log(form + " " + number);
    }
    public void MakeObj()
    {
        if (nowObj != null)
        {
            Destroy(nowObj);
        }
        if (form == Form.circle)
        {
            if (number == Number.four) nowObj = Instantiate(database.FourBall, this.transform);
            if (number == Number.five) nowObj = Instantiate(database.FiveBall, this.transform);
        }
        else if (form == Form.star)
        {
            if (number == Number.four) nowObj = Instantiate(database.FourStar, this.transform);
            if (number == Number.five) nowObj = Instantiate(database.FiveStar, this.transform);
        }
        this.isSelected = false;


    }
}
