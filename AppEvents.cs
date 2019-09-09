using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Calendar
{
    public class AppEvents
    {
        //id события
        private int _id;                                                
        public int Id { get { return _id; } set { _id = value; } }

        //коллекция для хранения напоминаний
        private SortedDictionary<DateTime, Event> _eventsList;

        //обход коллекции напоминаний
        public void ForEach(Action<Event> action)
        {
            foreach (var it in _eventsList) action(it.Value);
        }// ForEach

        //поиск первого элемента удовлетворяющего предикату
        public Event Find(Predicate<Event> Pred)
        {
            foreach(var it in _eventsList)
            {
                if (Pred(it.Value)) return it.Value;
            }
            return null;
        }// Find

        //добавить новое событие
        public void AddEvent(Event ev)
        {
            _eventsList.Add(ev.DateTimeEvent, ev);
        }// AddEvent

        public void RemoveEvent(DateTime dt)
        {
            _eventsList.Remove(dt);
        }

        //конструктор
        public AppEvents()
        {
            _id = 1;
            // инициализация коллекции для хранения событий
            _eventsList = new SortedDictionary<DateTime, Event>();
        }

        /// <summary>
        /// Записать коллекцию в файл
        /// </summary>
        public void WriteToFile()
        {
            using (System.IO.FileStream fstream = new System.IO.FileStream(@"data.bin", System.IO.FileMode.OpenOrCreate))
            {
                foreach (KeyValuePair<DateTime, Event> current in _eventsList)
                {
                    current.Value.WriteToFile(fstream);
                }
            }
        }

        /// <summary>
        /// Чтение из файла в коллекцию
        /// </summary>
        public void ReadFromFile()
        {
            // Путь к файлу
            string path = @"data.bin";

            // Проверка существует ли файл
            if (!File.Exists(path))
                return;

            // Загрузка данных из файла
            using (System.IO.FileStream fstream = File.OpenRead(path))
            {
                while (fstream.Position != fstream.Length)
                {
                    Event tmp = new Event();
                    tmp.ReadFromFile(fstream);
                    _eventsList.Add(tmp.DateTimeEvent, tmp);
                    if (tmp.Id >= Id) Id = tmp.Id + 1;
                }// while
            }// using
        }// ReadFromFile

        /// <summary>
        /// Уведомляет пользователя
        /// </summary>
        public void NotifyUser() {

            // Текущее дата и время
            DateTime now = DateTime.Now;

            var result = _eventsList.Select(it => it.Value).Where(it => it.Notify).Where(it => !it.IsReaded).Where(it => it.DateTimeEvent < now);

            foreach (var it in result) {
                it.IsReaded = true;
                MessageBox.Show(it.Text, "Уведомление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }// foreach

        }// NotifyUser

    }// class AppEvents
}
