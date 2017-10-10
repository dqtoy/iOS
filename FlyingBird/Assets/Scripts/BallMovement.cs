using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyBird
{
	public class BallMovement : MonoBehaviour {

		// Use this for initialization
		void Start () {
			random = new System.Random();
			ScreenTapped = BallMoved = false;
			gameObstacleCollection = new ObjectCollection ("Obstacle1", "Obstacle2", "Obstacle3");
			animalCollection = new ObjectCollection ("cow", "sheep", "pig");
			CornObject = Resources.Load<GameObject> ("corn");
			ReStartButtonTexture = GetTexture("RestartGame");
			TapToStartButtonTexture = GetTexture("TapToStart");
			GameOverTexture = GetTexture("GameOver");
			BombTexture = GetTexture ("Drop");
			TitleTexture = GetTexture ("Title");
			EggObject = Resources.Load<GameObject>("Egg");
			BombTexture.enabled = false;
			ReStartButtonTexture.enabled = false;
			TapToStartButtonTexture.enabled = true;
			GameOverTexture.enabled = false;
			TitleTexture.enabled = false;
			BirdAnimator = gameObject.GetComponent<Animator> ();
			rigidbody.isKinematic = true;
			LoadScoreTextures ();
			
			Main.SetGuiTextureInset (BombTexture);
			Main.SetGuiTextureInset (TapToStartButtonTexture);
			Main.SetGuiTextureInset (ReStartButtonTexture);
			Main.SetGuiTextureInset (GameOverTexture);
			Main.SetGuiTextureInset (TitleTexture);


			if (Main.Handedness == HandednessType.Left) 
			{
				BombTexture.pixelInset = new Rect(0, 10, BombTexture.pixelInset.width, BombTexture.pixelInset.height);
			}
			if (random.Next (100) % 2 == 0) {
				var bg = GameObject.Find ("BG1");
				if (bg != null) bg.renderer.enabled = false;
			}
			if (Main.CurrentSong != "" && MusicPlayer.instance != null && !MusicPlayer.instance.GetComponent<AudioSource>().isPlaying)
				MusicPlayer.PlaySound (Main.CurrentSong, true);
		}

		void LoadScoreTextures()
		{
			scoreCollection = new ObjectCollection ();
			for (int i=0; i<10; ++i) {
				Texture texture =  Resources.Load<Texture>(i.ToString());
				GameObject text0 = new GameObject ("Score0" + i.ToString());
				text0.AddComponent<GUITexture>();
				text0.guiTexture.texture = texture;
				text0.transform.position = new Vector3(0.1f, 0.9f, 0);
				text0.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				text0.guiTexture.enabled = false;
				scoreCollection.Add(text0);
			}
			for (int i=0; i<10; ++i) {
				Texture texture =  Resources.Load<Texture>(i.ToString());
				GameObject text0 = new GameObject ("Score1" + i.ToString());
				text0.AddComponent<GUITexture>();
				text0.guiTexture.texture = texture;
				text0.transform.position = new Vector3(0.2f, 0.9f, 0);
				text0.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				text0.guiTexture.enabled = false;
				scoreCollection.Add(text0);
			}
			scoreCollection.Find (go => go.name == "Score00").guiTexture.enabled = true;
		}

		void LoadEggTextures()
		{
			EggObject.renderer.material.mainTexture = Resources.Load<Texture>(string.Format("egg_color{0}", random.Next(100) % 3));
		}

		void SetScore(int score)
		{
			// disable all scores first
			scoreCollection.Where (go => go.guiTexture.enabled).ToList ().ForEach (go => go.guiTexture.enabled = false);
			string scr = score.ToString ();
			if (scr.Length == 2) {
				scoreCollection.Find (go => go.name == "Score1" + scr [1].ToString ()).guiTexture.enabled = true;
			}
			scoreCollection.Find (go => go.name == "Score0" + scr [0].ToString ()).guiTexture.enabled = true;
			
		}

		Animator BirdAnimator;
		GUITexture GetTexture(string name)
		{
			return (GUITexture)GameObject.Find (name).GetComponent<GUITexture> ();;
		}

		System.Random random;
		string RandomBackgroundName
		{
			get{
				return string.Format("BG0", random.Next(100) % 3  );
				}
		}

		public bool ScreenTapped, BallMoved, BombTouched;
		GUITexture ReStartButtonTexture, TapToStartButtonTexture, GameOverTexture, BombTexture, TitleTexture;
		GameObject BackgroundObject, EggObject, CornObject;
		ObjectCollection gameObstacleCollection, animalCollection, scoreCollection, eggCollection;
		public static float MinZ = -15;
		public float Speed = 4.5f;

		bool touched, touchReleased;
		// Update is called once per frame
		void Update () {

			if (Main.IsiDevice) {
				if (touched && Input.touchCount == 0)
				{
					touchReleased = true;
					touched = false;
				}
				if (!touched && Input.touchCount > 0)
				{
					touched = true;
					touchReleased = false;
				}
			} else {
				if (touched && Input.GetMouseButtonUp(0))
				{
					touchReleased = true;
					touched = false;
				}
				if (!touched && Input.GetMouseButtonDown(0))
				{
					touched = true;
					touchReleased = false;
				}
			}

			if (!BallMoved && !ScreenTapped) {
				if (touched)
				{
					if (!Main.GameStarted)
					{
						MyBird.Main.StartGame();
						rigidbody.isKinematic = false;
						AdBinding.destroyAdBanner();
						TapToStartButtonTexture.enabled = false;
						BombTexture.enabled = true;
					}
					ScreenTapped = true;
					Main.SetFlightTime();
					rigidbody.velocity = Vector3.zero;
					if (!Main.GameEnded)
					{
						MusicPlayer.PlaySound(SoundType.Flap);
						BirdAnimator.SetBool ("Flying", true);
						BirdAnimator.SetBool ("Running", false);
					}
				}
			} 
			if (touchReleased)
			{
				ScreenTapped = false;
				BallMoved = false;
			}
			// Process Menu clicks
			if (touched) {
				bool restartClick = Main.IsTextureTouched(ReStartButtonTexture);
				BombTouched = Main.TimeSinceBombed > 0.5f && Main.IsTextureTouched(BombTexture);
				if (Main.GameEnded && Main.IsTextureTouched(TitleTexture))
				{
					Main.RestartGame();
					AutoFade.LoadLevel("Title");
				}
				if (restartClick)
				{						
					Main.RestartGame();
					AutoFade.LoadLevel("Level");
				}
			}
		}

		float velocitySpeed = 4.5f;
		void FixedUpdate()
		{
			if (((Main.IsiDevice && Main.IsInFlight) || ScreenTapped) && !BallMoved && !Main.GameEnded) {
				if (!Main.IsiDevice || !Main.IsInFlight)
				{
					BallMoved = true;
				}
				rigidbody.velocity = velocitySpeed * Vector3.up;
			}
			if (!Main.GameEnded && BombTouched) 
			{
				Instantiate(EggObject, gameObject.transform.position, Quaternion.identity);
				LoadEggTextures();
				BombTouched = false;
				Main.SetBombTime();
			}
			if (!Main.GameEnded && Main.GameRunning) {
				UpdateObstacles();
				UpdateAnimals();
				Main.IncreaseGameSpeed ();
				if (Main.ScoreUpdated)
				{
					SetScore(Main.Score);
					Main.ScoreUpdated = false;
				}
			}
			if (Main.GameEnded && Main.TimeSinceGameOver > 2) 
			{
				ReStartButtonTexture.enabled = TitleTexture.enabled = true;
				if (random.Next (100) % 2 == 0)
					AdBinding.initializeInterstitial ();
			}

		}

		float StartingObstacleZ = 9, StartingObstacleX = 0 , SpacingY1 = 3, SpacingY2 = 3.5f;
		float ObstacleLoadedTime = 0;
		void UpdateObstacles()
		{
			DestroyObjectsWithTag ("Obstacle");
			if (Main.TimeInLevel - ObstacleLoadedTime > Main.ObstacleLoadTime) {
				float y = 0;
				float SpacingY = random.Next(100) % 2 == 0 ? SpacingY1 : SpacingY2;
				var go1 = (GameObject)Instantiate(gameObstacleCollection.GetObjects(random), new Vector3(StartingObstacleX, y, StartingObstacleZ), Quaternion.identity);
				var corn = (GameObject)Instantiate(CornObject, new Vector3(StartingObstacleX, y + 2, StartingObstacleZ), Quaternion.identity);
				var go2 = (GameObject)Instantiate(gameObstacleCollection.GetObjects(random), new Vector3(StartingObstacleX, y + SpacingY, StartingObstacleZ), Quaternion.identity);
				RemoveCollider(go1);
				RemoveCollider(go2);
				ObstacleLoadedTime = Time.timeSinceLevelLoad;
			}

		}

		void RemoveCollider(GameObject go)
		{
			var col = go.GetComponent<BoxCollider> ();
			if (col != null)
								col.enabled = false;
		}

		float AnimalLoadedTime = 0;
		void UpdateAnimals()
		{
			DestroyObjectsWithTag ("Animal");
			DestroyObjectsWithTag ("Corn");
			if (Main.TimeInLevel - AnimalLoadedTime > Main.AnimalLoadTime) {
				float y = 0;
				GameObject go = (GameObject)Instantiate(animalCollection.GetObjects(random), new Vector3(gameObject.transform.position.x, y, StartingObstacleZ), Quaternion.identity);
				go.transform.RotateAround(go.transform.position, Vector3.up, 90);
				AnimalLoadedTime = Time.timeSinceLevelLoad;
			}
		}

		void DestroyObjectsWithTag(string tag)
		{
			// get all current obstacles, if less than MinZ then get rid of it
			GameObject.FindGameObjectsWithTag (tag).ToList().Where(go => go.transform.position.z < MinZ).ToList().ForEach(go =>   Destroy (go));
		}

		void OnTriggerEnter(Collider other) {
			if (Main.GameRunning && !Main.GameEnded) {
				if (other.gameObject.tag == "Obstacle")
				{
					HitDead();
				}
				if (other.gameObject.tag == "Egg")
					rigidbody.velocity = Vector3.zero;
				if (other.gameObject.tag == "Corn")
				{
					other.gameObject.GetComponent<Animator>().SetBool("Idle", false);
					other.gameObject.GetComponent<Animator>().SetBool("Dead", true);
					Main.UpdateScore();
				}
			}
		}

		void OnCollisionEnter(Collision collision) {
			if (Main.GameEnded || !Main.GameRunning)
					return;
			if (collision.gameObject.tag == "Floor") {
				BirdAnimator.SetBool ("Flying", false);
				BirdAnimator.SetBool ("Running", true);
				rigidbody.velocity = Vector3.zero;
				if (Main.GameEnded)
					rigidbody.isKinematic = true;

			}
			if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Animal")
			{
				HitDead();
			}
		}
		
		void HitDead()
		{
			GameEnded();
			BirdAnimator.SetBool ("Flying", false);
			BirdAnimator.SetBool ("Running", false);
			BirdAnimator.SetBool ("Dead", true);
			rigidbody.velocity = Vector3.zero;
		}
		
		void GameEnded()
		{
			MyBird.Main.EndGame();
			GameOverTexture.enabled = true;
			BombTexture.enabled = false;
			MusicPlayer.PlaySound(SoundType.Explosion);
			AdBinding.createAdBanner (true);
		}
	}

	
	public class ObstacleCollection : List<float>
	{
		private static ObstacleCollection instance = null;
		public static ObstacleCollection Instance { 
			get{
				return instance ?? (instance = new ObstacleCollection());
			}
		}
		
		public float GetNextObstacle()
		{
			if (CurrentIndex >= this.Count) 
				CurrentIndex = 0;
			return this [CurrentIndex++];
		}
		
		public ObstacleCollection()
		{
			CurrentIndex = 0;
			Clear ();
			Add (1.0f);
			Add (1.2f);
			Add (0.4f);
			Add (2.8f);
			Add (1.3f);
			Add (1.9f);
			Add (1.5f);
		}
		
		int CurrentIndex ;
	}

	public class ObjectCollection : List<GameObject>
	{
		public ObjectCollection(params string[] list)
		{
			for (int i=0; i<list.Length; ++i)
				this.Add ((GameObject)Resources.Load (list[i]));
		}
		
		public GameObject GetObjects(System.Random rand)
		{

			return this.Count > 0 ? this [rand.Next (100) % this.Count] : null;
		}

	}
}










