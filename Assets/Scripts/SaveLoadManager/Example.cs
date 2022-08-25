using UnityEngine;
public class Example : MonoBehaviour
{
	public GameObject Cube;

	private Storage Storage;
	private GameData GameData;


	private void Start()
	{
		Storage = new Storage();
		Load();

	}

	private void Update()
	{
		Save();

		if (Input.GetKeyDown(KeyCode.L))
		{
			Load();
		}
	}

	private void Save()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			GameData.Score = DestroyerRock.UpdateScore;
			GameData.Position = Cube.transform.position;
			GameData.Rotation = Cube.transform.rotation;
			Storage.Save(GameData);
			Debug.Log($"Save Game{Application.persistentDataPath}");
		
		}
	}

	private void Load()
	{
		GameData = (GameData)Storage.Load(new GameData());
		Cube.transform.position = GameData.Position;
		Cube.transform.rotation = GameData.Rotation;
		UIManager.Score = GameData.Score;
		Debug.Log($"Loaded score GameData.Score = {GameData.Score}");
	}
}
