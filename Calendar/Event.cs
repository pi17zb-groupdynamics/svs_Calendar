using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar {

    /// <summary>
    /// Информация о заметке
    /// </summary>
    public class Event : ICloneable {

        // ПОЛЯ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Дата и время заметки
        /// </summary>
        public DateTime DateTimeEvent { get; set; }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// Уведомлять пользователя
        /// </summary>
        public bool Notify { get; set; } = true;

        private bool _isReaded = false;

        /// <summary>
        /// Определяет прочитано ли уведомление
        /// </summary>
        public bool IsReaded {
            get => _isReaded;
            set => _isReaded = value;
        }// IsReaded

        /// <summary>
        /// Список доступных значений уведомления за ... мин
        /// </summary>
        public static Dictionary<string, int> NotifyTimeList { get; set; }
            = new Dictionary<string, int>() {
                { "одновременно", 0 },
                { "за 5 мин.", 5 },
                { "за 10 мин.", 10 },
                { "за 15 мин.", 15 },
                { "за 1 час", 60 },
                { "за 1 день", 1440 }
            };

        public static ImageList imgList;

        /// <summary>
        /// Значение в минутах за сколько времени оповещать пользователя
        /// </summary>
        private int _notifyTime = 0;

        /// <summary>
        /// Уведомлять за ... (5, 10 мин) до
        /// </summary>
        public string NotifyTimeString {
            get => NotifyTimeList.Where(it => it.Value == _notifyTime).First().Key;
            set {
                // Проверка и присваивание значеня свойству
                if (!NotifyTimeList.TryGetValue(value, out _notifyTime))
                    throw new Exception($"Присваивается недопустимая величина {value}");
            }// set
        }// NotifyTime

        /// <summary>
        /// Дата время уведомления пользователя
        /// </summary>
        public DateTime NotifyTime => DateTimeEvent.AddMinutes(-_notifyTime);

        /// <summary>
        /// Индекс картинки для задачи (выполнена/невыполнена)
        /// </summary>
        public Image Image {
            get {
                if (IsReaded)
                    return imgList.Images[0];
                return imgList.Images[1];
            }// get
        }

        // МЕТОДЫ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Статический конструтор
        /// </summary>
        static Event() {
            
            // Создаем список иконок
            imgList = new ImageList();
            // Устанавливаем размер иконок
            imgList.ImageSize = new Size(16, 16);
            // Загружаем иконки
            imgList.Images.Add(Image.FromFile(@"../../Resources/BlackTag.png"));
            imgList.Images.Add(Image.FromFile(@"../../Resources/GreenTag.png"));
            imgList.Images.Add(Image.FromFile(@"../../Resources/BlueTag.png"));
            imgList.Images.Add(Image.FromFile(@"../../Resources/RedTag.png"));
            imgList.Images.Add(Image.FromFile(@"../../Resources/YellowTag.png"));

        }// Статический конструктор

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="d"></param>
        public Event(DateTime d) {
            DateTimeEvent = d;
        }// Конструктор

        /// <summary>
        /// Возвращает новый объект созданный на основе текущего
        /// </summary>
        /// <returns></returns>
        public object Clone() {
            return new Event(new DateTime(DateTimeEvent.Ticks)) {
                Text        = this.Text,
                Notify      = this.Notify,
                IsReaded    = this.IsReaded,
                NotifyTimeString  = this.NotifyTimeString
            };
        }// Clone

        /// <summary>
        /// Копирует данные из другого объекта
        /// </summary>
        public void CloneFrom(Event ev) {
            DateTimeEvent = ev.DateTimeEvent;
            Text = ev.Text;
            Notify = ev.Notify;
            IsReaded = ev.IsReaded;
            NotifyTimeString = ev.NotifyTimeString;
        }// CloneFrom

        /// <summary>
        /// Возврат строки с временем и текстом заметки
        /// </summary>
        public override string ToString() {
            return $"{DateTimeEvent.ToShortTimeString()} - {Text}";
        }// ToString

    }// class Event
}
