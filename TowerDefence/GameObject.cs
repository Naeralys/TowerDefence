using System;
namespace MyGame
{
    public abstract class GameObject
    {
		float _positionX;
		float _positionY;
		int _width;
		int _height;
		bool _selected;
        public GameObject (float positionX, float positionY, int width, int height)
        {
			_positionX = positionX;
			_positionY = positionY;
			_width = width;
			_height = height;
        }
		public float PositionY { get => _positionY; set => _positionY = value; }
		public float PositionX { get => _positionX; set => _positionX = value; }
		public int Width { get => _width; set => _width = value; }
		public int Height { get => _height; set => _height = value; }
		public bool Selected { get => _selected; set => _selected = value; }

		public abstract void Update ();
		public abstract void Render ();
	}
}
