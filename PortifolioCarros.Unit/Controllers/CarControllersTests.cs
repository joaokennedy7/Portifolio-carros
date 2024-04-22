using Moq;
using PortifolioCarros.API.Controllers;
using PortifolioCarros.API.Persistence.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace PortifolioCarros.Unit.Controllers
{
    public class CarControllersTests
    {
        [Fact]
        public void SHOULD_BE_RETURN_SUCCESS_WITH_EMPTY_LIST()
        {
            #region Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            carRepositoryMock.Setup(x => x.List()).Returns([]);

            var carController = new CarController(carRepositoryMock.Object);
            #endregion

            #region Act
            var result = carController.GetCars();
            #endregion

            #region Assert
            result.Should().NotBeNull();
            #endregion
        }
    }
}
