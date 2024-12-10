using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PalyerScript _player;
    [SerializeField] private SkillGauge gauge;
    [SerializeField] GameObject lifeImage;
    [SerializeField] GameObject Skill_1Image;
    [SerializeField] GameObject Skill_2Image;
    public Sprite life3Image;
    public Sprite life2Image;
    public Sprite life1Image;
    public Sprite life0Image;
    public Sprite skill_1ONImage;
    public Sprite skill_1OFFImage;
    public Sprite skill_2ONImage;
    public Sprite skill_2OFFImage;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHP();
        SkillOnOff();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
        SkillOnOff();
    }
    void UpdateHP()
    {
        if (_player .currentHP <=0)
        {
            lifeImage.GetComponent<Image>().sprite = life0Image;
        }
       else if(_player .currentHP ==1)
        {
            lifeImage.GetComponent<Image>().sprite = life1Image;
        }
        else if(_player .currentHP ==2)
        {
            lifeImage.GetComponent<Image>().sprite = life2Image;
        }
        else
        {
            lifeImage.GetComponent<Image>().sprite = life3Image;
        }
    }
    void SkillOnOff()
    {
        if(gauge .currentgauge >=5)
        {
            Skill_1Image.GetComponent<Image>().sprite = skill_1ONImage;
        }
        else
        {
            Skill_1Image.GetComponent<Image>().sprite = skill_1OFFImage;
        }
        if (gauge.currentgauge >= 10)
        {
            Skill_2Image.GetComponent<Image>().sprite = skill_2ONImage;
        }
        else
        {
            Skill_2Image.GetComponent<Image>().sprite = skill_2OFFImage;
        }
    }
}
