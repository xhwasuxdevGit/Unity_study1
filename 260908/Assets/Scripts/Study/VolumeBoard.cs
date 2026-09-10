using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeBoard : MonoBehaviour
{
  [SerializeField] private Slider _volumeSlider;
  [SerializeField] private TextMeshProUGUI _volumeText;

  private void Start()
  {
    BindSliderEvents();
    
  }

  private void BindSliderEvents()
  {
    _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
  }

  private void OnVolumeChanged(float volume)
  {
    UpdateText(volume);
  }

  private void UpdateText(float volume)
  {
    _volumeText.text = "Volume " + volume.ToString();
  }
}
