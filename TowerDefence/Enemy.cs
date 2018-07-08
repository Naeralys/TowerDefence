using System;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : GameObject
    {
		float _health;
		int _checkPoint;
		int _type;
        
		public float Health { get => _health; set => _health = value; }
		public int Type { get => _type; set => _type = value; }

		public Enemy (int width, int height, int health) : base(800, 30, width, height)
        {
			_health = health;
			_checkPoint = 1;
			_type = health;
        }
        public override void Update()
		{
			CheckPoint ();
		}
        public override void Render()
		{
			SwinGame.FillRectangle (Color.White, PositionX, PositionY, Width, Height);
			SwinGame.DrawText (Health.ToString(), Color.Red, PositionX, PositionY);
		}
		public void CheckPoint()
		{
			if (_checkPoint == 1) {
				if (PositionX > 100) {
					PositionX--;
				} else {
					_checkPoint = 2;
				}
			} else if (_checkPoint == 2) {
				if (PositionY < 200) {
					PositionY++;
				} else {
					_checkPoint = 3;
				}
			} else if (_checkPoint == 3) {
				if(PositionX < 700) {
					PositionX++;
				} else {
					_checkPoint = 4;
				}
			} else if(_checkPoint == 4) {
				if (PositionY < 400) {
					PositionY++;
				} else {
					_checkPoint = 5;
				}
			} else if (_checkPoint == 5) {
				if (PositionX > -100) {
					PositionX--;
				} else {
					_checkPoint = 6;
				}
			}
		}
        public void Shoot(float damage)
		{
			Health -= damage;
		}
    }
}
