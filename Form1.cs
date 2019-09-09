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
    public partial class Form1 : Form
    {
        public AppEvents myApp;

        public Form1()
        {
            myApp = new AppEvents();
            myApp.ReadFromFile();

            InitializeComponent();
            monthCalendar1.SelectionStart = DateTime.Today;
            monthCalendar1.SelectionEnd = DateTime.Today.AddDays(1).AddSeconds(-1);
            ListBoxUpdate(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);

        }

        //событие изменения даты в календаре
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ListBoxUpdate(e.Start, e.End);
        }

        //обновить выборку событий по текущей дате
        public void ListBoxUpdate(DateTime start, DateTime end)
        {
            //создаем коллекцию для выбора напоминаний
            List<Event> selectList = new List<Event>();
            
            //выбираем те которые соответствуют вбранной дате
            myApp.ForEach(it => {
                if (it.dateTime >= start && it.dateTime <= end)
                    selectList.Add(it);
            });

            //привязываем список формы к данным новой коллекции
            listBox1.DataSource = selectList;
            listBox1.DisplayMember = "timeAndText";
            listBox1.ValueMember = "id";
        }

        //при закрытии спрашивает: сохранить изменения?
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Сохранить изменения?",
                      "Выход из программы", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    myApp.WriteToFile();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        //нажатие кнопки добавление напоминания
        private void addEvent_Click(object sender, EventArgs e)
        {
            Event tmp = new Event();                //создаем новый объект напоминание
            FormObject f = new FormObject(tmp);     //создаем форму напоминания
            f.Owner = this;                         //записываем в новую форму родителя
            DialogResult result = f.ShowDialog();   //вызываем форму
            if (result == DialogResult.OK)          //если нажали Ок
            {
                tmp.id = myApp.id++;                //присваиваем новый id
                myApp.AddEvent(tmp);                //добавляем в коллекцию
            }

            //обновляем список напоминаний
            ListBoxUpdate(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
        }

        //нажатие кнопки удаление напоминания
        private void deleteEvent_Click(object sender, EventArgs e)
        {
            //найти объект напоминание по индексу
            Event tmp = myApp.Find(it => {
                if (it.id == (int)listBox1.SelectedValue) return true;
                return false;
            });

            //удаляем элемент по ключу
            myApp.RemoveEvent(tmp.dateTime);
            
            //обновляем список напоминаний
            ListBoxUpdate(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
        }

        //двойной клик на напоминании - измененике записи
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //найти объект напоминание по индексу
            Event tmp = myApp.Find(it => {
                if (it.id == (int)listBox1.SelectedValue) return true;
                return false;
            });

            FormObject f = new FormObject(tmp);     //создаем форму напоминания
            f.Owner = this;                         //записываем в новую форму родителя
            f.ShowDialog();                         //вызываем форму

            //обновляем список напоминаний
            ListBoxUpdate(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
        }

    }
}
