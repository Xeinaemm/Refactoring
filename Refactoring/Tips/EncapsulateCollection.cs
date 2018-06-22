using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class EncapsulateCollection
	{
		public class PersonBefore
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public int Age { get; set; }
			public List<CourseBefore> Courses { get; set; }
		}

		public class PersonAfter
		{
			private readonly List<CourseAfter> _courses = new List<CourseAfter>();
			public int Id { get; private set; }
			public string Name { get; private set; }
			public string Surname { get; private set; }
			public int Age { get; private set; }


			public void SetId(int id)
			{
				Id = id;
			}

			public void SetName(string name)
			{
				Name = name;
			}

			public void SetSurname(string surname)
			{
				Surname = surname;
			}

			public void SetAge(int age)
			{
				Age = age;
			}

			public void InitializePerson(int id, string name, string surname, int age)
			{
				Id = id;
				Name = name;
				Surname = surname;
				Age = age;
			}

			public void AddCourse(CourseAfter course)
			{
				_courses.Add(course);
			}

			public void RemoveCourse(CourseAfter course)
			{
				_courses.Remove(course);
			}
		}

		public class CourseBefore
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		public class CourseAfter
		{
			public int Id { get; private set; }
			public string Name { get; private set; }

			public void SetId(int id)
			{
				Id = id;
			}

			public void SetName(string name)
			{
				Name = name;
			}

			public void InitializeCourse(int id, string name)
			{
				Id = id;
				Name = name;
			}
		}

		public class Util
		{
			public void Before()
			{
				var collection = new PersonBefore
				{
					Id = 1,
					Name = "Piotr",
					Surname = "Czech",
					Age = 22,
					Courses = new List<CourseBefore>
					{
						new CourseBefore
						{
							Id = 1,
							Name = "Refactoring"
						}
					}
				};
			}

			public void After()
			{
				var collection = new PersonAfter();
				collection.SetId(1);
				collection.SetName("Piotr");
				collection.SetSurname("Czech");
				collection.SetAge(22);
				var course = new CourseAfter();
				course.SetId(1);
				course.SetName("Refactoring");
				collection.AddCourse(course);

				//Or
				var secondCollection = new PersonAfter();
				secondCollection.InitializePerson(1, "Piotr", "Czech", 22);
				var secondCourse = new CourseAfter();
				secondCourse.InitializeCourse(1, "refactoring");
				secondCollection.AddCourse(secondCourse);
			}
		}
	}
}