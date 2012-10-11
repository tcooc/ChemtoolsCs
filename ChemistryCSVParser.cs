/**
 * @author tcooc
**/
using System;
using System.Text;
using System.Collections.Generic;

namespace ChemTools {

	/// <summary>
	/// Parses very simple comma separated values in the format int,double,string,string,
	/// which corresponds to number, mass, name, symbol
	/// </summary>
	public class ChemistryCSVParser {

		/// <summary>
		/// Only method that needs to be used by a program.
		/// returns a <c>System.Collections.Generic.List&lt;Element&gt;</c> of the outputted elements.
		/// </summary>
		/// <example>
		/// Usage:
		/// <c>
		/// input = "1,2.00,Hydrogen,H";
		/// List&lt;Element&gt; elements = ChemistryCSVParser.ParseString(input);
		/// Console.WriteLine(elements.Length); //prints "1"
		/// Console.WriteLine(elements[0].symbol); //prints "H"
		/// Console.WriteLine(elements[0].masss); //prints "1.00"
		/// </c>
		/// </example>
		public static List<Element> ParseString(string str) {
			//make an instance of this class and operate on it in order to be thread-safe
			return new ChemistryCSVParser(str).Parse();
		}

		//reference to the original input string
		private string input;
		//the posiion of the next character in the string
		private int nextIndex;
		
		private ChemistryCSVParser(string str){
			input = str;
			nextIndex = 0;
		}

		//actually does the parsing
		//reads the data, creates a new Element, and adds it to the output list
		private List<Element> Parse() {
			List<Element> elements = new List<Element>();
			int number;
			double mass;
			string name, symbol;
			while(nextIndex < input.Length) {
				number = int.Parse(ReadValue());
				mass = double.Parse(ReadValue());
				name = ReadValue();
				symbol = ReadValue();
				elements.Add(new Element(symbol, name, number, mass));
			}
			return elements;
		}

		//reads from nextIndex until a comma (,) is reached
		//and returns that string (updating nextValue)
		//i.e. nextIndex=0, ReadValue on "this,is,a,string" would return "this"		
		private string ReadValue() {
			StringBuilder sb = new StringBuilder();
			char c = input[nextIndex++];
			while(nextIndex < input.Length && c != ',') {
				sb.Append(c);
				c = input[nextIndex++];
			}
			return sb.ToString();
		}
	}
	
}