using System;
using System.Collections.Generic;

namespace ChemTools {

	/// <summary> Main class for the program. </summary>
	public class ChemTools {
		/// <summary> Standard data on elements 1 through 118.
		/// Formatted as a CSV with (number,mass,name,symbol) "columns"</summary>
		public const string ELEMENT_DATA = "1,1.0079400000,Hydrogen,H,2,4.0026020000,Helium,He,3,6.9410000000,Lithium,Li,4,9.0121820000,Beryllium,Be,5,10.8110000000,Boron,B,6,12.0107000000,Carbon,C,7,14.0067000000,Nitrogen,N,8,15.9994000000,Oxygen,O,9,18.9994000000,Fluorine,F,10,20.1797000000,Neon,Ne,11,22.9897692800,Sodium,Na,12,24.3050000000,Magnesium,Mg,13,26.9815386000,Aluminium,Al,14,28.0855000000,Silicon,Si,15,30.9737620000,Phosphorus,P,16,32.0650000000,Sulphur,S,17,35.4530000000,Chlorine,Cl,18,39.9480000000,Argon,Ar,19,39.0983000000,Potassium,K,20,40.0780000000,Calcium,Ca,21,44.9559120000,Scandium,Sc,22,47.8670000000,Titanium,Ti,23,50.9415000000,Vanadium,V,24,51.9961000000,Chromium,Cr,25,54.9380450000,Manganese,Mn,26,55.8450000000,Iron,Fe,27,58.9331950000,Cobalt,Co,28,58.6934000000,Nickel,Ni,29,63.5460000000,Copper,Cu,30,65.3800000000,Zinc,Zn,31,69.7230000000,Gallium,Ga,32,72.6400000000,Germanium,Ge,33,74.9216000000,Arsenic,As,34,78.9600000000,Selenium,Se,35,79.9040000000,Bromine,Br,36,83.7980000000,Krypton,Kr,37,85.4678000000,Rubidium,Rb,38,87.6200000000,Strontium,Sr,39,88.9058500000,Yttrium,Y,40,91.2240000000,Zirkonium,Zr,41,92.9063800000,Niobium,Nb,42,95.9600000000,Molybdaenum,Mo,43,98.0000000000,Technetium,Tc,44,101.0700000000,Ruthenium,Ru,45,102.9055000000,Rhodium,Rh,46,106.4200000000,Palladium,Pd,47,107.8682000000,Silver,Ag,48,112.4110000000,Cadmium,Cd,49,114.8180000000,Indium,In,50,118.7100000000,Tin,Sn,51,121.7600000000,Antimony,Sb,52,127.6000000000,Tellurium,Te,53,126.9044700000,Iodine,I,54,131.2930000000,Xenon,Xe,55,132.9054519000,Cesium,Cs,56,137.3270000000,Barium,Ba,57,138.9054700000,Lanthanum,La,58,140.1160000000,Cerium,Ce,59,140.9076500000,Praseodymium,Pr,60,144.2420000000,Neodymium,Nd,61,145.0000000000,Promethium,Pm,62,150.3600000000,Samarium,Sm,63,151.9640000000,Europium,Eu,64,157.2500000000,Gadolinium,Gd,65,158.9253500000,Terbium,Tb,66,162.5001000000,Dysprosium,Dy,67,164.9303200000,Holmium,Ho,68,167.2590000000,Erbium,Er,69,168.9342100000,Thulium,Tm,70,173.0540000000,Ytterbium,Yb,71,174.9668000000,Lutetium,Lu,72,178.4900000000,Hafnium,Hf,73,180.9478800000,Tantalum,Ta,74,183.8400000000,Tungsten,W,75,186.2070000000,Rhenium,Re,76,190.2300000000,Osmium,Os,77,192.2170000000,Iridium,Ir,78,192.0840000000,Platinum,Pt,79,196.9665690000,Gold,Au,80,200.5900000000,Hydrargyrum,Hg,81,204.3833000000,Thallium,Tl,82,207.2000000000,Lead,Pb,83,208.9804010000,Bismuth,Bi,84,210.0000000000,Polonium,Po,85,210.0000000000,Astatine,At,86,220.0000000000,Radon,Rn,87,223.0000000000,Francium,Fr,88,226.0000000000,Radium,Ra,89,227.0000000000,Actinium,Ac,90,232.0380600000,Thorium,Th,91,231.0358800000,Protactinium,Pa,92,238.0289100000,Uranium,U,93,237.0000000000,Neptunium,Np,94,244.0000000000,Plutonium,Pu,95,243.0000000000,Americium,Am,96,247.0000000000,Curium,Cm,97,247.0000000000,Berkelium,Bk,98,251.0000000000,Californium,Cf,99,252.0000000000,Einsteinium,Es,100,257.0000000000,Fermium,Fm,101,258.0000000000,Mendelevium,Md,102,259.0000000000,Nobelium,No,103,262.0000000000,Lawrencium,Lr,104,261.0000000000,Rutherfordium,Rf,105,262.0000000000,Dubnium,Db,106,266.0000000000,Seaborgium,Sg,107,264.0000000000,Bohrium,Bh,108,277.0000000000,Hassium,Hs,109,268.0000000000,Meitnerium,Mt,110,271.0000000000,Ununnilium,Ds,111,272.0000000000,Unununium,Rg,112,285.0000000000,Ununbium,Uub,113,284.0000000000,Ununtrium,Uut,114,289.0000000000,Ununquadium,Uuq,115,288.0000000000,Ununpentium,Uup,116,292.0000000000,Ununhexium,Uuh,118,294.0000000000,Ununoctium,Uuo";

