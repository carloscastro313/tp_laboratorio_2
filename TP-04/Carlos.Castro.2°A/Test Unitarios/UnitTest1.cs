using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaPaqueteInstaciada()
        {
            Correo correo = new Correo();

            Assert.IsInstanceOfType(correo.Paquetes, typeof(List<Paquete>));
        }

        [TestMethod]
        public void TestCompararTrackingID()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Peru", "23-242-23");
            Paquete p2 = new Paquete("Argentina", "14-212-43");
            Paquete p3 = new Paquete("Indonesia", "23-011-99");
            Paquete p4 = new Paquete("Chile", "23-242-23");

            correo += p1;
            correo += p2;
            correo += p3;

            try
            {
                correo += p4;
            }
            catch (TrackingIdRepetidoException ex)
            {

                Assert.IsInstanceOfType(ex, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
