using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbutton : MonoBehaviour {
    //存储manger脚本的引用
    private gamemanger m_gamemanger;
	// Use this for initialization
	void Start () {
        //查找gamemanger脚本
        m_gamemanger = GameObject.Find("UI").GetComponent<gamemanger>();
	}
    /// <summary>
    /// 点击开始触发事件
    /// </summary>
    void OnMouseDown()
    {
        m_gamemanger.statechangge(gamemanger.gamestate.game);

    } 
   
	// Update is called once per frame
	void Update () {
		
	}
}
