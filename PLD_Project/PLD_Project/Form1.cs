using com.calitha.goldparser;

namespace PLD_Project
{
	public partial class Form1 : Form
	{
		MyParser p;
		public Form1()
		{
			InitializeComponent();
			p = new MyParser("PLD_Project.cgt", Parse_lstBox, Lexical_lstBox);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			Parse_lstBox.Items.Clear();
			Lexical_lstBox.Items.Clear();
			p.Parse(textBox3.Text);


		}






		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Lex_lstBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			

		}
	}
}
