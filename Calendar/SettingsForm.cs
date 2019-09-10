using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar {
    public partial class SettingsForm : Form {

        private Settings _s;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="s"></param>
        public SettingsForm(Settings s) {
            InitializeComponent();
            _s = s;

            // Отображаем текущие данные в полях формы
            textBox1.Text = _s.MailAddress;

        }// Конструктор

        /// <summary>
        /// При изменении строки с адресами для опопвещения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e) {
            _s.MailAddress = textBox1.Text;
        }// TextBox1_TextChanged
    }// class SettingsForm
}
