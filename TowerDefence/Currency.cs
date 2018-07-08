using System;
namespace MyGame
{
    public class Currency
    {
		int _value;
        
        public Currency ( int currency )
        {
			Value = currency;
        }

		public int Value { get => _value; set => _value = value; }

		public void Increment(int val)
		{
			Value += val;	
		}
        public void Spend(int val)
		{
			Value -= val;
		}
	}
}
