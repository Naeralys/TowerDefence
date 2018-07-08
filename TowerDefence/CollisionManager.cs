using System;
using System.Collections.Generic;
namespace MyGame
{
    public class CollisionManager
    {
		List<Tower> _towers;
		List<Enemy> _enemies;
		List<GameObject> _gameObjects;
		Currency _currency;
		public CollisionManager (List<Tower> towers, List<Enemy> enemies, List<GameObject> gameObjects, Currency currency)
        {
			_towers = towers;
			_enemies = enemies;
			_gameObjects = gameObjects;
			_currency = currency;
        }
        public void CheckCollision()
		{
			Enemy killEnemy = null;
			foreach(Tower tower in _towers) {
				foreach(Enemy enemy in _enemies) {
					if ((enemy.PositionX + 20) > (tower.PositionX - 50) && enemy.PositionX < (tower.PositionX + 50) && (enemy.PositionY + 20) > (tower.PositionY - 50) && enemy.PositionY < (tower.PositionY + 50)) {
						enemy.Shoot (tower.Damage);
						if(enemy.Health < 1) {
							killEnemy = enemy;
							_currency.Increment(enemy.Type);
						}
					}
				}
			}
			if (killEnemy != null) {
				_enemies.Remove (killEnemy);
				_gameObjects.Remove (killEnemy);
			}
		}
        
    }
}
