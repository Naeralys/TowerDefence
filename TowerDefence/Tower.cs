using System;
using SwinGameSDK;
namespace MyGame
{
	public class Tower : GameObject
    {
		float _damage;
		Color _color;

		public float Damage { get => _damage; set => _damage = value; }

		public Tower (float positionX, float positionY, int width, int height, float damage) : base(positionX, positionY, width, height)
        {
			_damage = (damage / 10);
			_color = Color.Blue;
        }
        public override void Update()
		{
			Hover ();
			CheckIfSelected ();
			if(Selected) {
				_color = Color.Aqua;
			}
		}
        public override void Render()
		{
			SwinGame.DrawRectangle (Color.Grey, (PositionX - 50), (PositionY - 50), (Width + 100), (Height + 100));
			SwinGame.FillRectangle (_color, PositionX, PositionY, Width, Height);
			if (Selected)
				SwinGame.DrawText ("Damage: " + Damage, Color.Red, 700, 500);
		}
		public bool IsAt (Point2D pt)
        {
            return SwinGame.PointInRect (pt, PositionX, PositionY, Width, Height);
        }
		public void Hover ()
        {
            if (IsAt (SwinGame.MousePosition ())) {
                _color = Color.Green;
            } else {
                _color = Color.Red;
            }
        }
		public void CheckIfSelected ()
        {
            if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
                if (IsAt (SwinGame.MousePosition ())) {
                    Selected = true;
                } else {
                    Selected = false;
                }
            }
        }
        public void Upgrade()
		{
			Damage = Damage * 2;
		}
    }
}