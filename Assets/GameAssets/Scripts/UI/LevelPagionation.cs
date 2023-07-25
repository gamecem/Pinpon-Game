using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UniRx;

public class LevelPagination : MonoBehaviour
{
    [SerializeField] private Button levelButtonPrefab;
    [SerializeField] private Transform levelButtonPanel;
    [SerializeField] private Transform paginationPanel;
    [SerializeField] public int levelsPerPage = 9;
    [SerializeField] private int rows = 3;
    [SerializeField] private int cols = 3;
    [SerializeField] private float spacingX = 100f;
    [SerializeField] private float spacingY = 50f;

    private List<List<Button>> levelButtonPages = new List<List<Button>>();
    private ReactiveProperty<int> currentPage = new ReactiveProperty<int>(0);

    private void Start()
    {
        CreateLevelButtons();
        CreatePreviousPageButton();
        CreateNextPageButton();

        currentPage.Subscribe(pageIndex => ShowPage(pageIndex)).AddTo(this);
    }

    private void CreateLevelButtons()
    {
        int pageCount = Mathf.CeilToInt((float)LevelManager.Instance.GetTotalLevels() / levelsPerPage);
        for (int i = 0; i < pageCount; i++)
        {
            List<Button> buttons = new List<Button>();
            for (int j = i * levelsPerPage; j < Mathf.Min((i + 1) * levelsPerPage, LevelManager.Instance.GetTotalLevels()); j++)
            {
                Button button = Instantiate(levelButtonPrefab, levelButtonPanel);
                int row = j / cols;
                int col = j % cols;

                float initialX = -((cols - 1) * spacingX) / 2f;
                float initialY = ((rows - 1) * spacingY) / 2f;

                button.GetComponent<RectTransform>().anchoredPosition = new Vector2(initialX + col * spacingX, initialY - row * spacingY);

                button.GetComponentInChildren<TMP_Text>().text = "Level " + (j + 1).ToString();
                button.onClick.AddListener(() => OnLevelButtonClicked(j + 1));
                buttons.Add(button);
            }
            levelButtonPages.Add(buttons);
        }
    }

    private void CreatePreviousPageButton()
    {
        Button previousButton = Instantiate(levelButtonPrefab, paginationPanel);
        previousButton.GetComponentInChildren<TMP_Text>().text = "Previous";
        previousButton.onClick.AsObservable()
            .Subscribe(_ => ShowPreviousPage())
            .AddTo(this);

        SetPaginationButtonPosition(previousButton.transform, -1f, -1f);
    }

    private void CreateNextPageButton()
    {
        Button nextButton = Instantiate(levelButtonPrefab, paginationPanel);
        nextButton.GetComponentInChildren<TMP_Text>().text = "Next";
        nextButton.onClick.AsObservable()
            .Subscribe(_ => ShowNextPage())
            .AddTo(this);

        SetPaginationButtonPosition(nextButton.transform, 1f, -1f);
    }

    private void SetPaginationButtonPosition(Transform buttonTransform, float xOffset, float yOffset)
    {
        RectTransform canvasRectTransform = GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        RectTransform buttonRectTransform = buttonTransform.GetComponent<RectTransform>();

        float canvasWidth = canvasRectTransform.rect.width;
        float canvasHeight = canvasRectTransform.rect.height;
        float buttonWidth = buttonRectTransform.rect.width;
        float buttonHeight = buttonRectTransform.rect.height;

        float posX = (canvasWidth / 2f - buttonWidth / 2f) * xOffset;
        float posY = (canvasHeight / 2f - buttonHeight / 2f) * yOffset;

        buttonRectTransform.anchoredPosition = new Vector2(posX, posY);
    }

    private void ShowPreviousPage()
    {
        currentPage.Value = Mathf.Max(0, currentPage.Value - 1);
    }

    private void ShowNextPage()
    {
        currentPage.Value = Mathf.Min(currentPage.Value + 1, levelButtonPages.Count - 1);
    }

    private void ShowPage(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex >= levelButtonPages.Count)
            return;

        for (int i = 0; i < levelButtonPages.Count; i++)
        {
            List<Button> buttons = levelButtonPages[i];
            for (int j = 0; j < buttons.Count; j++)
            {
                bool showButton = (i == pageIndex);
                buttons[j].gameObject.SetActive(showButton);

                if (showButton)
                {
                    buttons[j].transform.localScale = Vector3.zero;
                    buttons[j].transform.DOScale(Vector3.one, 0.5f);
                }
            }
        }

        paginationPanel.GetChild(0).GetComponent<Button>().interactable = (pageIndex != 0);

        paginationPanel.GetChild(1).GetComponent<Button>().interactable = (pageIndex != levelButtonPages.Count - 1);
    }

    private void OnLevelButtonClicked(int level)
    {
        Debug.Log("Level " + level + " button clicked!");
        // LEVELİ YÜKLE BURDA
    }
}
