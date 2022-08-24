using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
	private string _filePath;
	private BinaryFormatter _formatter;

	public Storage()
	{
		var directory = Application.persistentDataPath + "/saves";
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
		_filePath = directory + "GameSave.save";
		InitBinaryFormatter();
	}



	public object Load(object saveDataByDefault)
	{
		if (!File.Exists(_filePath))
		{
			if (saveDataByDefault != null)
			{
				Save(saveDataByDefault);
			}
			return saveDataByDefault;
		}
		var file = File.Open(_filePath, FileMode.Open);
		var savedData = _formatter.Deserialize(file);
		file.Close();
		return savedData;
	}

	public void Save(object saveData)
	{
		var file = File.Create(_filePath);
		_formatter.Serialize(file, saveData);
		file.Close();
	}

	private void InitBinaryFormatter()
	{
		_formatter = new BinaryFormatter();
		var selector = new SurrogateSelector();

		var v3Surrogate = new Vector3SerializationSurrogate();
		var qSurrogate = new QuaternionSerializationSurrogate();

		selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
		selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);

		_formatter.SurrogateSelector = selector;
	}


}
