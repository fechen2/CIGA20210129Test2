using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
public class MySceneManager : MonoBehaviour
{

    public GameObject testDragon;

    // Start is called before the first frame update
    void Start()
    {
        if(testDragon)
        {

            Transform ttt = testDragon.transform.Find("Dragon");

           SkeletonAnimation sA = ttt.GetComponent<SkeletonAnimation>();
           sA.state.SetAnimation(0,"flying",true);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
