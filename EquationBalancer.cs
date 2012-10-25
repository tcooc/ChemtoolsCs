namespace ChemTools {

	/// <summary> USed for balancing equations. </summary>
	public class EquationBalancer {

		private Equation equation;
		private Formula[] left, right;
		private int[] leftCoeff, rightCoeff;

		private EquationBalancer(Equation eq) {
			equation = eq;
			left = eq.left;
			leftCoeff = eq.leftCoeff;
			right = eq.right;
			rightCoeff = eq.rightCoeff;
		}

		/// <summary> Only method a program needs to use.
		///	Returns true iff the balance is successful. </summary>
		public static bool BalanceEquation(Equation eq) {
			//creates a new instance to be thread safe
			EquationBalancer balancer = new EquationBalancer(eq);
			if(!balancer.equation.Balanced) {
				balancer.BruteForceBalance(20, 0);
			}
			return balancer.equation.Balanced;
		}

		private bool Balance() {
			if(!equation.Balanced) {
				BruteForceBalance(20, 0);
			}
			return equation.Balanced;
		}

		//recursive brute-force
		//tries all combinations between {1}{1}{1}... to {threshold}{threshold}{threshold}...
		private void BruteForceBalance(int threshold, int index) {
			//for loop that breaks out if the equation is balanced
			for(int i = 1; !equation.Balanced && i < threshold; i++) {
				if(index < left.Length) {
					leftCoeff[index] = i;
				} else if(index < left.Length + right.Length) {
					rightCoeff[index - left.Length] = i;
				} else {
					return; //index exceeds threshold
				}
				//call itself with index + 1
				BruteForceBalance(threshold, index + 1);
			}
		}
	}

}
