using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class FoodBar : MonoBehaviour
    {
        Slider _slider;
        public GameObject textUI;
        Text _text;
        private int _maxFood;
        private int _currentFood;
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
            _maxFood = PlayerState.Instance._maxFood;
            _currentFood = PlayerState.Instance._currentFood;
            float sliderVal = (float)_currentFood/ _maxFood*100;
            _slider.maxValue = _maxFood;
            _slider.value = _currentFood;
            _text.text = _currentFood + "/" + _maxFood;
            _slider.value = sliderVal;
            
        }
        
    }
}
