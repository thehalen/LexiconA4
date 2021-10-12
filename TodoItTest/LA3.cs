using System;
using Xunit;
using LexiconA4;
using LexiconA4.Model;

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
                Assert.IsType<string>(result);
            });
            Assert.IsType<ArgumentIsNullOrWhiteSpaceException>(exception);
        }
                
        ///test for duplicate ID

    }


}
