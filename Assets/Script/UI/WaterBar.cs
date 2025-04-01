using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class WaterBar : MonoBehaviour
    {
        Slider _slider;
        public GameObject textUI;
        Text _text;
        private int _maxWater;
        private int _currentWater;
        
        void Start()
        {
            _slider = GetComponent<Slider>();
            _text = textUI.GetComponent<Text>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (InventorySystem.Instance.isOpen)
                {
                    
                }
            }   
            UpdateWaterBar();
        }

        void UpdateWaterBar()
        {
            _maxWater = PlayerState.Instance._maxWater;
            _currentWater = PlayerState.Instance._currentWater;
            float sliderVal = (float)_currentWater / _maxWater * 100;
            
            _slider.maxValue = _maxWater;
            _slider.value = _currentWater;
            _text.text = _currentWater + "/" + _maxWater;
            _slider.value = sliderVal;
        }
    }
}