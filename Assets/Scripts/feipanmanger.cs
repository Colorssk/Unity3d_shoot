using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feipanmanger : MonoBehaviour {
    public GameObject pre_feipan;
    private Transform m_transform;
	// Use this for initialization
	void Start () {       
        m_transform = gameObject.GetComponent<Transform>();
        
    }
    /// <summary>
    /// 生成飞盘
    /// </summary>
    public void creat()
    {
        InvokeRepeating("creatfeipan", 2.0f, 2.0f);
    }
    void creatfeipan()
    {   for (int i = 0; i < 3; i++)
        {
            //随机坐标
            Vector3 feipan = new Vector3(Random.Range(-6.0f, 5.0f), Random.Range(1.0f, 3.0f), Random.Range(-5.0f, 6.0f));
            //实例化物体
            GameObject  go= GameObject.Instantiate(pre_feipan, feipan, Quaternion.identity) as GameObject;
            //管理实例化物体
            go.GetComponent<Transform>().SetParent(m_transform);
        }
        
    }
    /// <summary>
    /// 停止生成飞盘
    /// </summary
   public void stopcreat()
    {
        CancelInvoke("creatfeipan");
    }
    public void removefeipan()
    {
        Transform[] fp = m_transform.GetComponentsInChildren<Transform>();
        //避免删除父物体（父物体有脚本），所以i从1开始
        for (int i = 1; i < fp.Length; i++)
        {
            GameObject.Destroy(fp[i].gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