		private static PeriodicTable tableInstance;
		/// <summary> Gets an instance of the periodic table. </summary>
		public static PeriodicTable Table {
			get {
				return tableInstance;
			}
			private set {}
		}

		//initializes the periodic table
		//by parsing the element data
		private static void Initialize() {
			List<Element> elements = ChemistryCSVParser.ParseString(ELEMENT_DATA);
			tableInstance = new PeriodicTable(elements);
		}

		/// <summary> Main method. Entry point. </summary>
		public static void Main(string[] args) {
			Initialize();
			//check for arguments
			if(args.Length > 0) {
				for(int i = 0; i < args.Length; i++){
					//every argument is either a formula or equation
					if(args[i].IndexOf(EquationParser.EQUATION_TOKEN) > -1) {
						Console.WriteLine("\n{0,4} Equation:", i + 1);
						CalculateEquation(args[i]);
					} else {
						Console.WriteLine("\n{0,4} Formula:", i + 1);
						CalculateFormula(args[i]);
					}
				}
			} else {
				Console.WriteLine("Usage: chemtools formula/expression");
			}
		}

		/// <summary> Attempts to parse the string into a formula
		/// and prints it out. </summary>
		public static void CalculateFormula(string input) {
			try {
				Formula formula = FormulaParser.ParseFormula(input);
				Console.WriteLine("Interpreted: {0:S}\n{1} g/mol", formula, formula.MolarMass);
				if(formula.Size == 1) {
					foreach(Element e in formula.Elements.Keys) {
					Console.WriteLine("Element: {0}", formula.Elements[e].Element);
					}
				}
			} catch(Exception e) {
				Console.WriteLine(e);
				Console.WriteLine("Error interpreting formula.");
			}
		}

		/// <summary> Attempts to parse the string into an equation
		/// and prints it out. </summary>
		public static void CalculateEquation(string input) {
			try {
				Equation equation = EquationParser.ParseEquation(input);

				//print all formulas
				for(int i = 0; i < equation.Left.Length; i++) {
					Console.WriteLine("{0} - {1} g/mol",
					                  equation.Left[i], equation.Left[i].MolarMass);
				}
				for(int i = 0; i < equation.Right.Length; i++) {
					Console.WriteLine("{0} - {1} g/mol",
					                  equation.Right[i], equation.Right[i].MolarMass);
				}

				Console.WriteLine("Interpreted equation: {0}", equation);
				//balance equation and print results
				if(EquationBalancer.BalanceEquation(equation)){
					Console.WriteLine("Balanced equation: {0}", equation);
				} else {
					Console.WriteLine("Balance failed.");
				}
			} catch(Exception e) {
				Console.WriteLine(e);
				Console.WriteLine("Error interpreting equation.");
			}
		}
		
	}

}