using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class HealthBar : MonoBehaviour
    {

        Slider _slider;
        public GameObject textUI;
        Text _text;
        private int _maxHealth;
        private int _currentHealth;
        void Start()
        {
            _slider = GetComponent<Slider>();
            _text = textUI.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateHealthBar();
        }

        void UpdateHealthBar()
        {
            _maxHealth = PlayerState.Instance._maxHealth;
            _currentHealth = PlayerState.Instance._currentHealth;
            float sliderVal = (float)_currentHealth / _maxHealth *100;
            _slider.maxValue = _maxHealth;
            _slider.value = _currentHealth;
            _text.text = _currentHealth + "/" + _maxHealth;
            _slider.value = sliderVal;
            
        }
    }
}
