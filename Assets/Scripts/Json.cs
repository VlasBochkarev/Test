using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class Json : MonoBehaviour
{

	private string _post = "Hello, my name is Vlas";

	private JsonFile _jsonFile = new JsonFile();
	private string _path;

	private void Start()
	{
		_path = Application.streamingAssetsPath + "/" + "test.json";
		_jsonFile = JsonUtility.FromJson<JsonFile>(File.ReadAllText(_path));
		Debug.Log($"Firs Name: {_jsonFile.FirstName}");
		Debug.Log($"Last Name: {_jsonFile.LastName}");
		Debug.Log($"Age: {_jsonFile.Age}");
	}



	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			StartCoroutine(GetDataCoroutine());
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			StartCoroutine(PostData());
		}
	}

	IEnumerator GetDataCoroutine()
	{
		string uri = "https://www.postman-echo.com/get";
		using (UnityWebRequest request = UnityWebRequest.Get(uri))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
	}

	IEnumerator PostData()
	{
		string uri = "https://www.postman-echo.com/post";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, _post))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
	}



}


