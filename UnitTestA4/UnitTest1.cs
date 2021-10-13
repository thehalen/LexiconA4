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
            TodoSequencer.reset();
            int a = TodoSequencer.nextTodoId();
            int i =  TodoSequencer.nextTodoId();
            Assert.Equal(a+1, i);
            i = TodoSequencer.nextTodoId();
            Assert.Equal(a + 2, i);
            i = TodoSequencer.nextTodoId();
            Assert.Equal(a + 3, i);

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
        //private TodoItems _todoItems;
        //public TodoItemsClassShouldConsider()
        //{
        //    _todoItems = new TodoItems();
        //    _todoItems.AddGenericTodo();
        //    _todoItems.AddGenericTodo();
        //    _todoItems.AddGenericTodo();
        //    _todoItems.AddGenericTodo();
        //    _todoItems.AddGenericTodo();
        //}

        //refactor this
        [Fact]
        [Trait("Class", "TodoItems")]
        public void AddGenericTodoAndIncrementSize()
        {
            TodoItems todoItems = new TodoItems();
            todoItems.AddGenericTodo();
            todoItems.AddGenericTodo();
            todoItems.AddGenericTodo();
            todoItems.AddGenericTodo();
            todoItems.AddGenericTodo();
            Assert.Equal(5, todoItems.Size());
            Todo todo = todoItems.AddGenericTodo();
            Assert.Equal(6, todoItems.Size());

            //Assert.Equal("Hacke", todoArr.FindById(1));
            //Assert.Equal("Hackspett", todo.LastName);

            todoItems.Clear();
            Assert.Equal(0, todoItems.Size());
        }
  

        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByDoneStatus()
        {
            TodoItems todoItems1 = new TodoItems();
            todoItems1.AddGenericTodo();
            todoItems1.AddGenericTodo();
            todoItems1.AddGenericTodo();
            todoItems1.AddGenericTodo();
            todoItems1.AddGenericTodo();
            todoItems1.FindById(1).Done = true;
            todoItems1.FindById(3).Done = true;
            Todo[] found = todoItems1.FindByDoneStatus(true);
            Assert.Equal(2, found.Length);
        }

        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByAssigneeID()
        {
            TodoItems todoItems2 = new TodoItems();
            todoItems2.AddGenericTodo();
            todoItems2.AddGenericTodo();
            todoItems2.AddGenericTodo();
            todoItems2.AddGenericTodo();
            todoItems2.AddGenericTodo();
            Todo[] found = todoItems2.FindByAssignee(2);
            Assert.Single(found);

        }
        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByAssignee()
        {
            TodoItems todoItems3 = new TodoItems();
            todoItems3.AddGenericTodo();
            todoItems3.AddGenericTodo();
            todoItems3.AddGenericTodo();
            todoItems3.AddGenericTodo();
            todoItems3.AddGenericTodo();
            Person person = new Person(5, "Inga", "Persson");
            todoItems3.FindById(1).Assignee = person;
            Todo[] found = todoItems3.FindByAssignee(person);
            Assert.Single(found);
        }
        [Fact]
        [Trait("Class", "TodoItems")]
        public static void FindUnassignedTodoItems()
        {
            TodoItems todoItems4 = new TodoItems();
            todoItems4.AddGenericTodo();
            todoItems4.AddGenericTodo();
            todoItems4.AddGenericTodo();
            todoItems4.AddGenericTodo();
            todoItems4.AddGenericTodo();
            Person person = new Person(5, "Inga", "Persson");
            todoItems4.FindById(1).Assignee = person;
            Todo[] found = todoItems4.FindByAssignee(person);
            Assert.Equal(4, found.Length);
        }
    }
}
