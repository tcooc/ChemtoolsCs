/**
 * @author tcooc
**/
using System.Text;
	
namespace ChemTools {

	/// <summary> Represents a number of elements </summary>
	public class NElements {

		private int n;
		private Element element;

		/// <param name="n"> Number </param>
		/// <param name="e"> The Element </param>
		public NElements(int n, Element e) {
			this.n = n;
			element = e;
		}

		/// <summary> Copy constructor. </summary>
		/// <param name="ne"> The NElement to copy. </param>
		public NElements(NElements ne) : this(ne.n, ne.element) {}

		/// <summary> Amount of the element. </summary>
		public int Number {
			get {
				return n;
			}
			set {
				n = value;
			}
		}

		/// <summary> Gets the element. </summary>
		public Element Element {
			get {
				return element;
			}
			private set { }
		}

		/// <returns> true iff other is an NElement,
		/// has the same Number, and the same Element </returns>
		public override bool Equals(object other){
			if(other is NElements) {
				NElements ne = (NElements) other;
				return n == ne.n && element.Equals(ne.element);
			}
			return false;
		}

		/// <returns> Integer representation
		/// of this object. Not guaranteed unique. </returns>
		public override int GetHashCode() {
			return element.GetHashCode() ^ n;
		}

		/// <returns> Symbol + Number (if Number is not 1) </returns>
		public override string ToString() {
			string number = (n == 1 ? "" : n.ToString());
			return new StringBuilder(element.Symbol).Append(number).ToString();
		}

	}

}