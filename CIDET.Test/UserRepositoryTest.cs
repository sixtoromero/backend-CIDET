using CIDET.Domain.Entity;
using CIDET.InfraStructure.DAL;
using CIDET.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CIDET.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public async void GetAsyncByIdUserNoRegister()
        {
            //Preparación
            Exception expectedException = null;
            DbContextOptions<CIDETDataContext> options = new DbContextOptions<CIDETDataContext>();
            UserRepository userRep = new UserRepository(options);
            int UserId = 4;

            //Prueba
            try
            {
                await userRep.GetAsync(UserId);
                Assert.Fail("Un error debió ser arrojado");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("La consulta no arrojo ningún resultado con ese UserId", expectedException.Message);

        }

        [TestMethod]
        public async void InsertAsync()
        {
            //Preparación
            Exception expectedException = null;
            DbContextOptions<CIDETDataContext> options = new DbContextOptions<CIDETDataContext>();
            UserRepository userRep = new UserRepository(options);
            User model = new User();

            model.Id = 0;
            model.Names = "User test";
            model.Surnames = "Test";
            model.Password = "123";
            model.Status = "A";
            model.RolId = 3;

            //Prueba
            try
            {
                await userRep.InsertAsync(model);
                Assert.Fail("Se debe insertar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debió ser insertado", expectedException.Message);
        }

        [TestMethod]
        public async void UpdateAsync()
        {
            //Preparación
            Exception expectedException = null;
            DbContextOptions<CIDETDataContext> options = new DbContextOptions<CIDETDataContext>();
            UserRepository userRep = new UserRepository(options);
            User model = new User();

            model.Id = 2;
            model.Names = "User test";
            model.Surnames = "Test";
            model.Password = "123";
            model.Status = "A";
            model.RolId = 3;

            //Prueba
            try
            {
                await userRep.UpdateAsync(model);
                Assert.Fail("Se debe actualizar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debió ser actualizado", expectedException.Message);
        }

        [TestMethod]
        public async void DeleteAsync()
        {
            //Preparación
            Exception expectedException = null;
            DbContextOptions<CIDETDataContext> options = new DbContextOptions<CIDETDataContext>();
            UserRepository userRep = new UserRepository(options);
            var Id = 4;

            //Prueba
            try
            {
                await userRep.DeleteAsync(Id);
                Assert.Fail("Se debe eliminar el registro");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("El registro debió ser eliminado", expectedException.Message);
        }


    }
}
