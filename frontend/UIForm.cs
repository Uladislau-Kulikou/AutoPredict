using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Autoprezzit_interface
{

    public partial class UIForm : Form
    {
        static string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
        static string searchDataPath = Path.Combine(exeFolder, "data", "search_data.json");
        static SearchData SearchData = new SearchData(searchDataPath);

        public UIForm()
        {
            InitializeComponent();
            loadMakeComboxBox();
            loadProvinceCombobox();
            loadFuelTypeCombobox();
            result_label.Width = result_label.Parent.ClientSize.Width;
            evaluate_button.Left = (evaluate_button.Parent.ClientSize.Width - evaluate_button.Width) / 2;
            //evaluate_button.Top = 10;
        }

        public class ComboItem
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public override string ToString() => Value;
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(40, 40, 40), 2))
            {
                // Drawing only vertical lines on the panel grid
                if (e.Column < tableLayoutPanel1.ColumnCount - 1)
                {
                    int x = e.CellBounds.Right - 1;
                    e.Graphics.DrawLine(pen, x, e.CellBounds.Top, x, e.CellBounds.Bottom);
                }
            }
        }


        private string denormalizeName(string text)
        {
            string denormalizedText = text.Replace("_", " ").Replace("-", " ");
            // Capitalize all words in the denormalized text
            string[] words = denormalizedText.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            denormalizedText = string.Join(" ", words);

            return denormalizedText;
        }


        private void loadMakeComboxBox()
        {
            List<string> normalizedMakes = SearchData.GetMakes();

            var items = normalizedMakes.Select(n => new ComboItem { Key = n, Value = denormalizeName(n) }).ToList();

            make_combobox.DisplayMember = "Value";
            make_combobox.ValueMember = "Key";
            make_combobox.DataSource = items;

            // Setting the non normalized data as auto complete source
            var autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(items.Select(i => i.Value).ToArray());
            make_combobox.AutoCompleteCustomSource = autoCompleteCollection;

        }


        private void make_combobox_TextChanged(object sender, EventArgs e)
        {
            // If the text equals to any item in the combobox, then load the models for that make
            string inputText = make_combobox.Text;
            var selectedItem = make_combobox.Items.Cast<ComboItem>().FirstOrDefault(item => item.Value.Equals(inputText, StringComparison.OrdinalIgnoreCase));
            if (selectedItem != null)
            {
                make_combobox.SelectedItem = selectedItem;
                loadModelCombobox(selectedItem.Key);
            }
            else
            {
                // If the input text does not match any item, clear the model and version comboboxes
                model_combobox.DataSource = null;
                version_combobox.DataSource = null;
            }
        }


        private void loadModelCombobox(string make)
        {
            List<string> normalizedModels = SearchData.GetModels(make);
            var items = normalizedModels.Select(n => new ComboItem { Key = n, Value = denormalizeName(n) }).ToList();

            model_combobox.DisplayMember = "Value";
            model_combobox.ValueMember = "Key";
            model_combobox.DataSource = items;

            var autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(items.Select(i => i.Value).ToArray());
            model_combobox.AutoCompleteCustomSource = autoCompleteCollection;
        }


        private void model_combobox_TextChanged(object sender, EventArgs e)
        {
            // If the text equals to any item in the combobox, then load the versions for that model
            string inputText = model_combobox.Text;
            var selectedItem = model_combobox.Items.Cast<ComboItem>().FirstOrDefault(item => item.Value.Equals(inputText, StringComparison.OrdinalIgnoreCase));
            var makeSelectedItem = make_combobox.SelectedItem as ComboItem;

            if (selectedItem != null)
            {
                model_combobox.SelectedItem = selectedItem;
                loadVersionCombobox(makeSelectedItem.Key, selectedItem.Key);

            }
        }


        private void loadVersionCombobox(string make, string model)
        {
            List<string> normalizedVersions = SearchData.GetVersions(make, model);
            var items = normalizedVersions.Select(n => new ComboItem { Key = n, Value = denormalizeName(n) }).ToList();

            version_combobox.DisplayMember = "Value";
            version_combobox.ValueMember = "Key";
            version_combobox.DataSource = items;
            var autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(items.Select(i => i.Value).ToArray());
            version_combobox.AutoCompleteCustomSource = autoCompleteCollection;
        }


        private void loadProvinceCombobox()
        {
            List<string> provinces = SearchData.GetProvinces();
            province_combobox.DataSource = provinces;
            var autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(provinces.ToArray());
            province_combobox.AutoCompleteCustomSource = autoCompleteCollection;
        }


        private void loadFuelTypeCombobox()
        {
            List<string> fuelTypes = SearchData.GetFuelTypes();
            fuel_combobox.DataSource = fuelTypes;
            var autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(fuelTypes.ToArray());
            fuel_combobox.AutoCompleteCustomSource = autoCompleteCollection;
        }


        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }


        private void collectData(object sender, MouseEventArgs e)
        {   
            int Is_new = new_radiobutton.Checked ? 1 : 0;

            string Make = (make_combobox.SelectedItem as ComboItem)?.Key;
            string Model = (model_combobox.SelectedItem as ComboItem)?.Key;
            string Version = (version_combobox.SelectedItem as ComboItem)?.Key;
            // If the version is not selected, choose '-'
            Version = string.IsNullOrWhiteSpace(Version) ? "-" : Version;

            string Fuel = fuel_combobox.SelectedItem as string;
            string Province = province_combobox.SelectedItem as string;

            // If the textboxes are empty, use the placeholder text
            string kmText = string.IsNullOrWhiteSpace(km_textbox.Text) ? km_textbox.PlaceholderText : km_textbox.Text;
            string powerText = string.IsNullOrWhiteSpace(power_textbox.Text) ? power_textbox.PlaceholderText : power_textbox.Text;
            string yearText = string.IsNullOrWhiteSpace(year_textbox.Text) ? year_textbox.PlaceholderText : year_textbox.Text;

            int Kilometers = int.Parse(kmText);
            int PowerKW = int.Parse(powerText);
            int year = int.Parse(yearText);

            if (string.IsNullOrWhiteSpace(Make) || string.IsNullOrWhiteSpace(Model))
            {
                MessageBox.Show("Please select make and model.");
                return;
            }

            if (PowerKW <= 0)
            {
                MessageBox.Show("Power cannot be negative or zero.");
                return;
            }

            if (year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Please enter a valid year.");
                return;
            }
            int Age = DateTime.Now.Year - year;

            string Gearbox = manual_radiobutton.Checked ? "manual" :
                             semi_radiobutton.Checked ? "semi-automatic" : "automatic";

            var car = new
            {
                Is_new,
                Make,
                Model,
                Version,
                Fuel,
                Kilometers,
                Age,
                Gearbox,
                PowerKW,
                Province
            };

            string json = JsonConvert.SerializeObject(car);
            if (json != null)
                Program.HandleCarData(json);
        }



        public void displayResult(string result)
        {
            result_label.Text = result;
        }


    }

    
}