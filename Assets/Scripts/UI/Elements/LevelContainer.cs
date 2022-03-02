using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.UI.Factory;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    private int _levelIndex = 4;

    [SerializeField] private List<Transform> _levelPositions;
    [SerializeField] private List<LevelStartButton> _levelStartButtons;

    private IGameStateMachine _gameStateMachine;
    private IUIFactory _uiFactory;
    private IProgressService _progressService;
    private IStaticDataService _staticDataService;

    public void Construct(IGameStateMachine gameStateMachine, IUIFactory uiFactory, IProgressService progressService, IStaticDataService staticDataService)
    {
        _gameStateMachine = gameStateMachine;
        _uiFactory = uiFactory;
        _progressService = progressService;
        _staticDataService = staticDataService;
    }

    private void Start()
    {
        InitializeLevelStartButtons();
        CheckUnlockedLevels();
    }

    private void InitializeLevelStartButtons()
    {
        for (int i = 0; i < _levelPositions.Count; i++)
        {
            LevelStartButton levelStartButton = CreateLevelStartButton(i);

            _levelStartButtons.Add(levelStartButton);

            _levelIndex++;
        }
    }

    private void CheckUnlockedLevels()
    {
        foreach (LevelStartButton levelStartButton in _levelStartButtons)
        {
            levelStartButton.LevelState();           
        }
    }

    private LevelStartButton CreateLevelStartButton(int index)
    {
        GameObject prefab = _uiFactory.CreateLevelStartButton(_levelPositions[index].position, transform);
        LevelStartButton levelStartButton = prefab.GetComponent<LevelStartButton>();
        levelStartButton.Construct(_gameStateMachine, _progressService, _staticDataService);
        levelStartButton.SetLevelName(_levelIndex);
        levelStartButton.SetLevelIndexText(++index);

        return levelStartButton;
    }
}
