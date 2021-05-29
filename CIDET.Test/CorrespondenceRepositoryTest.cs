using CIDET.Domain.Entity;
using CIDET.InfraStructure.DAL;
using CIDET.InfraStructure.Repository;
using CIDET.Transversal.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CIDET.Test
{
    [TestClass]
    public class CorrespondenceRepositoryTest
    {        
        [TestMethod]
        public async void InsertAsync()
        {
            //Preparación
            Exception expectedException = null;
            IConnectionFactory connectionFactory;
            CorrespondenceRepository messageRep = new CorrespondenceRepository(null);
            Correspondence model = new Correspondence();

            model.Id = 0;
            model.Consecutive = string.Empty;
            model.SenderId = 1;
            model.AddresseeId = 2;
            model.Subject = "Hola";
            model.Body = "Mundo";

            //Prueba
            try
            {
                await messageRep.InsertAsync(model);
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
            CorrespondenceRepository messageRep = new CorrespondenceRepository(null);
            Correspondence model = new Correspondence();

            model.Id = 2;
            model.Id = 0;
            model.Consecutive = "CI00000001";
            model.SenderId = 1;
            model.AddresseeId = 2;
            model.Subject = "Hola";
            model.Body = "Mundo";

            //Prueba
            try
            {
                await messageRep.UpdateAsync(model);
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
            CorrespondenceRepository messageRep = new CorrespondenceRepository(null);
            var Id = 4;

            //Prueba
            try
            {
                await messageRep.DeleteAsync(Id);
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

        [TestMethod]
        public async void GetAsyncByIdCorrespondenceNoRegister()
        {
            //Preparación
            Exception expectedException = null;
            DbContextOptions<CIDETDataContext> options = new DbContextOptions<CIDETDataContext>();
            CorrespondenceRepository messageRep = new CorrespondenceRepository(null);
            int CorrespondenceId = 4;

            //Prueba
            try
            {
                await messageRep.GetAsync(CorrespondenceId);
                Assert.Fail("Un error debió ser arrojado");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Verificación
            Assert.IsTrue(expectedException is ApplicationException);
            Assert.AreEqual("La consulta no arrojo ningún resultado con ese CorrespondenceId", expectedException.Message);

        }
    }
}
