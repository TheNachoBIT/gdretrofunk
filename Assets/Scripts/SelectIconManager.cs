using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconManager : MonoBehaviour {

    public float iconNumber;
    public Sprite s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
    [SerializeField] private Image iconImage;
    [SerializeField] private Text iconText;

    private void Update()
    {

    }

    private void Start()
    {
        iconNumber = 1;
        iconImage.color = new Color(255, 255, 0);
        iconImage.sprite = s1;
        iconText.text = "PLAYER";
        GameObject ob = new GameObject("Icon1");
        DontDestroyOnLoad(ob);
    }

    public void PlayerSprite()
    {
        iconNumber = 1;
        iconImage.color = new Color(255, 255, 0);
        iconImage.sprite = s1;
        iconText.text = "PLAYER";
        GameObject ob = new GameObject("Icon1");
        DontDestroyOnLoad(ob);
    }

    public void ClockSprite()
    {
        iconNumber = 2;
        iconImage.color = new Color(255, 255, 255);
        iconImage.sprite = s2;
        iconText.text = "TIME MASTER";
        GameObject ob = new GameObject("Icon2");
        DontDestroyOnLoad(ob);
    }

    public void Portal()
    {
        iconNumber = 3;
        iconImage.sprite = s3;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "PORTAL MAN";
        GameObject ob = new GameObject("Icon3");
        DontDestroyOnLoad(ob);
    }

    public void AntiPortal()
    {
        iconNumber = 4;
        iconImage.sprite = s4;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "ANTI-PORTAL MAN";
        GameObject ob = new GameObject("Icon4");
        DontDestroyOnLoad(ob);
    }

    public void BagPackRobot()
    {
        iconNumber = 5;
        iconImage.sprite = s5;
        s5 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "ROBOT BAGPACK";
        GameObject ob = new GameObject("Icon5");
        DontDestroyOnLoad(ob);
    }

    public void ColorBoy()
    {
        iconNumber = 6;
        iconImage.sprite = s6;
        s6 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "COLORBOY";
        GameObject ob = new GameObject("Icon6");
        DontDestroyOnLoad(ob);
    }

    public void TechnoSuitcase()
    {
        iconNumber = 7;
        iconImage.sprite = s7;
        s7 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "TECHNO SUITCASE";
        GameObject ob = new GameObject("Icon7");
        DontDestroyOnLoad(ob);
    }

    public void Qorg()
    {
        iconNumber = 8;
        iconImage.sprite = s8;
        s8 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "QORG11";
        GameObject ob = new GameObject("Icon8");
        DontDestroyOnLoad(ob);
    }

    public void Stivenelvro()
    {
        iconNumber = 9;
        iconImage.sprite = s9;
        s9 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "STIVENELVRO";
        GameObject ob = new GameObject("Icon9");
        DontDestroyOnLoad(ob);
    }

    public void TodoAndroid()
    {
        iconNumber = 10;
        iconImage.sprite = s10;
        s10 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "TODO ANDROID";
        GameObject ob = new GameObject("Icon10");
        DontDestroyOnLoad(ob);
    }

    public void Darkfoxy()
    {
        iconNumber = 11;
        iconImage.sprite = s11;
        s11 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "DARKFOXY";
        GameObject ob = new GameObject("Icon11");
        DontDestroyOnLoad(ob);
    }

    public void Ahiyu()
    {
        iconNumber = 12;
        iconImage.sprite = s12;
        s12 = iconImage.sprite;
        iconImage.color = new Color(255, 255, 255);
        iconText.text = "AHIYU";
        GameObject ob = new GameObject("Icon12");
        DontDestroyOnLoad(ob);
    }
}
