using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace RedRift.Test.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private string _settingsPath;
        [SerializeField] private string _gameScene;

        [SerializeField] private Transform _buttonParent;
        [SerializeField] private Button _buttonPrefab;

        [SerializeField] private TextMeshProUGUI _hitText;

        private PersistentSettings _persistent;

        private void Awake()
        {
            _persistent = FindObjectOfType<PersistentSettings>();
            _hitText.text = _persistent.Hits.ToString();

            CreateButtons();
        }

        private void CreateButtons()
        {
            PlanetSettings[] settings = Resources.LoadAll<PlanetSettings>(_settingsPath);

            foreach (PlanetSettings pSettings in settings)
            {
                Button newButton = Instantiate(_buttonPrefab, _buttonParent);

                newButton.GetComponentInChildren<TextMeshProUGUI>().text = pSettings.name;
                newButton.onClick.AddListener(() => SelectPlanet(pSettings));
            }
        }

        private void SelectPlanet(PlanetSettings s)
        {
            Debug.Log($"You have selected {s.name} planet! Prepare to landing...");
            _persistent.SetPlanet(s);
            SceneManager.LoadScene(_gameScene);
        }
    }
}