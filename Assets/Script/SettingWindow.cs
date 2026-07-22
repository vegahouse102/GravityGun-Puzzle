using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
	SettingManager _settingManager;
	[SerializeField]
	Slider _bgm;
	[SerializeField]
	Slider _sfx;
	[SerializeField]
	Slider _sensitivity;

	[SerializeField]
	AudioMixer _audioMixer;


	[SerializeField]
	GameObject _window;
	[SerializeField]
	PlayerInputGetter _input;
	void Start()
	{
		_settingManager = SettingManager.Instance;
		_bgm.value = _settingManager.BgmVolume;
		_sfx.value = _settingManager.SfxVolume;
		_sensitivity.value = _settingManager.MouseSensitivity/5f;

		_audioMixer.SetFloat("BGM",ValueToDB(_bgm.value));
		_audioMixer.SetFloat("SFX", ValueToDB(_sfx.value));
	}
	private void Update()
	{
		if (_input.Input.Player.Setting.WasPressedThisFrame())
		{
			_window.SetActive(!_window.activeSelf);
			if (_window.activeSelf)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}


	private float ValueToDB(float value01)
	{
		value01 = Mathf.Max(value01, 0.0001f);
		return 20 * Mathf.Log10(value01);
	}
	// Update is called once per frame


	public void SetBGM(float value01)
	{
		_audioMixer.SetFloat("BGM", ValueToDB(_bgm.value));
		_settingManager.SetBgmVolume(value01);
	}
	public void SetSFX(float value01)
	{
		_audioMixer.SetFloat("SFX", ValueToDB(_sfx.value));
		_settingManager.SetSfxVolume(value01);
	}
	public void SetSensitivity(float value)
	{
		_settingManager.SetMouseSensitivity(value*5);
	}

}
