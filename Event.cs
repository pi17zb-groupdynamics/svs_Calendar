using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Event
    {
        //уникальный идентификатор
        private int _id;                        
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0) throw new Exception("id события должен быть больше нуля");
                _id = value;
            }
        }

        //дата и время заметки
        public DateTime DateTimeEvent { get; set; } = DateTime.Now;

        //текст заметки
        private string _text;                   
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        //уведомлять пользователя
        public bool Notify { get; set; } = true;

        /// <summary>
        /// Определяет прочитано ли уведомление
        /// </summary>
        public bool IsReaded { get; set; } = false;

        // Конструктор
        public Event()
        {
            _id = 0;
            _text = "";
        }// Event

        /// <summary>
        /// Возврат строки с временем и текстом заметки для отображения в ListBox
        /// </summary>
        public string timeAndText { get { return $"{DateTimeEvent.ToShortTimeString()} - {_text}"; } }

        //запись в файл
        public void WriteToFile(System.IO.FileStream fstream)
        {
            //запись поля id
            byte[] array = BitConverter.GetBytes(_id);
            fstream.Write(array, 0, array.Length);

            //записываем время и дату
            array = BitConverter.GetBytes(DateTimeEvent.Ticks);
            fstream.Write(array, 0, array.Length);

            //записываем длину поля _text
            array = BitConverter.GetBytes(_text.Length);
            fstream.Write(array, 0, array.Length);

            //записывем поле _text
            array = System.Text.Encoding.Default.GetBytes(_text);
            fstream.Write(array, 0, array.Length);
        }

        //чтение из файла
        public void ReadFromFile(System.IO.FileStream fstream)
        {
            //читаем поле id из файла
            byte[] array = new byte[System.Runtime.InteropServices.Marshal.SizeOf(_id)];
            fstream.Read(array, 0, array.Length);
            _id = BitConverter.ToInt32(array, 0);

            //читаем время и дату из файла
            array = new byte[System.Runtime.InteropServices.Marshal.SizeOf(DateTimeEvent.Ticks)];
            fstream.Read(array, 0, array.Length);
            DateTimeEvent = DateTime.FromBinary(BitConverter.ToInt64(array, 0));

            //читаем длину поля _text
            array = new byte[System.Runtime.InteropServices.Marshal.SizeOf<int>()];
            fstream.Read(array, 0, array.Length);
            int length = BitConverter.ToInt32(array, 0);

            //читаем поле _text
            array = new byte[length];
            fstream.Read(array, 0, array.Length);
            _text = System.Text.Encoding.Default.GetString(array);

        }


    }// class Event
}
