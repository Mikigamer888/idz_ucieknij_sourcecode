using UnityEngine;
using TMPro; // Use TMPro for TextMesh Pro UI elements
using System.Collections.Generic;

public class AudioDropdownController : MonoBehaviour
{
    public TMP_Dropdown musicDropdown;
    private AudioSource[] allAudioSources;
    private AudioSource currentPlayingAudio;

    void Start()
    {
        // Get all audio sources from this GameObject and its children
        allAudioSources = GetComponentsInChildren<AudioSource>();

        // Clear any existing options from the dropdown
        musicDropdown.ClearOptions();

        // Create a list of OptionData for the dropdown
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData("None")); // Add the "None" option first

        // Add the names of all child GameObjects that have an AudioSource
        foreach (AudioSource audioSource in allAudioSources)
        {
            options.Add(new TMP_Dropdown.OptionData(audioSource.gameObject.name));
        }

        // Add the created options to the dropdown
        musicDropdown.AddOptions(options);

        // Add a listener to detect when the dropdown selection changes
        musicDropdown.onValueChanged.AddListener(delegate {
            OnDropdownValueChanged(musicDropdown);
        });
    }

    public void OnDropdownValueChanged(TMP_Dropdown dropdown)
    {
        // Get the selected option's text
        string selectedName = dropdown.options[dropdown.value].text;

        // Stop the currently playing audio if any exists
        if (currentPlayingAudio != null)
        {
            currentPlayingAudio.Stop();
        }

        // Check if the selected option is "None"
        if (selectedName == "None")
        {
            currentPlayingAudio = null;
            return; // Exit the function
        }

        // Find the corresponding AudioSource and play it
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.gameObject.name == selectedName)
            {
                currentPlayingAudio = audioSource;
                currentPlayingAudio.Play();
                break; // Stop searching once a match is found
            }
        }
    }
}