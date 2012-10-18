using System.Text;
using System.Collections.Generic;

namespace ChemTools {

	/// <summary> A chemical formula like H2O, CO2, CH3COOH, etc. </summary>
	public class Formula {
		//Map that holds NElements
		//accessible like an array, but uses keys instead of integers
		//this map uses Elements as keys and holds NElements
		//Given Element e, an NElement ne can be saved as:
		//elementMap[e] = ne;
		//and can later be retrieved by using
		//elementMap[e]
		public readonly Dictionary<Element, NElements> elementMap = new Dictionary<Element, NElements>();

		/// <summary> Default empty formula </summary>
		public Formula() {}

		/// <summary> Copy constructor. </summary>
		/// <param name="f"> Formula to copy. </param>
		public Formula(Formula f) {
			MergeFormula(f);
		}

		/// <summary> Gets molar mass of the formula </summary>
		public double MolarMass {
			get {
				double mm = 0;
				foreach(NElements ne in elementMap.Values) {
					mm += ne.Number * ne.element.mass;
				}
				return mm;
			}
		}

		/// <summary> Merges this formula with other.
		/// Result is this object; other isn't affected. </summary>
		/// <example> H2O merged with H2 will result in H4O </example>
		public void MergeFormula(Formula other) {
			foreach(NElements ne in other.elementMap.Values) {
				Add(new NElements(ne));
			}
		}

		/// <summary> Multiplies each element in formula by a constant.
		/// Changes the formula itself, not the coefficient before the formula. </summary>
		/// <returns> This formula for chaining/convenience. </returns>
		/// <example> H2O Factor(2) results in H4O2, not 2H2O. </example>
		public Formula Factor(int x) {
			foreach(NElements ne in elementMap.Values) {
				ne.Number = ne.Number * x;
			}
			return this;
		}

		/// <summary> Adds one or more elements to the formula. </summary>
		/// <example> H2 Add(O) results in H2O </example>
		public void Add(NElements ne) {
			if(elementMap.ContainsKey(ne.element)) {
				NElements ne2 = elementMap[ne.element];
				ne2.Number += ne.Number;
			} else {
				elementMap.Add(ne.element, ne);
			}
		}

		/// <summary> Gets the number of elements in the formula. </summary>
		public int Size {
			get {
				return elementMap.Count;
			}
		}

		/// <returns> true iff other is a Formula and
		/// has the same number of each element </returns>
		public override bool Equals(object other) {
			if(other is Formula) {
				Formula f = (Formula) other;
				foreach(NElements ne in elementMap.Values) {
					if(!ne.Equals(f.elementMap[ne.element])) {
						return false;
					}
				}
				foreach(NElements ne in f.elementMap.Values) {
					if(!ne.Equals(elementMap[ne.element])) {
						return false;
					}
				}
				return true;
			}
			return false;
		}

		/// <returns> Integer representation of this
		///	object. Not guaranteed to be unique. </returns>
		public override int GetHashCode() {
			int hash = 0;
			foreach(NElements ne in elementMap.Values) {
				hash ^= ne.GetHashCode();
			}
			return hash;
		}

		/// <returns> All the element-number sets in any order. </returns>
		/// <example> H2O ToString() may return "H2O" or "O2H" </example>
		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			foreach(NElements ne in elementMap.Values) {
				sb.Append(ne);
			}
			return sb.ToString();
		}
	}

}
