using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calendar
{
    public class AppEvents
    {
        //id события
        private int _id;                                                
        public int id { get { return _id; } set { _id = value; } }

        //коллекция для хранения напоминаний
        private SortedDictionary<DateTime, Event> _eventsList;

        //обход коллекции напоминаний
        public void ForEach(Action<Event> action)
        {
            foreach (var it in _eventsList) action(it.Value);
        }

        //поиск первого элемента удовлетворяющего предикату
        public Event Find(Predicate<Event> Pred)
        {
            foreach(var it in _eventsList)
            {
                if (Pred(it.Value)) return it.Value;
            }
            return null;
        }

        //добавить новое событие
        public void AddEvent(Event ev)
        {
            _eventsList.Add(ev.dateTime, ev);
        }

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

        //записать коллекцию в файл
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

        //чтение из файла в коллекцию
        public void ReadFromFile()
        {
            string path = @"data.bin";
            if (!File.Exists(path))
                return;
            using (System.IO.FileStream fstream = File.OpenRead(path))
            {
                while (fstream.Position != fstream.Length)
                {
                    Event tmp = new Event();
                    tmp.ReadFromFile(fstream);
                    _eventsList.Add(tmp.dateTime, tmp);
                    if (tmp.id >= id) id = tmp.id + 1;
                }
            }
        }
    }
}
