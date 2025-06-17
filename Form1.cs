using Animals_project.Controlers;
using Animals_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Animals_project
{
    public partial class Form1 : Form
    {
        AnimalControler animalController = new AnimalControler();
        BreedControler breedController = new BreedControler();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadRecord(Animal animal)
        {
            textBox2.BackColor = Color.White;
            textBox2.Text = animal.id.ToString();
            textBox3.Text = animal.name;
            textBox4.Text = animal.age.ToString();
            comboBox1.Text = animal.Breed.name;
        }
        private void ClearScreen()
        {
            textBox2.BackColor = Color.White;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedController.GetAllBreeds();
            comboBox1.DataSource = allBreeds;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                textBox2.Focus();
                return;
            }
            Animal newAnimal = new Animal();
            newAnimal.age = int.Parse(textBox3.Text);
            newAnimal.name = textBox2.Text;


            newAnimal.BreedId = (int)comboBox1.SelectedValue;

            animalController.Create(newAnimal);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimal = animalController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allAnimal)
            {
                listBox1.Items.Add($"{item.id}. {item.name} - Age: {item.age} Breed:{item.Breed.name}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox2.Text);
            }
            Animal findedDog = animalController.Get(findId);
            if (findedDog == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
                return;
            }
            LoadRecord(findedDog);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox2.Text);
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Animal findedDog = animalController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox2.BackColor = Color.Red;
                    textBox2.Focus();
                    return;
                }
                LoadRecord(findedDog);
            }
            else //Ако има намерен вече запис променяме по полетата
            {
                Animal updatedDog = new Animal();
                updatedDog.name = textBox2.Text;
                updatedDog.age = int.Parse(textBox3.Text);
                updatedDog.BreedId = (int)comboBox1.SelectedValue;

                animalController.Update(findId, updatedDog);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;

            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox2.Text);
            }

            Animal findedAnimal = animalController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
                return;
            }

            LoadRecord(findedAnimal);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
                findId + " ?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                animalController.Delete(findId);
            }

        }
    }
}
