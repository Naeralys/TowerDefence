using System;
using SwinGameSDK;
namespace MyGame
{
	public class Button : GameObject
    {
		int _id;
		Color _color;
		int _cost;
		bool _shown;

		public int Id { get => _id; set => _id = value; }
		public int Cost { get => _cost; set => _cost = value; }
		public bool Shown { get => _shown; set => _shown = value; }

		public Button (float positionX, float positionY, int width, int height, int id) : base(positionX, positionY, width, height)
        {
			_shown = true;
			_color = Color.Red;
			_id = id;
			switch(_id) {
			case 1:
				Cost = 50;
				break;
			case 2:
				Cost = 500;
				break;
			case 3:
				Cost = 2500;
				break;
			case 4:
				Cost = 10000;
				break;
			}
        }
        public override void Render()
		{
			SwinGame.FillRectangle (_color, PositionX, PositionY, Width, Height);
			SwinGame.DrawText (Cost.ToString(), Color.Yellow, (PositionX + 15), (PositionY + 20));
		}
		public override void Update ()
		{
			CheckIfSelected ();
			Hover ();
			if(Selected) {
				_color = Color.Aqua;
			}
		}
        public bool IsAt(Point2D pt)
		{
			return SwinGame.PointInRect (pt, PositionX, PositionY, Width, Height);
		}
        public void Hover()
		{
			if(IsAt(SwinGame.MousePosition())) {
				_color = Color.Green;
			} else {
				_color = Color.Red;
			}
		}
        public void CheckIfSelected()
		{
			if(SwinGame.MouseClicked(MouseButton.LeftButton)) {
				if(IsAt(SwinGame.MousePosition())) {
					Selected = true;
				} else {
					Selected = false;
				}
			}
		}
	}
}