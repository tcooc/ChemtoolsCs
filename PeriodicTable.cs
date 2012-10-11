/**
 * @author Steven Wang
**/
using System.Collections.Generic;

namespace ChemTools {

	/// <summary> Stores all the elements for reference </summary>
	public class PeriodicTable {
		const int NUMBER_ELEMENTS = 118;
		private Element[] elements;
		
		/// <param name="eList"> List of elements in any order. </param>
		public PeriodicTable(List<Element> eList) {
			elements = new Element[NUMBER_ELEMENTS];
			//sorts the elements in the array based on element number
			foreach(Element e in eList) {
				elements[e.Number - 1] = e;
			}
		}
		
		/// <summary> Uses the atomic number to get the corresponding Element </summary>
		public Element GetElementByAtomicNumber(int i){
			return elements[i - 1];
		}
		
		/// <summary> Uses the symbol to get the corresponding Element </summary>
		/// <example> GetElementBySymbol("He") returns a Element object that represents Helium </example>
		/// <returns> The elemenent object, or null if not found </returns>
		public Element GetElementBySymbol(string symbol) {
			foreach(Element e in elements) {
				if(e.Symbol.Equals(symbol)) {
					return e;
				}
			}
			return null;
		}
	}
	
}