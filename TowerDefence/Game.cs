using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    public class Game
    {
		bool _isRunning;
		int _spawnTime;
		int _difficulty;
		int _difficultyTimer;
		Currency _currency;
		List<GameObject> _gameObjects = new List<GameObject> ();
		List<Tower> _towers = new List<Tower> ();
		List<Enemy> _enemies = new List<Enemy> ();
		UI _ui;
		EventHandler _event;
		CollisionManager _collision;
        public Game (string windowTitle, int windowWidth, int windowHeight)
        {
			SwinGame.OpenGraphicsWindow (windowTitle, windowWidth, windowHeight);
			_isRunning = true;
			_difficulty = 1;
			SpawnEnemy ();
			_currency = new Currency (50);
			_ui = new UI (_currency);
			_event = new EventHandler (_ui, _towers, _gameObjects, _currency );
			_collision = new CollisionManager (_towers, _enemies, _gameObjects, _currency);
        }
		public bool IsRunning { 
			get { 
				if(SwinGame.WindowCloseRequested()) {
					_isRunning = false;
				}
				return _isRunning;
			}
		}
        public void Update()
		{
			_spawnTime++;
			if(_spawnTime > 60) {
				_spawnTime = 0;
				SpawnEnemy ();
			}
			SwinGame.ProcessEvents ();
			foreach (GameObject obj in _gameObjects) {
				obj.Update ();
			}
			GarbageCollect ();
			_event.CheckInput ();
			_ui.Update ();
			_collision.CheckCollision ();
		}
        public void Render()
		{
			SwinGame.ClearScreen (Color.Black);
			foreach(GameObject obj in _gameObjects) {
				obj.Render ();
			}
			_ui.Render ();
			SwinGame.RefreshScreen ();         
		}
		public void SpawnEnemy ()
		{
			_difficultyTimer++;
			if (_difficultyTimer > 10) {
				_difficulty++;
				_difficultyTimer = 0;
			}
			Enemy enemy;
			switch (_difficulty) {
			case 1: 
        		enemy = new Enemy (20, 20, 5);
				break;
			case 2:
				enemy = new Enemy (20, 20, 20);
				break;
			case 3:
                enemy = new Enemy (20, 20, 50);
                break;
			case 4:
                enemy = new Enemy (20, 20, 150);
                break;
			case 5:
                enemy = new Enemy (20, 20, 250);
                break;
			case 6:
                enemy = new Enemy (20, 20, 500);
                break;
			case 7:
                enemy = new Enemy (20, 20, 1000);
                break;
			case 8:
                enemy = new Enemy (20, 20, 2000);
                break;
			case 9:
                enemy = new Enemy (20, 20, 4000);
                break;
			default:
				enemy = new Enemy (20, 20, 5);
				break;
		    }
			_gameObjects.Add (enemy);
            _enemies.Add (enemy);
			Console.WriteLine (_difficulty);
		}
		public void GarbageCollect()
		{
            GameObject removeObj = null;
            foreach (GameObject o in _gameObjects) {
                if (o.PositionX < 0)
                    removeObj = o;
            }
            if (removeObj != null)
                _gameObjects.Remove (removeObj);
		}
    }
}