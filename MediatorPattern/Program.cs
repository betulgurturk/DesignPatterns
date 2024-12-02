
internal class Program
{
    private static void Main(string[] args)
    {
        Teacher teacher = new Teacher();
    }

    public interface IMediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        void SendQuestion(string question, Student student);
        void SendAnswer(string answer, Student student);
        void SendMessage(string message);
    }
    public class Mediator : IMediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        void IMediator.SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer, student);
        }

        void IMediator.SendMessage(string message)
        {
            foreach (var item in Students)
            {
                item.ReceiveMessage(message);
            }
        }

        void IMediator.SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }
    }
    public class Teacher : CourseMember
    {
        IMediator _mediator;
        public Teacher(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine(question + " - " + student.Name);
        }

        public void SendAnswer(string answer, Student student)
        {
            Console.WriteLine("öğretmen cevap verdi : " + student.Name + " - Cevap: " + answer);

        }
        public void SendMessage(string message)
        {
            _mediator.SendMessage(message);
        }
    }
    public class Student : CourseMember
    {
        public string Name { get; set; }
        IMediator _mediator;
        public Student(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        public void ReceiveMessage(string url)
        {
            Console.WriteLine($"Image: {url}");
        }

        public void ReceiveAnswer(string answer, Student student)
        {
            Console.WriteLine(answer + " Cevap alan öğrenci:" + student.Name);
        }
        public void SendQuestion(string question)
        {
            _mediator.SendQuestion(question, this);
        }
    }

    public interface ICourseMember
    {

    }
    public class CourseMember : ICourseMember
    {
        IMediator _mediator;

        public CourseMember(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}