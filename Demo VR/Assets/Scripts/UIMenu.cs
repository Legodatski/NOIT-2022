using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIMenu : MonoBehaviour
{
	private InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
	private InputDevice targetDevice;
	void Start()
	{
		TryInitialize();
	}
	void TryInitialize()
	{
		List<InputDevice> devices = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
		foreach (var item in devices)
		{
			Debug.Log(item.name + item.characteristics);
		}
		if (devices.Count > 0)
		{
			targetDevice = devices[0];
		}
	}
	// Update is called once per frame
	void Update()
	{
		targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
		if (primaryButtonValue)
			Debug.Log("Nigger pressed button");
	}
}
