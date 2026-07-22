using System;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
	public static SettingManager Instance { get; private set; }

	[SerializeField, Range(0f, 1f)]
	private float _bgmVolume = 1f;

	[SerializeField, Range(0f, 1f)]
	private float _sfxVolume = 1f;

	[SerializeField, Range(0.1f, 5f)]
	private float _mouseSensitivity = 1f;

	public event Action<float> OnBgmVolumeChanged;
	public event Action<float> OnSfxVolumeChanged;
	public event Action<float> OnMouseSensitivityChanged;

	public float BgmVolume => _bgmVolume;
	public float SfxVolume => _sfxVolume;
	public float MouseSensitivity => _mouseSensitivity;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);

			Load();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SetBgmVolume(float value)
	{
		value = Mathf.Clamp01(value);

		if (Mathf.Approximately(_bgmVolume, value))
			return;

		_bgmVolume = value;
		PlayerPrefs.SetFloat(nameof(_bgmVolume), value);

		OnBgmVolumeChanged?.Invoke(value);
	}

	public void SetSfxVolume(float value)
	{
		value = Mathf.Clamp01(value);

		if (Mathf.Approximately(_sfxVolume, value))
			return;

		_sfxVolume = value;
		PlayerPrefs.SetFloat(nameof(_sfxVolume), value);

		OnSfxVolumeChanged?.Invoke(value);
	}

	public void SetMouseSensitivity(float value)
	{
		value = Mathf.Max(0.1f, value);

		if (Mathf.Approximately(_mouseSensitivity, value))
			return;

		_mouseSensitivity = value;
		PlayerPrefs.SetFloat(nameof(_mouseSensitivity), value);

		OnMouseSensitivityChanged?.Invoke(value);
	}

	private void Load()
	{
		_bgmVolume = PlayerPrefs.GetFloat(nameof(_bgmVolume), 1f);
		_sfxVolume = PlayerPrefs.GetFloat(nameof(_sfxVolume), 1f);
		_mouseSensitivity = PlayerPrefs.GetFloat(nameof(_mouseSensitivity), 1f);
	}
}