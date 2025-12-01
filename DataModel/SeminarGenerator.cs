namespace DataModel
{
    public class SeminarGenerator
    {
        public List<Seminar> CreateSeminars()
        {
            var random = new Random();
            var seminars = new List<Seminar>();

            var faculties = new[]
            {
            new Faculty { Department = "Факультет комп'ютерних наук", Branch = "Інженерія програмного забезпечення" },
            new Faculty { Department = "Факультет комп'ютерних наук", Branch = "Штучний інтелект" },
            new Faculty { Department = "Факультет інформаційних технологій", Branch = "Кібербезпека" },
            new Faculty { Department = "Факультет інформаційних технологій", Branch = "Комп'ютерні мережі" },
            new Faculty { Department = "Факультет прикладної математики", Branch = "Аналіз даних" }
            };

            var cathedras = new[]
            {
            "Кафедра алгоритмів і структур даних",
            "Кафедра операційних систем",
            "Кафедра баз даних",
            "Кафедра машинного навчання",
            "Кафедра кібербезпеки",
            "Кафедра комп'ютерних мереж",
            "Кафедра мов програмування",
            "Кафедра програмної інженерії"
            };

            var headers = new[]
            {
            new Person { Name = "Іван", Surname = "Петренко" },
            new Person { Name = "Олена", Surname = "Коваль" },
            new Person { Name = "Дмитро", Surname = "Шелест" },
            new Person { Name = "Василь", Surname = "Шелест" },
            new Person { Name = "Світлана", Surname = "Гриценко" },
            new Person { Name = "Андрій", Surname = "Марченко" }
            };

            var topics = new[]
            {
            "Вступ до алгоритмів",
            "Сучасні мови програмування",
            "Практика розробки програмного забезпечення",
            "Оптимізація коду та продуктивність",
            "Основи машинного навчання",
            "Нейронні мережі для початківців",
            "Безпека інформаційних систем",
            "Кібербезпека у сучасному світі",
            "Бази даних: SQL та NoSQL",
            "Проєктування комп'ютерних мереж",
            "Хмарні технології та сервіси",
            "DevOps: CI/CD на практиці",
            "Вступ до Data Science",
            "Обчислювальна математика",
            "Штучний інтелект та етичні аспекти",
            "Глибинне навчання",
            "Мікросервісна архітектура",
            "Контейнеризація та Docker",
            "Побудова REST API",
            "Системне програмування"
            };
            var topicCounts = new int[topics.Length];
            Array.Fill(topicCounts, 0);

            var descriptions = topics
                .Select(t =>
                    $"Студентський семінар на тему: «{t}». " +
                    "Проводиться викладачами КНУ та спрямований на поглиблення знань студентів.")
                .ToArray();

            var startDate = new DateTime(DateTime.Now.Year, 9, 1);

            for (var i = 0; i < 300; i++)
            {
                var topicIndex = random.Next(topics.Length);

                var topicCount = topicCounts[topicIndex];
                topicCounts[topicIndex] = topicCount + 1;

                var seminar = new Seminar
                {
                    //Topic = topics[topicIndex] + (topicCount > 0 ? $". Частина {topicCount + 1}" : string.Empty),
                    Topic = topics[topicIndex],
                    Description = descriptions[topicIndex],
                    Cathedra = cathedras[random.Next(cathedras.Length)],
                    Faculty = faculties[random.Next(faculties.Length)],
                    Header = headers[random.Next(headers.Length)],

                    // Дата: кожні 2–4 дні, починаючи з 1 вересня
                    Date = startDate.AddDays(i * random.Next(2, 5))
                };

                seminars.Add(seminar);
            }

            return seminars;
        }
    }
}
