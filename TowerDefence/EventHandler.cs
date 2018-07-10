using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    public class EventHandler
    {
		UI _ui;
		List<Button> _buttons;
		List<Tower> _towers;
		List<GameObject> _gameObjects;
		Currency _currency;
		public EventHandler (UI ui, List<Tower> towers, List<GameObject> gameObjects, Currency currency)
        {
			_ui = ui;
			_buttons = _ui.Buttons;
			_towers = towers;
			_gameObjects = gameObjects;
			_currency = currency;
        }
        public void CheckInput()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				foreach (Button btn in _buttons) {
					if (btn.Selected) {
						if (btn.Id == 1 && _currency.Value >= btn.Cost) {
							Point2D pt = SwinGame.MousePosition ();
							Tower tower = new Tower (pt.X, pt.Y, 20, 20, 1);
							_towers.Add (tower);
							_gameObjects.Add (tower);
							_currency.Spend (btn.Cost);
						}
						else if (btn.Id == 2 && _currency.Value >= btn.Cost) {
                            Point2D pt = SwinGame.MousePosition ();
                            Tower tower = new Tower (pt.X, pt.Y, 20, 20, 5);
                            _towers.Add (tower);
                            _gameObjects.Add (tower);
                            _currency.Spend (btn.Cost);
                        }
						else if (btn.Id == 3 && _currency.Value >= btn.Cost) {
                            Point2D pt = SwinGame.MousePosition ();
                            Tower tower = new Tower (pt.X, pt.Y, 20, 20, 25);
                            _towers.Add (tower);
                            _gameObjects.Add (tower);
                            _currency.Spend (btn.Cost);
                        }
						else if (btn.Id == 4 && _currency.Value >= btn.Cost) {
                            Point2D pt = SwinGame.MousePosition ();
                            Tower tower = new Tower (pt.X, pt.Y, 20, 20, 100);
                            _towers.Add (tower);
                            _gameObjects.Add (tower);
                            _currency.Spend (btn.Cost);
						} else if(btn.Id == 5 && _currency.Value >= btn.Cost) {
							foreach (Tower twr in _towers) {
                                if (twr.Selected) {
									_currency.Spend (btn.Cost);                           
									twr.Damage = twr.Damage * 2;
                                }
                            }
						}
					}  
				}            
			}
			bool towerSelected = false;         
            foreach (Tower twr in _towers) {
                if (twr.Selected) {
                    towerSelected = true;               
                }
            }
            if (towerSelected)
                _ui.TowerSelected = true;
            else
                _ui.TowerSelected = false;
		}
    }
}