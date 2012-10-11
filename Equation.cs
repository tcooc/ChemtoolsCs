/**
 * @author Steven Wang
**/
using System.Text;

namespace ChemTools {

	/// <summary> represents a chemical equation, with reactants on the left
	/// and products on the right, including coefficients for both </summary>
	public class Equation {
		
		private Formula[] left;
		/// <summary> Array of integers for the left coefficients. </summary>
		public int[] leftCoeff;
		private Formula[] right;
		/// <summary> Array of integers for the right coefficients. </summary>
		public int[] rightCoeff;
		
		/// <summary> Returns the left side of the equation </summary>
		public Formula[] Left {
			get { return left;}
			private set {}
		}
		/// <summary> Returns the right side of the equation </summary>
		public Formula[] Right {
			get { return right; }
			private set {}
		}

		/// <param name="l"> Left side. </param>
		/// <param name="r"> Right side. </param>
		public Equation(Formula[] l, Formula[] r) {
			left = new Formula[l.Length];
			leftCoeff = new int[l.Length];
			right = new Formula[r.Length];
			rightCoeff = new int[r.Length];
			//copies the formulas instead of referencing
			//(reduces side-effects of using Equation class)
			for(int i = 0; i < l.Length; i++) {
				left[i] = new Formula(l[i]);
				leftCoeff[i] = 1;
			}
			for(int i = 0; i < r.Length; i++) {
				right[i] = new Formula(r[i]);
				rightCoeff[i] = 1;
			}
		}

		/// <summary> Copy constructor </summary>
		public Equation(Equation eq) : this(eq.left, eq.right) {
			for(int i = 0; i < leftCoeff.Length; i++) {
				leftCoeff[i] = eq.leftCoeff[i];
			}
			for(int i = 0; i < rightCoeff.Length; i++) {
				rightCoeff[i] = eq.rightCoeff[i];
			}
		}

		//returns an equivalent formula that takes into account all
		//formulas and coefficients
		//i.e. [O2,2H2] results in H4O2
		private static Formula CountMolecules(Formula[] formulas, int[] coeff) {
			Formula f = new Formula();
			for(int i = 0; i < formulas.Length; i++) {
				//creates new equivalent formula without coefficient
				Formula f2 = new Formula(formulas[i]);
				//merges the formula into f
				f.MergeFormula(f2.Factor(coeff[i]));
			}
			return f;
		}
		
		/// <summary> Counts the number of all elements in the left side,
		///	taking into account the coeficients before the formulas </summary>
		/// <returns> Formula that contains the count. </returns>
		public Formula CountMoleculesLeft() {
			return CountMolecules(left, leftCoeff);
		}
		
		/// <summary> Counts the number of all elements in the right side,
		///	taking into account the coeficients before the formulas </summary>
		/// <returns> Formula that contains the count. </returns>
		public Formula CountMoleculesRight() {
			return CountMolecules(right, rightCoeff);
		}

		/// <summary> Returns true iff the equation is balanced </summary>
		public bool IsBalanced() {
			return CountMoleculesLeft().Equals(CountMoleculesRight());
		}

		
		/// <returns> String in form n1X1+n2X2+...=naXa+nbXb+... X1, Xa, ... are the formulas
		/// ant n1, na, ... are the coefficients (or blank if the coefficient is 1) </returns>
		/// <example> H2+O2=2H2O ToString() returns "H2+O2=2H2O" </example>
		public override string ToString() {
			string[] strLeft = new string[left.Length];
			string[] strRight = new string[right.Length];
			for(int i = 0; i < left.Length; i++) {
				if(leftCoeff[i] == 1) {
					strLeft[i] = left[i].ToString();
				} else {
					strLeft[i] = leftCoeff[i] + left[i].ToString();
				}
			}
			for(int i = 0; i < right.Length; i++) {
				if(rightCoeff[i] == 1) {
					strRight[i] = right[i].ToString();
				} else {
					strRight[i] = rightCoeff[i] + right[i].ToString();
				}
			}
			return new StringBuilder().Append(DeepToString(strLeft))
			.Append(EquationParser.EQUATION_TOKEN).Append(DeepToString(strRight)).ToString();
		}

		//helper method for converting string arrays into strings
		private static string DeepToString(string[] arrStr) {
			StringBuilder sb =  new StringBuilder();
			bool init = false;
			for(int i = 0; i < arrStr.Length; i++) {
				if(init) {
					sb.Append(EquationParser.TERM_TOKEN);
				}
				sb.Append(arrStr[i].ToString());
				init = true;
			}
			return sb.ToString();
		}
	}
	
}