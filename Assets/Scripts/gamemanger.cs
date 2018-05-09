using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanger : MonoBehaviour {

    public enum gamestate
    {
        start,
        game,
        end
    }
    /// <summary>
    /// 存储Ui组件引用
    /// </summary>
    public GameObject start_ui;
    public GameObject game_ui;
    public GameObject end_ui;
    // 存储当前状态
    public gamestate m_state;
    //存储脚本
    private weapon m_weapon;
    private feipanmanger m_feipanmanger;
    //存储音乐引用；
    private AudioSource music;
    /// <summary>
    /// 存储UITEXT组件  一定要都找全，只负责给其他类调用
    /// </summary>
    private GUIText m_time;
    private GUIText m_totalscore;
    public GUIText m_score;
    //标识符用来决定时间是否流动
    private bool time_start = false;
    //时间 要是float型
    float time = 10.0f;


    // Use this for initialization
    void Start () {
        //查找ui界面 Ui空物体管理ui组件
        start_ui = GameObject.Find("GAMEST");
        game_ui = GameObject.Find("GAME");
        end_ui = GameObject.Find("GAMEEND");
        //查找脚本
        m_weapon = GameObject.Find("weapon").GetComponent<weapon>();
        m_feipanmanger = GameObject.Find("feipanmanger").GetComponent<feipanmanger>();
        //查找音乐引用
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //查找时间UI组件
        m_time = GameObject.Find("gametime").GetComponent<GUIText>();
        m_totalscore = GameObject.Find("TOTALSCPRE").GetComponent<GUIText>();
        m_score = GameObject.Find("fenshu").GetComponent<GUIText>();
        //初始为开始界面
        statechangge(gamestate.start);

    }
    /// <summary>
    /// 管理Ui界面的切换
    /// </summary>
    /// 
    public void statechangge(gamestate state)
    {
        m_state = state;//存储状态
        if (m_state == gamestate.start)//当界面为开始界面
        {
            start_ui.SetActive(true);//界面设置显示与否
            game_ui.SetActive(false);
            end_ui.SetActive(false);
            //用标志符不允许手臂运动
            m_weapon.canmove = false;
            //刚进入时候停止播放音乐
            music.Stop();
            
        }else if (m_state == gamestate.game)//当界面为游戏界面
        {
            start_ui.SetActive(false);//界面设置显示与否
            game_ui.SetActive(true);
            end_ui.SetActive(false);
            m_weapon.canmove = true;
            starttime();
            music.Play();
            m_feipanmanger.creat();

        }
        else if (m_state == gamestate.end)//当界面为结束界面
        {
            start_ui.SetActive(false);//界面设置显示与否
            game_ui.SetActive(false);
            end_ui.SetActive(true);
            m_weapon.canmove = false;
            music.Stop();
            m_feipanmanger.stopcreat();
            m_feipanmanger.removefeipan();


        }
    }
    /// <summary>
    /// 用来开启时间
    /// </summary>
    void starttime()
    {
        time_start = true;
    }
    // Update is called once per frame
    void Update () {
        //倒计时
        if (time_start)
        {
            m_score.text = "分数:" + m_weapon.score + "分";
            time -= Time.deltaTime;//时间类型为float型
            m_time.text = "时间：" + time + "秒";
            if (time <=0)
            {
                statechangge(gamestate.end);//时间到以后自动转换UI界面 
                //重置
                time_start = false;//停止update中的倒计时
                time = 10.0f;//重置时间
                m_totalscore.text = "总分：" + m_weapon.score + "分";
                m_weapon.score = 0;
            }
        }
	}
}
