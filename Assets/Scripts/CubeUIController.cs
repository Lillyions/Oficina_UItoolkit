using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeUIController : MonoBehaviour
{
    public CubeController cube;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Button play_button = root.Q<Button>("play_button");
        Button stop_button = root.Q<Button>("stop_button");
        Button color_button = root.Q<Button>("color_button");

        play_button.clicked += () => cube.StartRotation();
        stop_button.clicked += () => cube.StopRotation();
        color_button.clicked += () => cube.ChangeColor();
    }
}
