using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class FormObject : Form
    {
        //эта форма привязана к объекту
        public Event ev;

        //конструктор формы - передаем через параметр 
        //ссылку на изменяемый объект или null
        public FormObject(Event ev)
        {
            InitializeComponent();

            if (ev == null) throw new Exception("FormObject не может принимать null ссылку");
            this.ev = ev;

            //если объект не новый а редактируем существующий
            if (this.ev.Id != 0)
            {
                ID.Text = this.ev.Id.ToString();    //отображаем тек. индекс
                CancelButton.Visible = false;       //скрываем кнопку Cancel
            }

            setDate.Value = this.ev.DateTimeEvent;       //заполнить поле Дата
            notify.Checked = this.ev.Notify;        //заполнить поле Уведомлять
            text.Text = this.ev.Text;               //заполнить поле Текст
        }

        private void FormObject_Load(object sender, EventArgs e)
        {

        }

        //нажатие кнопки Ок приводит к записи объекта или добавления в коллекцию
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ev.Text == "") throw new Exception("Поле Текст не может быть пустым.");
                Close();
            }
            catch(Exception ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        //устаовить ID
        public void SetId(int id)
        {
            ID.Text = id.ToString();
        }

        //событие изменения поля Уведомлять
        private void notify_CheckedChanged(object sender, EventArgs e)
        {
            this.ev.Notify = notify.Checked;
        }

        //событие изменения поля Дата
        private void setDate_Leave(object sender, EventArgs e)
        {
            this.ev.DateTimeEvent = setDate.Value;
        }

        //событие изменения поля Текс
        private void text_TextChanged(object sender, EventArgs e)
        {
            this.ev.Text = text.Text;
        }

        private void SetDate_ValueChanged(object sender, EventArgs e) {
            ev.IsReaded = false;
        }
    }
}
