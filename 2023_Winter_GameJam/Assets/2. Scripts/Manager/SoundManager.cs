using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource controller_1Click;
    public AudioSource button_Click, button_Click2;
    public AudioSource blop /*BGM*/;

    public Slider setting;

    public GameObject settingWindow, buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.dataPath + "/8. Data/SaveData.txt"))
        {
            Debug.Log("ºÒ·¯¿Ô½·´ô!");
            DataManager.Instance.Load();
            Debug.Log(DataManager.Instance.playData.sound);
            setting.value = DataManager.Instance.playData.sound;
        }

        //BGM = transform.Find("BGM").GetComponent<AudioSource>();
    }

    private void Update()
    {
        //BGM.volume = DataManager.Instance.playData.sound;
    }

    public void Setting(float volume)
    {
        setting.value = volume;
        //Button_Cilck();
        DataManager.Instance.playData.sound = volume;
        DataManager.Instance.Save();
    }

    public void Controller_1Click()
    {
        controller_1Click.volume = DataManager.Instance.playData.sound;
        controller_1Click.Play();
    }

    public void Button_Cilck()
    {
        button_Click.volume = DataManager.Instance.playData.sound;
        button_Click.Play();
    }

    public void Button_Click2()
    {
        button_Click2.volume = DataManager.Instance.playData.sound;
        button_Click2.Play();
    }

    public void Blop()
    {
        blop.volume = DataManager.Instance.playData.sound;
        blop.Play();
    }

    public void OnClickSetButton()
    {
        buttonSound.SetActive(true);
        settingWindow.SetActive(true);
        settingWindow.GetComponentInChildren<Button>().interactable = false;
        //Debug.Log(settingWindow);
        settingWindow.transform.DOScale(new Vector2(1, 1), 1f).SetEase(Ease.InOutCirc);
        //settingWindow.transform.localScale = new Vector2(1, 1);
        Invoke("Setting", 1f);
    }

    private void Setting()
    {
        settingWindow.GetComponentInChildren<Button>().interactable = true;
        Time.timeScale = 0;
    }

    public void OnClickExitSetting()
    {
        Time.timeScale = 1;
        settingWindow.GetComponentInChildren<Button>().interactable = false;
        settingWindow.transform.DOScale(new Vector2(0, 0), 1f).SetEase(Ease.InBack);
        Invoke("S_Exit", 1f);
    }

    private void S_Exit()
    {
        settingWindow.GetComponentInChildren<Button>().interactable = true;
        settingWindow.SetActive(false);
        buttonSound.SetActive(false);
    }
}
