using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGauge : MonoBehaviour
{
    public int gaugeMax = 15;
    public int currentgauge = 0;

    [SerializeField ] Slider gaugeBar;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        gaugeBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentgauge <gaugeMax )
        {
            time = time + Time.deltaTime;
            if(time>0.8f)
            {
                currentgauge++;
                time = 0f;
            }
           
        }
        gaugeBar.value = (float)currentgauge / (float)gaugeMax;
    }
}
