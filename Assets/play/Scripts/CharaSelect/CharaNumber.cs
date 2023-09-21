using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharaNumber : MonoBehaviour
{

    private Button button;
    private CharaSelect charaSelect;
    public int Select;

    private Vector2 _sizeExit = new Vector2(350, 500);
    private Vector2 _sizeEnter = new Vector2(420, 600);

    private RectTransform _rT;
    public GameObject dif;
    public GameObject Fade;
    public GameObject[] Chara=new GameObject[2];

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectNum);
        charaSelect = GameObject.Find("CharaSelect").GetComponent<CharaSelect>();
        _rT = GetComponent<RectTransform>();
        dif.SetActive(false);
        Fade.SetActive(false);
    }

    public void Enter()
    {
        _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sizeEnter.x);
        _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _sizeEnter.y);
        dif.SetActive(true);
        for(int i = 0; i < 2; ++i) {
            Chara[i].gameObject.transform.parent=GameObject.Find("CharaFade").transform;
        }
        Fade.SetActive(true);
    }

    public void Exit()
    {
        _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sizeExit.x);
        _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _sizeExit.y);
        dif.SetActive(false);
        Fade.SetActive(false);
        for(int i = 0; i < 2; ++i) {
            Chara[i].gameObject.transform.parent = GameObject.Find("Chara").transform;
        }
    }

    void SelectNum()
    {
        charaSelect.SetGame(Select);
    }
}
