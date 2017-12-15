using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Выбор_автомобилей {
    public partial class ConverterForm : Form {
        string openFile;
        public ConverterForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                openFile = "";
                try {

                    if ((myStream = openFileDialog1.OpenFile()) != null) {
                        //открываем 
                        using (myStream) {
                            int ch = 0;
                            //читаем символ за символом и сохраняем в string openFile
                            while (true) {
                                ch = myStream.ReadByte();
                                if (ch == -1) {
                                    break;
                                }
                                openFile += (char)ch;
                            }
                        }
                    }

                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                } finally {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {

            Stream myStream;
            // TAuto auto = new TAuto();
            List<TAuto> cars = new List<TAuto>();
            BinaryFormatter bformatter = new BinaryFormatter();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if ((myStream = saveFileDialog1.OpenFile()) != null) {
                    try {
                        foreach (var i in openFile.Split('\n')) {
                            int j = 0;
                            TAuto auto = new TAuto();
                            auto.Auto = i.Trim().Split()[j];
                            auto.Cost = i.Trim().Split()[++j];
                            auto.Rate = i.Trim().Split()[++j];
                            auto.Realibility = i.Trim().Split()[++j];
                            auto.Comfort = i.Trim().Split()[++j];

                            cars.Add(auto);
                        }

                        bformatter.Serialize(myStream, cars);


                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    } finally {
                        myStream.Close();
                    }

                }
            }
        }
    }
}
