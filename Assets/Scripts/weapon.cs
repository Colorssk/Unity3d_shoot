using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    private Transform tra;
    private Ray ray;
    private RaycastHit hit;
    private Transform shoot;//枪口位置
    private LineRenderer m_linerenderer;
    private AudioSource m_music;//射击声音
    public int score = 0;
    //存储gamemanger
    public gamemanger m_gamemanger;
    //控制手臂移动的标识符
    public bool canmove=true;

	void Start () {
        tra = gameObject.GetComponent<Transform>();
        shoot = tra.FindChild("ray");
        m_linerenderer = shoot.gameObject.GetComponent<LineRenderer>();
        //shoot为transform组件用.gameObjectke找出其上一级的物体组件
        m_music = gameObject.GetComponent<AudioSource>();
        //查找gamemanger
        m_gamemanger = GameObject.Find("UI").GetComponent<gamemanger>();
     
    }

    /// <summary>
    /// 分数增加
    /// </summary>
    public void addscore()
    {
        score++;
        m_gamemanger.m_score.text= "分数:" + score + "分";//像这种藏的比较深的GUI组件最好让那个组件的父脚本查找并且赋值，
        //其他脚本只负责引用

    }
    void Update () {
       
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (canmove)//判断手臂是否可以移动
        {
            if (Physics.Raycast(ray, out hit))
            {   //控制手臂朝向鼠标点
                tra.LookAt(hit.point);
                //debug绘制
                Debug.DrawLine(shoot.position, hit.point, Color.red);

                //绘制linerenderer
                m_linerenderer.SetPosition(0, shoot.position);
                m_linerenderer.SetPosition(1, hit.point);


                //点击射击事件
                if (hit.collider.tag == "feipan" && Input.GetMouseButtonDown(0))
                {
                    m_music.Play();
                    //由子物体找到父物体均为transform组件
                    Transform parent = hit.collider.gameObject.GetComponent<Transform>().parent;
                    //再由父物体统一找到所有子物体均为transform组件
                    Transform[] allchild = parent.GetComponentsInChildren<Transform>();
                    //添加刚体组件模拟飞盘下落
                    for (int j = 0; j < allchild.Length; j++)
                    {
                        allchild[j].gameObject.AddComponent<Rigidbody>();
                    }
                    GameObject.Destroy(parent.gameObject, 2.0f);
                    //调用增加增加分数
                    addscore();
                }
            }
        }
		
	}
   
}
