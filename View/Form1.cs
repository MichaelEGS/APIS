using APIS.Controllers;
using APIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIS.View
{
    public partial class Form1 : Form
    {
        private CharacterControllers CharacterController;
        private Characters characters;

        public Form1()
        {
            InitializeComponent();
            CharacterController = new CharacterControllers();
            characters = new Characters();
        }

        private async void GetCharacters()
        {
            characters = await CharacterController.GetAllCharacters();

            if (characters != null)
            {
                List<Character> characters1 = characters?.Results;
                foreach (var character in characters1)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCharacters);

                    row.Cells[0].Value = character.Name;
                    row.Cells[1].Value = character.Gender;
                    row.Cells[2].Value = character.Species;
                    row.Cells[3].Value = character.Origin.Name;

                    dgvCharacters.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener la petición", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetCharacters();
        }
    }
}
