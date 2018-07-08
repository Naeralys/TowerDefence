using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    public class UI
    {
		List<Button> _buttons = new List<Button> ();
		Currency _currency;
		bool _towerSelected;
		public List<Button> Buttons { get => _buttons; set => _buttons = value; }
		public bool TowerSelected { get => _towerSelected; set => _towerSelected = value; }

		public UI (Currency currency)
        {
			AddButtons ();
			_currency = currency;
        }
        void AddButtons()
		{
			Button easyTower = new Button (100, 500, 50, 50, 1);
			Button mediumTower = new Button (200, 500, 50, 50, 2);
			Button hardTower = new Button (300, 500, 50, 50, 3);
			Button expertTower = new Button (400, 500, 50, 50, 4);
			Buttons.Add (easyTower);
			Buttons.Add (mediumTower);
			Buttons.Add (hardTower);
			Buttons.Add (expertTower);
			Button upgrade = new Button (600, 500, 50, 50, 5);
			upgrade.Shown = false;
            Buttons.Add (upgrade);
		}
        public void Update()
		{
			foreach(Button btn in Buttons) {
				btn.Update ();
			}
			TowerSelect ();
		}
		public void Render ()
		{
			foreach(Button btn in Buttons) {
				if(btn.Shown)
				    btn.Render ();
			}
			SwinGame.DrawText ("Currency: " + _currency.Value, Color.Red, 0, 0);
		}
		public void TowerSelect ()
        {
			foreach (Button btn in Buttons) {
				if (btn.Id == 5) {
					if (TowerSelected)
						btn.Shown = true;
					else
						btn.Shown = false;
			    }
			}
        }
    }
}
