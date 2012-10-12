namespace ChemTools {

	/// <summary> Parses equation strings into Equations </summary>
	public class EquationParser {
		/// <summary> Token that separates 2 sides of an equation. </summary>
		public const string EQUATION_TOKEN = "=";
		/// <summary> Token that separates 2 formulas. </summary>
		public const string TERM_TOKEN = "+";

		private string[] left, right;

		private EquationParser(string str) {
			//divides equations string into left and right sides
			//and further divides it into formula strings
			int middle = str.IndexOf(EQUATION_TOKEN);
			left = str.Substring(0, middle).Split(TERM_TOKEN.ToCharArray());
			right = str.Substring(middle + EQUATION_TOKEN.Length)
			.Split(TERM_TOKEN.ToCharArray());
		}

		//use FormulaParser to get the formulas and adds them into array
		private Equation Equation {
			get {
				Formula[] leftFormula = new Formula[left.Length];
				Formula[] rightFormula = new Formula[right.Length];
				for(int i = 0; i < left.Length; i++){
					leftFormula[i] = FormulaParser.ParseFormula(left[i].Trim());
				}
				for(int i = 0; i < right.Length; i++){
					rightFormula[i] = FormulaParser.ParseFormula(right[i].Trim());
				}
				return new Equation(leftFormula, rightFormula);
			}
		}

		/// <summary> Only method a program needs. </summary>
		public static Equation ParseEquation(string str){
			return new EquationParser(str).Equation;
		}
	}

}