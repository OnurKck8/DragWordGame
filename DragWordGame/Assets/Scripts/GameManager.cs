using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string[] _dictionary;

    public TextMeshProUGUI _scoreText;

    List<GameObject> _selectedButtons;


    string _word = null;

    public bool _isClicked = false;

    public GameObject _gamePanel;

    int _score = 0;
    int _answerCount = 0;

    void Start()
    {
        _selectedButtons = new List<GameObject>();
    }

    public void SelectedButton(GameObject button)
    {
        _selectedButtons.Add(button);
        _word = null;

        foreach (GameObject buttons in _selectedButtons)
        {
            _word = _word + buttons.name;
            _scoreText.text = _word;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isClicked = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isClicked = false;
            CreatedWord();
            _scoreText.text = _score.ToString();
        }
    }

    void CreatedWord()
    {
        foreach (string words in _dictionary)
        {
            if (words == _word)
            {
                _score += 100;
                _answerCount++;

                foreach (GameObject button in _selectedButtons)
                {
                    button.GetComponent<ButtonController>()._destroyword = true;
                }
            }
        }

        _selectedButtons.Clear();
        _word = null;

        if (_answerCount == _dictionary.Length)
        {
            _gamePanel.SetActive(true);

        }
    }
}
