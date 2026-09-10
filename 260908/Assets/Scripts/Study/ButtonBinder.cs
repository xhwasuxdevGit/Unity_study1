using UnityEngine;
using UnityEngine.UI;


public class ButtonBinder : MonoBehaviour
{
    [SerializeField] private Button _codeButton;
    [SerializeField] private ScoreBoard _scoreBoard;
    [SerializeField] private Button _addButton;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        BindButtonEvents();
    }

    private void BindButtonEvents()
    {
        _codeButton.onClick.AddListener(_scoreBoard.AddScore);
        _addButton.onClick.AddListener(_audioSource.Play);
    }

}
