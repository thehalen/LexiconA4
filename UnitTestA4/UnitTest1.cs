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
            int i = PersonSequencer.nextPersonId();
            int v = i;
            i = PersonSequencer.nextPersonId();
            Assert.True(v < i);
            v = i;
            i = PersonSequencer.nextPersonId();
            Assert.True(v < i);

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
            int i = TodoSequencer.nextTodoId();
            Assert.Equal(a + 1, i);
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
            Assert.Equal(4, people.Size());
            Person pers = people.AddGenericPerson();
            Assert.Equal(5, people.Size());

            Assert.Equal("Hacke", pers.FirstName);
            Assert.Equal("Hackspett", pers.LastName);

            Assert.Equal(people.Size(), people.FindAll().Length);
            people.Clear();
            Assert.Equal(0, people.Size());
        }

        [Fact]
        [Trait("Class", "People")]
        public void RemoveAPerson()
        {
            People remPeople = new People();
            remPeople.AddGenericPerson();
            remPeople.AddGenericPerson();
            remPeople.AddGenericPerson();
            remPeople.AddGenericPerson();
            remPeople.AddGenericPerson();
            Person person = remPeople.FindById(2);
            remPeople.RemoveFromArray(person);
            Assert.Equal(4, remPeople.Size());
        }
    }
}

namespace UnitTestA4
{ 
    public class TodoItemsClassShouldConsiderFixture : IDisposable
    {
        //refactor this
        public TodoItems _todoItems;
        private bool disposedValue;

        public TodoItemsClassShouldConsiderFixture()
        {
            _todoItems = new TodoItems();
            _todoItems.AddGenericTodo();
            _todoItems.AddGenericTodo();
            _todoItems.AddGenericTodo();
            _todoItems.AddGenericTodo();
            _todoItems.AddGenericTodo();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TodoItemsClassShouldConsiderFixture()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public class TodoItemsClassShouldConsider : IClassFixture<TodoItemsClassShouldConsiderFixture>
    {
        TodoItemsClassShouldConsiderFixture fixture;
        public TodoItemsClassShouldConsider(TodoItemsClassShouldConsiderFixture fix)
        {
            this.fixture = fix;
        }

        [Fact]
        [Trait("Class", "TodoItems")]
        public void AddGenericTodoAndIncrementSize()
        {            
            Assert.Equal(4, fixture._todoItems.Size());
            Todo todo = fixture._todoItems.AddGenericTodo();
            Assert.Equal(5, fixture._todoItems.Size()); 
        }
  

        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByDoneStatus()
        {
            fixture._todoItems.FindById(1).Done = true;
            fixture._todoItems.FindById(3).Done = true;
            Todo[] found = fixture._todoItems.FindByDoneStatus(true);
            Assert.Equal(2, found.Length);
        }

        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByAssigneeID()
        {
            Todo[] found = fixture._todoItems.FindByAssignee(2);
            Assert.Single(found);
        }
        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindByAssignee()
        { 
            Person testPerson = fixture._todoItems.FindById(3).Assignee;
            Todo[] found = fixture._todoItems.FindByAssignee(testPerson);
            Assert.Single(found);
        }
        [Fact]
        [Trait("Class", "TodoItems")]
        public void FindUnassignedTodoItems()
        {
            fixture._todoItems.FindById(2).Assignee = null;
            Todo[] found = fixture._todoItems.FindUnassignedTodoItems();
            Assert.Single(found);
        }
        [Fact]
        [Trait("Class", "TodoItems")]
        public void RemoveATodo()
        {
            Person person = new Person(PersonSequencer.nextPersonId(), "Inga", "Persson");
            fixture._todoItems.FindById(2).Assignee = person;
            Todo[] found = fixture._todoItems.FindByAssignee(person.PersonId);
            fixture._todoItems.RemoveFromArray(found[0]);
            Assert.Equal(4, fixture._todoItems.Size());
        }

    }
}
