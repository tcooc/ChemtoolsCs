/**
 * @author tcooc
**/
using System.Text;
	
namespace ChemTools {
	
	/// <summary>
	/// A chemical Element. Immutable.
	/// </summary>
	public class Element {
		//i.e. H
		private string symbol;
		//i.e. Hydrogen
		private string name;
		//atmoic number, i.e. 1
		private int number;
		//mass number i.e. 1.00784
		private double mass;
		
		//forces immutability
		/// <summary> Gets the symbol </summary>
		/// <example> returns He for helium </example>
		public string Symbol {
			get { return symbol; }
			private set {}
		}
		/// <summary> Gets the name </summary>
		/// <example> returns Carbon for carbon </example>
		public string Name {
			get {return name; }
			private set {}
		}
		/// <summary> Gets the number </summary>
		/// <example> returns 2 for helium </example>
		public int Number {
			get { return number; }
			private set {}
		}
		/// <summary> Gets the mass </summary>
		/// <example> returns 1 for hydrogen </example>
		public double Mass {
			get { return mass; }
			private set {}
		}

		/// <param name="symbol"> symbol of the element </param>
		/// <param name="name"> name of the element </param>
		/// <param name="number"> atomic number </param>
		/// <param name="mass"> atomic mass </param>
		/// <example> Usage: <c> new Element("H", "Hydrogen", 1, 1.00) </c> </example>
		public Element(string symbol, string name, int number, double mass) {
			this.symbol = symbol;
			this.name = name;
			this.number = number;
			this.mass = mass;
		}
		
		/// <returns> true iff other is an Element and has the same atomic number. </returns>
		public override bool Equals(object other) {
			if(other is Element) {
				return ((Element) other).number == number;
			}
			return false;
		}
		
		/// <returns> Unique integer representation of this element. </returns>
		public override int GetHashCode() {
			return number;
		}
		
		/// <returns> string in format "symbol,name,number,mass" </returns>
		public override string ToString() {
			return new StringBuilder(symbol)
			.Append(',').Append(name)
			.Append(',').Append(number)
			.Append(',').Append(mass).ToString();
		}
	}

}