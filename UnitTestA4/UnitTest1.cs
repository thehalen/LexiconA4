using System;
using Xunit;
using LexiconA4;
using LexiconA4.Model;
using static LexiconA4.Exceptions;
using LexiconA4.Data;

namespace TodoItTest
{
    public class PersonClassShouldConsider
    {
        [Theory]
        [Trait("Class", "Person")] //not like Unit can sort by class anyway... but the imagination is sorely lacking at this point
        [InlineData(null, "")]
        [InlineData(null, "Nullsoft")]
        [InlineData("Adam", "")]
        [InlineData("Adam", null)]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void ArgumentIsNullOrWhiteSpaceException(string firstName, string lastName)
        {
            Exception exception = Assert.Throws<ArgumentIsNullOrWhiteSpaceException>(() =>
            {
                Person result = new Person(1, firstName, lastName);
                //Assert.IsType<string>(result);
            });
            Assert.IsType<ArgumentIsNullOrWhiteSpaceException>(exception);
        }

        [Fact]
        [Trait("Class", "Person")]
        public void ValidNames()
        {
            Person testPerson = new Person(1, "Thomas", "Anderson");
            Assert.Equal(1, testPerson.PersonId);
            Assert.Equal("Thomas", testPerson.FirstName);
            Assert.Equal("Anderson", testPerson.LastName);
        }
        
    }

    public class TodoClassShouldConsider
    {
        ///test for duplicate ID?

        [Theory]
        [Trait("Class", "Todo")]
        [InlineData(1, null)]
        [InlineData(2, "")]
        public void InValidInput(int i, string task)
        {
            Exception ex = Assert.Throws<ArgumentIsNullOrWhiteSpaceException>(() =>
            {
                Todo todoTest = new Todo(i, task);
            });
            Assert.IsType<ArgumentIsNullOrWhiteSpaceException>(ex);
        }

        [Fact]
        [Trait("Class", "Todo")]
        public void ValidInput()
        {
            Todo todoTest = new Todo(1, "Finish the assignment");
            Assert.Equal(1, todoTest.TodoID);
        }

    }

    public class PersonSequencerClassShouldConsider
    {
        [Fact]
        [Trait("Class", "PersonSequencer")]
        public static void IncrementID()
        {
            int i = 0;
            i = PersonSequencer.nextPersonId();
            Assert.Equal(0, i);
            i = PersonSequencer.nextPersonId();
            Assert.Equal(1, i);
            i = PersonSequencer.nextPersonId();
            Assert.Equal(2, i);

            PersonSequencer.reset();

            i = PersonSequencer.nextPersonId();
            Assert.Equal(0, i);
        }

    }

    public class TodoSequencerClassShouldConsider
    {
        [Fact]
        [Trait("Class", "TodoSequencer")]
        public static void IncrementID()
        {
            int i = 0;
            i = TodoSequencer.nextTodoId();
            Assert.Equal(0, i);
            i = TodoSequencer.nextTodoId();
            Assert.Equal(1, i);
            i = TodoSequencer.nextTodoId();
            Assert.Equal(2, i);

            TodoSequencer.reset();

            i = TodoSequencer.nextTodoId();
            Assert.Equal(0, i);
        }

    }

    public class PeopleClassShouldConsider
    {
        [Fact]
        [Trait("Class", "People")]
        public static void AddGenericPerson()
        {
            People people = new People();
            Assert.Equal(0, people.Size());
            Person pers = people.AddGenericPerson();
            Assert.Equal(1, people.Size());

            Assert.Equal("Hacke", people.FindById(1).FirstName);
            Assert.Equal("Hackspett", pers.LastName);

            Assert.Equal(people.Size(), people.FindAll().Length);
            people.Clear();
            Assert.Equal(0, people.Size());
        }
    }

    public class TodoItemsClassShouldConsider
    {
        [Fact]
        [Trait("Class", "TodoItems")]
        public static void AddGenericTodo()
        {
            TodoItems todoArr = new TodoItems();
            Assert.Equal(0, todoArr.Size());
            Todo todo = todoArr.AddGenericTodo();
            Assert.Equal(1, todoArr.Size());

            //Assert.Equal("Hacke", todoArr.FindById(1));
            //Assert.Equal("Hackspett", todo.LastName);

            Assert.Equal(todoArr.Size(), todoArr.FindAll().Length);
            todoArr.Clear();
            Assert.Equal(0, todoArr.Size());
        }
    }
}
