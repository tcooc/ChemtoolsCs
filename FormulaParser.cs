/**
 * @author Steven Wang
**/
using System.Text;

namespace ChemTools {

	/// <summary>
	/// Class for parsing strings to Formulas.
	/// </summary>
	public class FormulaParser {
		
		//the input string broken down into a character array
		private char[] chars;
		//index of next character
		private int next;
		
		private FormulaParser(string str) {
			next = 0;
			chars =  str.ToCharArray();
		}

		//gets a Formula starting from next
		//hydrates arent handled
		private Formula GetFormula() {
			Formula formula = new Formula();
			while(Check()) {
				//end inner formula, return this
				if(chars[next] == ')') {
					Next();
					return formula;
				}
				//start inner formula
				else if(chars[next] == '(') {
					Next();
					//gets formula
					Formula f1 = GetFormula();
					//gets the number after the closing parens
					//i.e. get 7 from (CO2)7
					int n = GetNumber();
					//adds it to the main formula
					formula.MergeFormula(f1.Factor(n));
				}
				//start symbol
				else if (char.IsUpper(chars[next])){
					Element e = GetSymbol();
					if(e == null) {
						continue;
					}
					int n = GetNumber();
					formula.Add(new NElements(n, e));
				//error or end of data
				} else {
					break;
				}
			}
			return formula;
		}

		//gets an Element from a symbol starting from next
		private Element GetSymbol() {
			StringBuilder sb = new StringBuilder();
			if(Check() && char.IsUpper(chars[next])){
				sb.Append(chars[next]);
				while(char.IsLower(Next())) {
					sb.Append(chars[next]);
				}
				return ChemTools.Table.GetElementBySymbol(sb.ToString());
			}
			return null;
		}

		//gets a number (integer) that starts from next
		private int GetNumber() {
			StringBuilder sb = new StringBuilder();
			if(Check() && char.IsDigit(chars[next])){
				sb.Append(chars[next]);
				while(char.IsDigit(Next())) {
					sb.Append(chars[next]);
				}
				return int.Parse(sb.ToString());
			}
			return 1;
		}

		//returns true if next is within bounds
		//and the next character is not a space
		private bool Check() {
			return next < chars.Length && chars[next] != ' ';
		}

		//gets the next character
		//increments the index (next)
		private char Next() {
			next++;
			if(next >= chars.Length) {
				return (char) 0;
			}
			return chars[next];
		}
		
		/// <summary> Only method needed to be used by a program. </summary>
		/// <example>
		/// Usage:
		/// <c>
		/// string input = "H2SO4";
		/// Formula f = FormulaParser.ParseFormula(input);
		/// Console.WriteLine(f); //prints "H2O4S" (sorted by atomic number)
		/// input = "CH3COOH";
		/// f = FormulaParser.ParseFormula(input);
		/// Console.WriteLine(f); //prints "H4C2O2"
		/// input = "Na(NO3)2";
		/// f = FormulaParser.ParseFormula(input);
		/// Console.WriteLine(f); //prints "N2O6Na"
		/// </c>
		/// </example>
		public static Formula ParseFormula(string str){
			//instantiates class to be thread-safe
			return new FormulaParser(str).GetFormula();
		}
	}
	
}