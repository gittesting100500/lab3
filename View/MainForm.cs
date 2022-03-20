using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;


namespace View
{
    public partial class MainForm : Form
    {
       /// <summary>
       /// Список объектов.
       /// </summary>
       public List<Calc> lst = new List<Calc>();
        

       public MainForm()
       {
            InitializeComponent();

            // Текущие рабочие каталоги.
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Вывод названий столбцов в таблице.
            dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Object", HeaderText = "Object", DataPropertyName = "Object" },
                new DataGridViewTextBoxColumn() { Name = "U", HeaderText = "U/ω", DataPropertyName = "U" },
                new DataGridViewTextBoxColumn() { Name = "I", HeaderText = "I/C/L", DataPropertyName = "I" }
                                         );
        }


        /// <summary>
        /// Открытие формы AddShapeForm для добавления нового объекта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddObjectToForm addShapeForm = new AddObjectToForm();
            addShapeForm.Show(this); 
        }


        /// <summary>
        /// Удаление объекта из таблицы и списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentRow.Index;
            lst.RemoveAt(index);
            dataGridView.Rows.RemoveAt(index);
            dataGridView.Refresh();
        }


        /// <summary>
        /// Реализация сериализатора.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public void Serializer(string filePath, List<Calc> data)
        {
            var serializar = new XmlSerializer(typeof(List<Calc>));

            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                serializar.Serialize(textWriter, data);
                textWriter.Close();
            }    
        }


        /// <summary>
        /// Реализация десериализатора.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns>Список объектов.</returns>
        public List<Calc> Deserializer(string filePath)
        {
            var serializar = new XmlSerializer(typeof(List<Calc>));

            using (TextReader textReader = new StreamReader(filePath))
            {
                var settings = (List<Calc>)serializar.Deserialize(textReader);
                textReader.Close();

                return settings;
            }            
        }


        /// <summary>
        /// Сериализация.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Serializer(saveFileDialog.FileName, lst);
                    MessageBox.Show("Данные сохранены в файл: " + saveFileDialog.FileName.ToString(),
                        "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Не найден файл.",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
        }


        /// <summary>
        /// Десериализация.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    lst = Deserializer(openFileDialog.FileName);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Не найден файл.",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            dataGridView.Rows.Clear();

            foreach (Calc obj in lst)
                dataGridView.Rows.Add(obj.Name(), obj.U.ToString(), obj.I.ToString());
        }


        /// <summary>
        /// Открытие формы SearchForm для поиска объекта в списке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show(this);
        }
    }
}
