using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.StaticData.Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartButton : MonoBehaviour
{
    public int LevelIndex { get; set; }

    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _levelIndexText;
    [SerializeField] private Sprite _lockedLevelSprite;
    [SerializeField] private Sprite _unlockedLevelSprite;
    [SerializeField] private Sprite _oneStarLevelSprite;
    [SerializeField] private Sprite _twoStarsLevelSprite;
    [SerializeField] private Sprite _threeStarsLevelSprite;

    private IGameStateMachine _gameStateMachine;
    private IProgressService _progressService;
    private IStaticDataService _staticDataService;

    public void Construct(IGameStateMachine gameStateMachine, IProgressService progressService, IStaticDataService staticDataService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _staticDataService = staticDataService;
    }

    private void Start() =>
        StartButton();

    public void SetLevelName(int levelIndex) =>
        LevelIndex = levelIndex;

    public void SetLevelIndexText(int levelIndex) =>
        _levelIndexText.SetText(levelIndex.ToString());

    public void LevelState()
    {
        if (_progressService.PlayerProgress.LevelProgress.LevelAt < LevelIndex)
        {
            LockedLevel();
        }
        else if (_progressService.PlayerProgress.LevelProgress.LevelAt == LevelIndex)
        {
            CurrentLevel();
        }
        else
        {
            FinishedLevel();
        }
    }

    private void CurrentLevel()
    {
        _startButton.interactable = true;
        _startButton.image.sprite = _unlockedLevelSprite;
        _levelIndexText.enabled = false;
    }

    private void LockedLevel()
    {
        _startButton.interactable = false;
        _startButton.image.sprite = _lockedLevelSprite;
        _levelIndexText.enabled = false;
    }

    private void FinishedLevel()
    {
        LevelStaticData levelStaticData = _staticDataService.LevelData(LevelIndex.ToString());

        if (levelStaticData.MinimumCoinCollected())
        {
            _startButton.image.sprite = _oneStarLevelSprite;
        }
        else if (levelStaticData.MediumCoinCollected())
        {
            _startButton.image.sprite = _twoStarsLevelSprite;
        }
        else if (levelStaticData.MaximumCointCollected())
        {
            _startButton.image.sprite = _threeStarsLevelSprite;
        }

        _levelIndexText.enabled = true;
    }

    private void StartButton() =>
        _startButton.onClick.AddListener(() => _gameStateMachine.Enter<LoadLevelState, string>(LevelIndex.ToString()));
}
