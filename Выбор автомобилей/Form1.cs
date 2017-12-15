using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Выбор_автомобилей {

    public partial class Form1 : Form {
        List<TAuto> cars;
        public Form1() {
            InitializeComponent();
            cars = new List<TAuto>();
        }

        private void button1_Click(object sender, EventArgs e) {
            
            if (cars.Count == 0) {
                MessageBox.Show("Нет открытого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form2 newMDIChild = new Form2();

            string auto = (string)comboBox1.SelectedItem;
            string cost = (string)comboBox2.SelectedItem;
            string rate = (string)comboBox3.SelectedItem;
            string realibility = (string)comboBox4.SelectedItem;
            string comfort = (string)comboBox5.SelectedItem;
            int i = 0;
            foreach (var a in cars) {
                //проверяет, есть ли в строке 6 колонок, если да то выводит
                    if ((auto == a.Auto || auto == null) &&
                        (cost == a.Cost || cost == null) &&
                        (rate == a.Rate || rate == null) &&
                        (realibility == a.Realibility || realibility == null) &&
                        (comfort == a.Comfort || comfort == null)) {
                        newMDIChild.dataGridView2.Rows.Add(a.Auto, a.Cost, a.Rate, a.Realibility, a.Comfort);
                        newMDIChild.dataGridView2.Rows[i].HeaderCell.Value = (i + 1).ToString();
                        i++;
                    }
            }

            newMDIChild.Show();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) {
            
            Form3 newMDIChild = new Form3();
            // Задать дочернюю форму
            newMDIChild.Owner = this;
            //Заполняем DataGridView1 из файла
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {

                    if ((myStream = openFileDialog1.OpenFile()) != null) {
                        
                        using (myStream) {
                            //  dgw = new DataGridView();
                            BinaryFormatter bformatter = new BinaryFormatter();
                            cars = (List<TAuto>)bformatter.Deserialize(myStream);
                            int j = 0;
                            foreach (var a in cars) {
                                newMDIChild.dataGridView1.Rows.Add(a.Auto, a.Cost, a.Rate, a.Realibility, a.Comfort);
                                newMDIChild.dataGridView1.Rows[j].HeaderCell.Value = (j + 1).ToString();
                                j++;
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                
                newMDIChild.Show();

            }

        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) {
            Form3 newMDIChild = new Form3();
            // Задать дочернюю форму
            newMDIChild.Owner = this;

            newMDIChild.dataGridView1.Rows.Clear();

            newMDIChild.Show();



        }

        private void конвертерToolStripMenuItem_Click(object sender, EventArgs e) {
            ConverterForm convert = new ConverterForm();
            convert.Owner = this;
            convert.Show();
            
        }
    }
}

