using System;
using TaskingBoss.Areas.Identity.Data;
using Xunit;

namespace TaskingBoss.Tests
{
    public class ApplicationUserTest
    {
        [Fact]
        public void SetAbbreviation_IsCalledWithOneName_SetToTwoCharacters()
        {
            //Arrange 
            var user = new ApplicationUser() { Name = "Ole" };

            //Act
            user.SetAbbreviation();

            //Assert
            Assert.Equal("O", user.Abbreviation);
        }

        [Fact]
        public void SetAbbreviation_IsCalledWithTwoNames_SetToTwoCharacters()
        {
            //Arrange 
            var user = new ApplicationUser() { Name = "Ole Hansen" };

            //Act
            user.SetAbbreviation();

            //Assert
            Assert.Equal("OH", user.Abbreviation);
        }

        [Fact]
        public void SetAbbreviation_IsCalledWithThreeNames_SetToTwoCharacters()
        {
            //Arrange 
            var user = new ApplicationUser() { Name = "Ole Hansen Andersen" };

            //Act
            user.SetAbbreviation();

            //Assert
            Assert.Equal("OH", user.Abbreviation);
        }

        [Fact]
        public void SetAbbreviation_Lowercase_SetToUppercase()
        {
            //Arrange 
            var user = new ApplicationUser() { Name = "ole hansen" };

            //Act
            user.SetAbbreviation();

            //Assert
            Assert.Equal("OH", user.Abbreviation);
        }
    }
}
