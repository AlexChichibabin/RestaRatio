using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MainMenuWindow : WindowBase
{
    public event UnityAction playButtonClicked;

    [SerializeField] private string buttonLabelPrefic = "Start level ";
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => playButtonClicked?.Invoke());
    }

    public void SetLevelIndex(int levelIndex)
    {
        levelNumberText.text = buttonLabelPrefic + (levelIndex + 1).ToString();
    }

    public void HidePlayButton()
    {
        playButton.gameObject.SetActive(false);
    }
}