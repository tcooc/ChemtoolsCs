using System;
using System.Windows.Forms;
using System.Drawing;

namespace ChemTools.Gui {

	public class ChemtoolsGui : Form {

		public static void Initialize() {
			Application.EnableVisualStyles();
			Application.Run(new ChemtoolsGui());
		}

		private TextBox input;
		private RichTextBox output, savedOutput;
		private ListBox savedList;
		private Button btnAdd, btnDelete, btnClear;

		private ChemtoolsGui() {
			Text = "ChemTools";
			Size = new Size(640, 640);

			input = new TextBox();
			input.Location = new Point(20, 20);
			input.Size = new Size(250, 20);
			input.TextChanged += new EventHandler(InputChanged);
			input.KeyDown += new KeyEventHandler(InputKeyDown);

			output = new RichTextBox();
			output.Location = new Point(50, 160);
			output.Size = new Size(250, 300);

			savedList = new ListBox();
			savedList.Location = new Point(300, 20);
			savedList.Size = new Size(300, 120);
			savedList.SelectedIndexChanged += new EventHandler(SelectChange);
			savedList.BeginUpdate();
			savedList.Items.Add("H2O");
			savedList.Items.Add("CO2");
			savedList.Items.Add("C4H10+O2=CO2+H2O");
			savedList.Items.Add("U9000");
			savedList.Items.Add("44.0095gCO2");
			savedList.EndUpdate();

			savedOutput = new RichTextBox();
			savedOutput.Location = new Point(300, 160);
			savedOutput.Size = new Size(250, 300);

			btnAdd = new Button();
			btnAdd.Location = new Point(180, 50);	
			btnAdd.Text = "Save";
			btnAdd.Click += new EventHandler(AddClick);

			btnDelete = new Button();
			btnDelete.Location = new Point(180, 100);	
			btnDelete.Text = "Delete";
			btnDelete.Click += new EventHandler(DeleteClick);
						
			btnClear = new Button();
			btnClear.Location = new Point(20, 50);
			btnClear.Text = "Clear";
			btnClear.Click += new EventHandler(ClearClick);

			this.Controls.Add(input);
			this.Controls.Add(output);
			this.Controls.Add(savedList);
			this.Controls.Add(savedOutput);
			this.Controls.Add(btnAdd);
			this.Controls.Add(btnDelete);
			this.Controls.Add(btnClear);
		}

		private void InputChanged(object sender, EventArgs e) {
			output.Text = ChemTools.GetOutputString(input.Text);
		}
		
		private void InputKeyDown(object sender, KeyEventArgs e) {
		
		}
		
		private void ClearClick(object sender, EventArgs e) {
			input.Text = "";
		}
		
		private void DeleteClick(object sender, EventArgs e) {
			int selected = savedList.SelectedIndex;
			if(savedList.SelectedIndex > -1) {
				savedList.Items.RemoveAt(savedList.SelectedIndex);
				if(savedList.Items.Count > selected - 1) {
					savedList.SelectedIndex = selected - 1;
				}
			}
		}
		
		private void AddClick(object sender, EventArgs e) {
			savedList.Items.Add(input.Text);
		}

		private void SelectChange(object sender, EventArgs e) {
			int selected = savedList.SelectedIndex;
			if(selected > -1) {
				savedOutput.Text = ChemTools.GetOutputString(
					savedList.Items[selected].ToString());
			}
		}

	}
}
