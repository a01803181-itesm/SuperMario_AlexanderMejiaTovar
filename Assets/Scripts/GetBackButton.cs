// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackButton : MonoBehaviour
{
    private UIDocument getBackUIDocument;
    private Button getBackButton;
    
    // Initializes the UI document, finds the back button, and registers the click callback.
    void Start()
    {
        getBackUIDocument = GetComponent<UIDocument>();
        var root = getBackUIDocument.rootVisualElement;
        getBackButton = root.Q<Button>("GetBackButton");

        getBackButton.RegisterCallback<ClickEvent>(GetBack);
    }

    // Loads the MainMenu scene when the back button is clicked.
    void GetBack(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
