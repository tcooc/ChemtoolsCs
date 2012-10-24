using System;
using System.Windows.Forms;
using System.Drawing;

namespace ChemTools.Gui {

	public class ChemtoolsGui : Form {

		public static void Initialize() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ChemtoolsGui());
		}

		private TextBox input;
		private RichTextBox output;
		private WebBrowser renderer;

		private ChemtoolsGui() {
			Text = "ChemTools";
			Size = new Size(640, 640);

			input = new TextBox();
			input.Location = new Point(20, 20);
			input.Size = new Size(250, 20);
			input.TextChanged += new EventHandler(InputChanged);

			output = new RichTextBox();
			output.Location = new Point(20, 60);
			output.Size = new Size(250, 300);
			//output.Multiline = true;
			//output.AcceptsReturn = true;
			//output.AcceptsTab = true;
			//output.Dock = DockStyle.Fill;
			//output.ScrollBars = ScrollBars.Both;

			renderer = new WebBrowser();
			renderer.Location = new Point(20, 400);
			renderer.Size = new Size(300, 120);

			this.Controls.Add(input);
			this.Controls.Add(output);
			this.Controls.Add(renderer);
		}

		private void InputChanged(object sender, EventArgs e) {
			output.Text = ChemTools.GetOutputString(input.Text);
		}

	}

}
