using GameAssets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
namespace GameAssets.Scripts.UI
{
    public class OptionsMenuUI : MonoBehaviour
    {
        [SerializeField] private Button returnToMainMenuButton;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Slider vfxSoundSlider;
        private void Start()
        {
            soundSlider.maxValue = 100;
            soundSlider.minValue = 0;
            vfxSoundSlider.minValue = 0;
            vfxSoundSlider.maxValue = 100;
            
            HandleMainMenuButton();
            HandleSoundSlider();
            HandleVfxSoundSlider();
        }
        private void HandleMainMenuButton()
        {
            returnToMainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToMainMenu();
            }).AddTo(gameObject);
        }
        private void HandleSoundSlider()
        {
            //
            soundSlider.OnValueChangedAsObservable().Subscribe(_ =>
            {
                // SoundManager. AudioSourcetan sesi kısarız.
            }).AddTo(gameObject);
        }
        private void HandleVfxSoundSlider()
        {
            vfxSoundSlider.OnValueChangedAsObservable().Subscribe(_ =>
            {
                // VfxManagerdan 5efekt seslerini kısarız.    
            }).AddTo(gameObject);
        } 
    }
}
