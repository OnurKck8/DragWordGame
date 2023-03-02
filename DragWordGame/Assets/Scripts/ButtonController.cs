using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    GameManager _gameManager;
    Image _color;
    RectTransform _scale;

    string _word;

    bool _giveWord = false;

    public bool _destroyword = false;

    float _scaleSpeed = 0.08f;


    void Start()
    {
        _gameManager = GameObject.Find("[GameManager]").GetComponent<GameManager>();
        _color = GetComponent<Image>();
        _scale = GetComponent<RectTransform>();
        _word = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager._isClicked == false)
        {
            _giveWord = false;
            _color.color = Color.white;
        }

        if (_destroyword == true)
        {
            _scale.localScale -= new Vector3(_scaleSpeed, _scaleSpeed, _scaleSpeed);

            if (_scale.localScale.x <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GreenMake()
    {
        if (_gameManager._isClicked == true)
        {
            _color.color = Color.green;

            if (_giveWord == false)
            {
                _gameManager.SelectedButton(gameObject);
                _giveWord = true;
            }
        }
    }
}
