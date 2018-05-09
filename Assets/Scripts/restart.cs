using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour {
    //存储gamemanger
    public gamemanger m_gamemanger;
    // Use this for initialization
    void Start () {
        //查找gamemanger
        m_gamemanger = GameObject.Find("UI").GetComponent<gamemanger>();
    }
    void OnMouseDown()
    {
        m_gamemanger.statechangge(gamemanger.gamestate.start);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
