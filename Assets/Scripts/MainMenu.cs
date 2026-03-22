// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private UIDocument mainMenu;
    private Button playButton;
    private Button helpButton;
    private Button creditsButton;
    private Button exitHelp;
    private Button exitCredits;
    private Button exitApp;
    private VisualElement helpContainer;
    private VisualElement creditsContainer;
    private ScrollView creditsBody;
    private Coroutine scrollCoroutine;

    // Initializes UI elements and event callbacks when the script is enabled.
    void OnEnable()
    {
        mainMenu = GetComponent<UIDocument>();
        var root = mainMenu.rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        helpButton = root.Q<Button>("HelpButton");
        creditsButton = root.Q<Button>("CreditsButton");
        exitHelp = root.Q<Button>("ExitHelp");
        exitCredits = root.Q<Button>("ExitCredits");
        exitApp = root.Q<Button>("ButtonExit");
        helpContainer = root.Q<VisualElement>("HelpContainer");
        creditsContainer = root.Q<VisualElement>("CreditsContainer");
        creditsBody = root.Q<ScrollView>("CreditsScroll");

        playButton.RegisterCallback<ClickEvent>(PlayGame);
        helpButton.RegisterCallback<ClickEvent>(DisplayHelp);
        creditsButton.RegisterCallback<ClickEvent>(DisplayCredits);
        exitHelp.RegisterCallback<ClickEvent>(ExitSubmenu);
        exitCredits.RegisterCallback<ClickEvent>(ExitSubmenu);
        exitApp.RegisterCallback<ClickEvent>(QuitApplication);
    }

    // Loads the main game scene when the play button is clicked.
    void PlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Hides main menu buttons and shows the help container.
    void DisplayHelp(ClickEvent evt)
    {
        playButton.style.display = DisplayStyle.None;
        helpButton.style.display = DisplayStyle.None;
        creditsButton.style.display = DisplayStyle.None;
        helpContainer.style.display = DisplayStyle.Flex;
    }

    // Hides main menu buttons, shows credits container, and starts auto-scrolling.
    void DisplayCredits(ClickEvent evt)
    {
        playButton.style.display = DisplayStyle.None;
        helpButton.style.display = DisplayStyle.None;
        creditsButton.style.display = DisplayStyle.None;
        creditsContainer.style.display = DisplayStyle.Flex;
        if (scrollCoroutine != null) StopCoroutine(scrollCoroutine);
        scrollCoroutine = StartCoroutine(AutoScrollCredits());
    }

    // Shows main menu buttons, hides submenus, and stops scrolling.
    void ExitSubmenu(ClickEvent evt) {
        playButton.style.display = DisplayStyle.Flex;
        helpButton.style.display = DisplayStyle.Flex;
        creditsButton.style.display = DisplayStyle.Flex;
        helpContainer.style.display = DisplayStyle.None;
        creditsContainer.style.display = DisplayStyle.None;
        if (scrollCoroutine != null) {
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
        }
    }

    // Quits the application when the quit button is clicked (handles editor play mode and built application).
    void QuitApplication(ClickEvent evt) {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Continuously scrolls the credits text downwards and resets to the top when reaching the end.
    private IEnumerator AutoScrollCredits()
    {
        while (true)
        {
            creditsBody.scrollOffset = new Vector2(0, creditsBody.scrollOffset.y + 1);
            yield return new WaitForSeconds(0.02f); // Adjust speed as needed
            if (creditsBody.scrollOffset.y >= creditsBody.contentContainer.layout.height - creditsBody.layout.height)
            {
                creditsBody.scrollOffset = Vector2.zero;
            }
        }
    }
}
